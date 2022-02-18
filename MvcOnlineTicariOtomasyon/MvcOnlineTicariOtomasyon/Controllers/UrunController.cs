using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult UrunListele()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.KategoriAdi,
                                                Value = x.KategoriId.ToString()
                                            }).ToList();
            ViewBag.dgr1 = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("UrunListele");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("UrunListele");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = c.Uruns.Find(id);
            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAdi,
                                                 Value = x.KategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr1 = degerler;
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunId);
            urn.UrunAd = p.UrunAd;
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.KategoriId = p.KategoriId;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("UrunListele");
        }
    }
}