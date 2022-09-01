using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2O22A2_LG.Controllers
{
    public class InvoiceController : Controller
    {
        private Manager m = new Manager();
        // GET: Invoice
        public ActionResult Index()
        {
            var c = m.InvoiceGetAll();
            return View(c);
        }


        public ActionResult Details(int? id)
        {
            //var obj = m.InvoiceGetById(id.GetValueOrDefault());
            var obj = m.InvoiceGetByIdWithDetail(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }
        public ActionResult Details1(int? id)
        {
            //var obj = m.InvoiceGetById(id.GetValueOrDefault());
            var obj = m.InvoiceGetByIdWithDetail(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }
    }
}