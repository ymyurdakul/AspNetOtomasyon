using ETicaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class DepartmanController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: Departman
        public ActionResult Index()
        {
            var a=context.Departmans.Where(x=>x.Durum==true).ToList();
            return View(a);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            if (ModelState.IsValid)
            {
                context.Departmans.Add(d);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }
        public ActionResult DepartmanSil(int id)
        {
            var r = context.Departmans.Find(id);
            r.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = context.Departmans.Find(id);
            return View(dpt);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman dep)
        {
            context.Entry(dep).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanDetay(int id)
        {
            
     

            var depart = context.Departmans.Find(id);
             return View(depart);
        }
        public ActionResult Deneme()
        {
            return View(context.Departmans.ToList()[0]);
        }
        public ActionResult SatısHareket(int id)
        {
            Personel b = context.Personels.Find(id);
            return View(b.SatisHarekets);
         }
    }
}