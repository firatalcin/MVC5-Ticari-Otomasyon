using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman

        Context c = new Context();
        public ActionResult DepartmanListele()
        {
            var departman = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(departman);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            c.Departmans.Add(departman);
            c.SaveChanges();
            return RedirectToAction("DepartmanListele");
        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("DepartmanListele");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmans.Find(id);
            return View("DepartmanGetir", dep);
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dep = c.Departmans.Find(departman.DepartmanId);
            dep.DepartmanAd = departman.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("DepartmanListele");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var deger = c.Departmans.SingleOrDefault(x => x.DepartmanId == id);
            ViewBag.dgr1 = deger.DepartmanAd;
            return View(degerler);
        }
    }
}