using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context c = new Context();
        public ActionResult CariListele()
        {
            var cariList = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(cariList);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            cari.Durum = true;
            c.Carilers.Add(cari);       
            c.SaveChanges();
            return RedirectToAction("CariListele");
        }

        public ActionResult CariSil(int id)
        {
            var cariSil = c.Carilers.Find(id);
            cariSil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("CariListele");
        }

        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var veri = c.Carilers.Find(id);
            return View(veri);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cariler cari)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var cariGuncelle = c.Carilers.Find(cari.CariId);
            cariGuncelle.CariAd = cari.CariAd;
            cariGuncelle.CariSoyad = cari.CariSoyad;
            cariGuncelle.CariSehir = cari.CariSehir;
            cariGuncelle.CariMail = cari.CariMail;
            c.SaveChanges();
            return RedirectToAction("CariListele");
        }

        public ActionResult CariDetaylar(int id)
        {
            var cariDetay = c.satisHarekets.Where(x => x.CariId == id).ToList();
            var cariSatis = c.Carilers.SingleOrDefault(x => x.CariId == id);
            ViewBag.CariAdi1 = cariSatis.CariAd + " " + cariSatis.CariSoyad;
            return View(cariDetay);
        }
    }
}