using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.Controllers
{
    public class QrController : Controller
    {
        // GET: Qr
        public ActionResult Index()
        {
            return View();
        }
        // GET: Qr
        [HttpPost]
        public ActionResult Index(string kod)
        {
            using(MemoryStream ms=new MemoryStream())
            {
                QRCodeGenerator generator = new QRCodeGenerator();
                var qrdata = generator.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(qrdata);
                using (Bitmap bitmep = code.GetGraphic(10))
                {
                    bitmep.Save(ms,ImageFormat.Png);
                    ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}