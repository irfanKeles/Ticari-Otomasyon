using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        MyDbContext c = new MyDbContext();
        public ActionResult Index(string ara, int sayfa = 1)
        {
            Random rnd = new Random();
            string[] harflerDizi = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", };
            string random = "";
            for (int i = 1; i <= 10; i++)
            {
                random += harflerDizi[rnd.Next(harflerDizi.Length)];
            }
            ViewBag.sonuc = random;

            var Kdetay = c.kargoDetays.Where(x => x.TakipKodu.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 5);
            return View(Kdetay);
        }
        [HttpGet]
        public ActionResult kargoEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult kargoEkle(KargoDetay k)
        {
            k.KargoDurum = true;
            c.kargoDetays.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult kargoTakip(string id)
        {
            var qurey = c.kargoTakips.Where(x => x.TakiipKodu == id).ToList();
            return View(qurey);
        }
    }
}