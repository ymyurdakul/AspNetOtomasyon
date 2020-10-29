using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class DefaultController : Controller
    {

      public  class theErkisi
        {
            public string ad { get; set; }
            public string soyad { get; set; }
        }

        public JsonResult test(theErkisi erkisi)
        {
            string a = erkisi.ad;
            string b = erkisi.soyad;

            return Json(erkisi);
        }
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}