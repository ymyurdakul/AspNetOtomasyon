using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaret.Models;

namespace ETicaret.Controllers
{
    public class SatisHareketsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: SatisHarekets
        public ActionResult Index()
        {
          //  var satisHarekets = db.SatisHarekets.Include(s => s.Cari).Include(s => s.Personel).Include(s => s.Urun);
            return View(db.SatisHarekets.ToList());
        }

        // GET: SatisHarekets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            if (satisHareket == null)
            {
                return HttpNotFound();
            }
            return View(satisHareket);
        }

        // GET: SatisHarekets/Create
        public ActionResult Create()
        {
            ViewBag.CariId = new SelectList(db.Carilers, "CariId", "CariAd");
            ViewBag.PersonelId = new SelectList(db.Personels, "PersonelId", "PersonelAd");
            ViewBag.UrunId = new SelectList(db.Uruns, "UrunId", "UrunAd");
            return View();
        }

        // POST: SatisHarekets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatisId,Tarih,Adet,Fiyat,ToplamTutar,UrunId,CariId,PersonelId")] SatisHareket satisHareket)
        {
            if (ModelState.IsValid)
            {
                db.SatisHarekets.Add(satisHareket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CariId = new SelectList(db.Carilers, "CariId", "CariAd", satisHareket.CariId);
            ViewBag.PersonelId = new SelectList(db.Personels, "PersonelId", "PersonelAd", satisHareket.PersonelId);
            ViewBag.UrunId = new SelectList(db.Uruns, "UrunId", "UrunAd", satisHareket.UrunId);
            return View(satisHareket);
        }

        // GET: SatisHarekets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            if (satisHareket == null)
            {
                return HttpNotFound();
            }
            ViewBag.CariId = new SelectList(db.Carilers, "CariId", "CariAd", satisHareket.CariId);
            ViewBag.PersonelId = new SelectList(db.Personels, "PersonelId", "PersonelAd", satisHareket.PersonelId);
            ViewBag.UrunId = new SelectList(db.Uruns, "UrunId", "UrunAd", satisHareket.UrunId);
            return View(satisHareket);
        }

        // POST: SatisHarekets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatisId,Tarih,Adet,Fiyat,ToplamTutar,UrunId,CariId,PersonelId")] SatisHareket satisHareket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satisHareket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CariId = new SelectList(db.Carilers, "CariId", "CariAd", satisHareket.CariId);
            ViewBag.PersonelId = new SelectList(db.Personels, "PersonelId", "PersonelAd", satisHareket.PersonelId);
            ViewBag.UrunId = new SelectList(db.Uruns, "UrunId", "UrunAd", satisHareket.UrunId);
            return View(satisHareket);
        }

        // GET: SatisHarekets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            if (satisHareket == null)
            {
                return HttpNotFound();
            }
            return View(satisHareket);
        }

        // POST: SatisHarekets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SatisHareket satisHareket = db.SatisHarekets.Find(id);
            db.SatisHarekets.Remove(satisHareket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult SatisDetay(int id)
        {
           var satıs= db.SatisHarekets.Find(id);
            return View(satıs); 
        }
    }
}
