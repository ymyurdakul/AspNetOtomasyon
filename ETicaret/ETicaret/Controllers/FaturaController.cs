using ETicaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class FaturaController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: Fatura
        public ActionResult Index()
        {
            return View(context.Fatulars.ToList());
        }
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                context.Fatulars.Add(fatura);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fatura);
        }

        public ActionResult FaturaGuncelle(int id)
        {
            return View(context.Fatulars.Find(id));
        }
        [HttpPost]
        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fatura).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(fatura);
        }
        public ActionResult Detaylar(int id)
        {
           var fatura= context.Fatulars.Find(id);
           return View( fatura);
        }
        [HttpGet]
        public ActionResult KalemEkle(int id)
        {
            ViewBag.id =id;
            return View();
        }
        [HttpPost]
        public ActionResult KalemEkle(FaturaKalem kalem)
        {
            if (ModelState.IsValid)
            {
                context.FaturaKalems.Add(kalem);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kalem);
        }
    }
}