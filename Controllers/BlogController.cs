using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Classes;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum blg = new BlogYorum();
        // GET: Blog
        public ActionResult Index()
        {
            // var bloglar = c.Blogs.ToList();
            blg.Deger1 = c.Blogs.OrderByDescending(p => p.ID).Take(5).ToList();
            return View(blg);
        }
        
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x=>x.ID==id).ToList();
            blg.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            blg.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();

            return View(blg);
        }

       [HttpGet]
       public PartialViewResult YorumYapmak(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYapmak(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();

        }


    }
}