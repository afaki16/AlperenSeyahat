using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Classes;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        // GET: Default
        public ActionResult Index()
        {
            var dgr = c.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return View(dgr);
        }
        public ActionResult About()
        {

            return View();
        }
        public PartialViewResult Partial1()
        {
            var dgr = c.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();

            return PartialView(dgr);
        }
        public PartialViewResult Partial2()
        {
            var dgr = c.Blogs.Where(x => x.ID==1).ToList();

            return PartialView(dgr);
        }
        public PartialViewResult Partial3()
        {
            var dgr = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();

            return PartialView(dgr);
        }
        public PartialViewResult Partial4()
        {
            var dgr = c.Blogs.Take(3).ToList();

            return PartialView(dgr);
        }
    }
}