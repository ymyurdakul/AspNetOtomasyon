using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaret.Models;
using System.IO;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace ETicaret.Controllers
{
    public class KargoesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Kargoes
        public async Task<ActionResult> Index(string key)
        {
            if (key==null)
            {
                return View(await db.Kargos.ToListAsync());

            }
            else
            {
                return View(await db.Kargos.Where(x=>x.TakipKodu==key).ToListAsync());
            }
        }

        // GET: Kargoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = await db.Kargos.FindAsync(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // GET: Kargoes/Create
        public ActionResult Create()
        {
            string GuidKey = Guid.NewGuid().ToString();
            ViewBag.key = GuidKey;
            return View();
        }

        // POST: Kargoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KargoId,Acıklama,TakipKodu,Personel,Alıcı,Tarih")] Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                db.Kargos.Add(kargo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(kargo);
        }

        // GET: Kargoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = await db.Kargos.FindAsync(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // POST: Kargoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KargoId,Acıklama,TakipKodu,Personel,Alıcı,Tarih")] Kargo kargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kargo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kargo);
        }

        // GET: Kargoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kargo kargo = await db.Kargos.FindAsync(id);
            if (kargo == null)
            {
                return HttpNotFound();
            }
            return View(kargo);
        }

        // POST: Kargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kargo kargo = await db.Kargos.FindAsync(id);
            db.Kargos.Remove(kargo);
            await db.SaveChangesAsync();
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
        public ActionResult KargoDetay(String TakipKodu)
        {
            KargoTakip detay = db.KargoTakips.Where(x=>x.TakipKod==TakipKodu).FirstOrDefault();
            ViewBag.kod = CreateQr(detay.TakipKod);
            return View(detay);
        }
        public string CreateQr(string kod)
        {
            var image = "";
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator generator = new QRCodeGenerator();
                var qrdata = generator.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(qrdata);
                using (Bitmap bitmep = code.GetGraphic(10))
                {
                    bitmep.Save(ms, ImageFormat.Png);
                     image = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

            }
            return image;
        }
    }
}
