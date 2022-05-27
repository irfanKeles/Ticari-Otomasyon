using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrkod = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = qrkod.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resin = karekod.GetGraphic(10))
                {
                    resin.Save(ms, ImageFormat.Png);
                    ViewBag.qr = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}