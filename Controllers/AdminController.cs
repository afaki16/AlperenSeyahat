using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Classes;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog p1)
        {
            c.Blogs.Add(p1);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBlog(int id)
        {
            var br = c.Blogs.Find(id);
            c.Blogs.Remove(br);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir",b);
        }
        public ActionResult BlogGuncelle(Blog p1)
        {
            var b = c.Blogs.Find(p1.ID);
            b.Baslik = p1.Baslik;
            b.Tarih = p1.Tarih;
            b.Aciklama = p1.Aciklama;
            b.BlogImage = p1.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();


            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var sil = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(sil);
            c.SaveChanges();

            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var b = c.Yorumlars.Find(id);
            return View("YorumGetir", b);
        }
        public ActionResult YorumGuncelle(Yorumlar p1)
        {
            var b = c.Yorumlars.Find(p1.ID);
            b.KullanıcıAdi = p1.KullanıcıAdi;
            b.Mail = p1.Mail;
            b.Yorum = p1.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumGuncelle");
        }
    }
}