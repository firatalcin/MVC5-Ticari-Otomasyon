using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        Context c = new Context();
        public ActionResult PersonelListele()
        {
            var personelList = c.Personels.ToList();
            return View(personelList);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList();
            ViewBag.dgr1 = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            c.Personels.Add(personel);
            c.SaveChanges();
            return RedirectToAction("PersonelListele");
        }

        public ActionResult PersonelGetir(int id)
        {
            var per = c.Personels.Find(id);
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList();
            ViewBag.dgr1 = degerler;
            return View(per);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var per = c.Personels.Find(personel.PersonelId);
            per.PersonelAd = personel.PersonelAd;
            per.PersonelSoyad = personel.PersonelSoyad;
            per.PersonelGorsel = personel.PersonelGorsel;
            per.DepartmanId = personel.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("PersonelListele");
        }
    }
}