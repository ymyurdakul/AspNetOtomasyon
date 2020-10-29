using ETicaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class IstatistikController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.d1 = context.Carilers.Count();
            ViewBag.d2 = context.Uruns.Count();
            ViewBag.d3 = context.Personels.Count();
            ViewBag.d4 = context.Kategoris.Count();
            ViewBag.d5 = context.Uruns.Sum(x => x.Stok);
            ViewBag.d6 = context.Uruns.Select(x => x.Marka).Distinct().Count();
            ViewBag.d7 = context.Uruns.Where(x => x.Durum == true).Count();
            ViewBag.d8 = context.Uruns.OrderByDescending(x => x.AlısFiyat).FirstOrDefault().UrunAd;
                
                
                // context.Uruns.Max(x => x.AlısFiyat).ToString() + "₺";
            ViewBag.d9 = context.Uruns.OrderBy(x => x.AlısFiyat).FirstOrDefault().UrunAd;



            ViewBag.d10 = context.Uruns.Where(x => x.UrunAd == "Buzdolabı").Sum(x => x.Stok);
            ViewBag.d11 = context.Uruns.Where(x => x.UrunAd == "Fırın").Sum(x => x.Stok);
            ViewBag.d12 = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault();



                
                var id=context.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault();

            ViewBag.d13 = context.Uruns.Where(x => x.UrunId == id).First().UrunAd;


            ViewBag.d14 = context.SatisHarekets.Sum(x => x.ToplamTutar);

            ViewBag.d15 = context.SatisHarekets.Count(x => x.Tarih == DateTime.Today);

            ViewBag.d16 = context.SatisHarekets.Where(x=>x.Tarih==DateTime.Today).Sum(x => (double?)x.ToplamTutar)??0.0;
                



            return View();
        }
       
        public ActionResult SimpleList()
        {
          var r=  context.Carilers.GroupBy(x => x.CariSehir).Select(e => new SimpleList { count = e.Count(), name = e.Key }).ToList();
            return View(r);
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}