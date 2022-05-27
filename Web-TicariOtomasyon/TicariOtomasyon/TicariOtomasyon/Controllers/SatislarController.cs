using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Concrete;
using TicariOtomasyon.ValidationRules;

namespace TicariOtomasyon.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        MyDbContext c = new MyDbContext();
        public SatislarController()
        {
            List<SelectListItem> urun = (from item in c.urunlerims.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.UrunAd,
                                             Value = item.UrunID.ToString()
                                         }).ToList();
            List<SelectListItem> musteri = (from item in c.musterilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = (item.MusteriAD + " " + item.MusteriSoyad),
                                                Value = item.MusteriID.ToString()
                                            }).ToList();
            List<SelectListItem> personel = (from item in c.personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = (item.PersonelAd + " " + item.PersonelSoyad),
                                                 Value = item.PersonelID.ToString()
                                             }).ToList();
            ViewBag.urun = urun;
            ViewBag.msuteri = musteri;
            ViewBag.personel = personel;
        }
        public ActionResult Index()
        {
            return View(c.satislars.ToList());
        }
        [HttpGet]
        public ActionResult SatisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(Satislar s)
        {
            SatislarValidator sv = new SatislarValidator();
            ValidationResult result = sv.Validate(s);
            if (result.IsValid)
            {
                var deneme = c.urunlerims.Where(x => x.UrunID == s.UrunID).Select(z => z.UrunSatisFiyat).FirstOrDefault();
                s.SatisFiyat = deneme;
                s.SatisToplamFiyat = s.SatisFiyat * s.SatisAdet;
                s.SatisTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
                s.SatisDurum = true;
                c.satislars.Add(s);
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
            return View();
        }
        public ActionResult SGetir(int id)
        {
            var getir = c.satislars.Find(id);
            return View("SGetir", getir);
        }
        public ActionResult SGuncelle(Satislar s)
        {
            SatislarValidator sv = new SatislarValidator();
            ValidationResult result = sv.Validate(s);
            if (result.IsValid)
            {
                var SarisFİyat = c.satislars.Where(x => x.UrunID == s.UrunID).Select(z => z.SatisFiyat).FirstOrDefault();
                s.SatisFiyat = SarisFİyat;
                s.SatisToplamFiyat = s.SatisFiyat * s.SatisAdet;
                s.SatisTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
                s.SatisDurum = true;
                var satisAdet = c.satislars.Where(x => x.UrunID == s.UrunID).Select(z => z.SatisAdet).FirstOrDefault();
                satisAdet = s.SatisAdet - s.SatisAdet;
                //--------------------------------------------------------------------
                var guncel = c.satislars.Find(s.SatisID);
                guncel.SatisAdet = satisAdet;
                guncel.SatisToplamFiyat = s.SatisToplamFiyat;

                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("SGetir");
                }
            }
            return View();
        }
        public ActionResult Sdetay()
        {
            var dList = c.satislars.ToList();
            return View(dList);
        }
    }
}