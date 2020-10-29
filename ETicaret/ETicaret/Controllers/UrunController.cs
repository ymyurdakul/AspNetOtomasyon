using ETicaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class UrunController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler= context.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            SelectList item = new SelectList(context.Kategoris, "KategoriID", "KategoriAd");
            ViewBag.KategoriId = item;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            if (ModelState.IsValid)
            {
                context.Uruns.Add(urun);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urun);
      
         }

        public ActionResult Sil(int id)
        {
          var a=  context.Uruns.Find(id);
          a.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        } 
        public ActionResult UrunGetir(int id)
        {
            SelectList item = new SelectList(context.Kategoris, "KategoriID", "KategoriAd");
            ViewBag.items = item;
            var urun = context.Uruns.Find(id);
            return View(urun);
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            if (ModelState.IsValid)
            {
                context.Entry(urun).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");  
            }
         

        }
        public ActionResult UrunListele()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        public ActionResult UrunDetay(int id)
        {
            var a = context.Uruns.Find(id);
            return View(a);
        }

        public ActionResult SatısYap(int id)
        {
            Urun u = context.Uruns.Find(id);
            ViewBag.CariId = new SelectList(context.Carilers, "CariId", "CariAd");
            ViewBag.PersonelId = new SelectList(context.Personels, "PersonelId", "PersonelAd");
            ViewBag.UrunId = id;
            ViewBag.Fiyat = u.SatısFiyat;
             return View();
        }

        [HttpPost]
        public ActionResult SatısYap(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Today;
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index","SatisHarekets");
        }

    }
}