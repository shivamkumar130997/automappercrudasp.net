using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2O22A2_LG.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();
        // GET: Tracks
        public ActionResult Index()
        {

            var c = m.TrackGetAll();
            return View(c);
        }
        public ActionResult TrackAllRockMetal()
        {

            var c = m.TrackGetAllRockMetal();
            return View("Index", c);
        }
        public ActionResult TrackAllTylerVallance()
        {

            var c = m.TrackGetAllTylerVallance();
            return View("Index", c);
        }
        public ActionResult TrackAllTop50Longest()
        {

            var c = m.TrackGetAllTop50Longest();
            return View("Index", c);
        }
        public ActionResult TrackAllTop50Smallest()
        {

            var c = m.TrackGetAllTop50Smallest();
            return View("Index", c);
        }


    }
}