// ************************************************************************************
// WEB524 Project Template V1 2224 == ff595ec4-6d59-4556-bbd4-dccaa5fe656f
// Do not change or remove the line above.
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using S2O22A2_LG.EntityModels;
using S2O22A2_LG.Models;

namespace S2O22A2_LG.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineBaseViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>();
                cfg.CreateMap<Invoice, InvoiceLineWithDetailViewModel>();
             

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        public IEnumerable<TrackBaseViewModel> TrackGetAll()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.OrderBy(a => a.Name));
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllRockMetal()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.Where(s => s.GenreId==1|| s.GenreId==3).OrderBy(a => a.Name).ThenBy(a => a.Composer));
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTylerVallance()
        {
           
            //return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.Where(s => including.Contains(s.Composer)).OrderBy(a => a.Composer).ThenBy(a => a.Name));
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.Where(s => s.Composer.Contains("Steven Tyler")&& s.Composer.Contains("Jim Vallance")).OrderBy(a => a.Composer).ThenBy(a => a.Name));
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Longest()
        {
            int numberOfrecords = 50;
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.OrderByDescending(a => a.Milliseconds).Take(numberOfrecords));
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Smallest()
        {
            int numberOfrecords = 50;
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(ds.Tracks.OrderBy(a => a.Bytes).Take(numberOfrecords));
        }

        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll()
        {
            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBaseViewModel>>(ds.Invoices.OrderByDescending(a=>a.InvoiceDate));
        }

        public InvoiceBaseViewModel InvoiceGetById(int id)
        {
            var obj = ds.Invoices.Find(id);

            return obj == null ? null : mapper.Map<Invoice, InvoiceBaseViewModel>(obj);
        }
        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int id)
        {

 
            var obj = ds.Invoices.Where(v => v.InvoiceId == id).Include(v => v.Customer).Include(v => v.Customer.Employee).Include(v=>v.InvoiceLines).Include(v => v.InvoiceLines.Select(ec=>ec.Track).Select(ev=>ev.Album).Select(ss=>ss.Artist)).Include(v => v.InvoiceLines.Select(ec => ec.Track).Select(ev => ev.MediaType)).FirstOrDefault();
          
               var value = mapper.Map<Invoice, InvoiceWithDetailViewModel>(obj);   
            
            return obj == null ? null : value;
        }

    }
}