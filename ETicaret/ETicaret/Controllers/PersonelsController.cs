using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaret.Models;

namespace ETicaret.Controllers
{
    [Route(Name ="Personel")]
    public class PersonelsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Personels
        public ActionResult Index(string name)
        {
            if (name==null)
            {
                var personels = db.Personels.Include(p => p.Departman);
                return View(personels.ToList());
            }
            else
            {

                var personels = db.Personels.Include(p => p.Departman).Where(x=>x.PersonelAd.Contains(name)||x.PersonelSoyad.Contains(name));
                return View(personels.ToList());
            }
           
        }

        // GET: Personels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personels/Create
        public ActionResult Create()
        {
            ViewBag.DepartmanId = new SelectList(db.Departmans, "DepartmanID", "DepartmanAd");
            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public ActionResult Create( Personel personel, HttpPostedFileBase PersonelGorsel)
        {
            if (PersonelGorsel != null && PersonelGorsel.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/"),
                                               Path.GetFileName(PersonelGorsel.FileName));
                    PersonelGorsel.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    personel.PersonelGorsel = PersonelGorsel.FileName;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            if (ModelState.IsValid)
            {
                db.Personels.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmanId = new SelectList(db.Departmans, "DepartmanID", "DepartmanAd", personel.DepartmanId);
            return View(personel);
        }

        // GET: Personels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmanId = new SelectList(db.Departmans, "DepartmanID", "DepartmanAd", personel.DepartmanId);
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         public ActionResult Edit(  Personel personel,HttpPostedFile PersonelGorsel)
        {
            if (PersonelGorsel != null && PersonelGorsel.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/"),
                                               Path.GetFileName(PersonelGorsel.FileName));
                    PersonelGorsel.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    personel.PersonelGorsel = PersonelGorsel.FileName;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
 
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
            ViewBag.DepartmanId = new SelectList(db.Departmans, "DepartmanID", "DepartmanAd", personel.DepartmanId);
            return View(personel);
        }

        // GET: Personels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personels.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personels.Find(id);
            db.Personels.Remove(personel);
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
        public ActionResult CardOfPersonel(int id)
        {
            return View(db.Personels.Find(id));
        }
    }
}
