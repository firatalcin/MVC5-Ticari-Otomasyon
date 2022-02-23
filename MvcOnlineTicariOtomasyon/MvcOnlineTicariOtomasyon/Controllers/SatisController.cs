using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis

        Context c = new Context();
        public ActionResult SatisListele()
        {
            var satisList = c.satisHarekets.ToList();
            return View(satisList);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunId.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList() 
                                           select new SelectListItem 
                                           { 
                                               Text = x.PersonelAd + " " + x.PersonelSoyad, 
                                               Value = x.PersonelId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satisHareket)
        {
            satisHareket.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.satisHarekets.Add(satisHareket);
            c.SaveChanges();
            return RedirectToAction("SatisListele");
        }
    }
}