using ETicaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class CariController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: Cari
        public ActionResult Index()
        {
            var a = context.Carilers.Where(x=>x.Durum==true). ToList();
            return View(a);
        }
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cari cari)
        {
            if (ModelState.IsValid)
            {
                cari.Durum = true;
                context.Carilers.Add(cari);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           else
            return View(cari);
        }
        public ActionResult Sil(int id)
        {
            var a=context.Carilers.Find(id);
            a.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = context.Carilers.Find(id);
            return View(cari);

        }
        public ActionResult Guncelle(Cari cari)
        {
            if (ModelState.IsValid)
            {
                context.Entry(cari).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(cari);
            }
          


        }
        public ActionResult Detay(int id)
        {
            var cari = context.Carilers.Find(id);
            return View(cari);
        }
    }
}