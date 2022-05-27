using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Concrete;
using TicariOtomasyon.Models.IEnumerableGroup;
using TicariOtomasyon.ValidationRules;
using PagedList;
using PagedList.Mvc;
using TicariOtomasyon.Models.Kategori_urun;

namespace TicariOtomasyon.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        MyDbContext c = new MyDbContext();
        public ActionResult Index(string ara, int sayfa = 1)
        {
            var kList = c.kategorilers.Where(x => x.KategoriAd.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 5);
            return View(kList);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler k)
        {
            KategorilerValidator kv = new KategorilerValidator();
            ValidationResult result = kv.Validate(k);
            if (result.IsValid)
            {
                k.KategoriDurum = true;
                c.kategorilers.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("Index", c.kategorilers.ToList());
                }
            }
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var katesil = c.kategorilers.Find(id);
            c.kategorilers.Remove(katesil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var verilergetir = c.kategorilers.Find(id);
            return View("KategoriGetir", verilergetir);
        }
        public ActionResult KategoriGuncelle(Kategoriler k)
        {
            KategorilerValidator kv = new KategorilerValidator();
            ValidationResult result = kv.Validate(k);
            if (result.IsValid)
            {
                var kateguncelle = c.kategorilers.Find(k.KategoriID);
                kateguncelle.KategoriAd = k.KategoriAd;
                kateguncelle.KategoriDurum = k.KategoriDurum;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("KategoriGetir");
        }
        public PartialViewResult Kategoriurun(int id)
        {
            var kList = from item in c.urunlerims.Where(x => x.KategoriID == id)
                        group item by item.Kategoriler.KategoriAd into g
                        select new KategoriGrup
                        {
                            KategoriAd = g.Key,
                            KategoriSayi = g.Count()
                        };
            return PartialView(kList);
        }
        public PartialViewResult KategoriurunList(int id)
        {
            var kListele = c.urunlerims.Where(x => x.KategoriID == id).ToList();
            return PartialView(kListele);
        }
        public PartialViewResult KategoriSatisOran(int id)
        {
            var oran = from item in c.satislars.Where(x => x.Urunlerim.KategoriID == id)
                       group item by item.Urunlerim.Kategoriler.KategoriAd into g
                       select new KategoriGrup
                       {
                           KategoriAd = g.Key,
                           KategoriSayi = g.Count()
                       };
            return PartialView(oran);
        }
        public ActionResult KategoriUrunDrop()
        {
            KategoriUrunList ku = new KategoriUrunList();
            ku.KATEGORILER = new SelectList(c.kategorilers, "KategoriID", "KategoriAd");
            ku.URUNLER = new SelectList(c.urunlerims, "UrunID", "UrunAd");
            return View(ku);
        }
        public JsonResult urunListem(int p)
        {
            var allUrunList = (from item in c.urunlerims
                               join y in c.kategorilers
                               on item.Kategoriler.KategoriID equals y.KategoriID
                               where item.Kategoriler.KategoriID == p
                               select new
                               {
                                   Text = item.UrunAd,
                                   Value = item.UrunID
                               }).ToList();
            return Json(allUrunList, JsonRequestBehavior.AllowGet);
        }
    }
}