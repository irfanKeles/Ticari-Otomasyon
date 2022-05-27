using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Concrete;
using TicariOtomasyon.Models.IEnumerableGroup;
using TicariOtomasyon.ValidationRules;
using PagedList;
using PagedList.Mvc;

namespace TicariOtomasyon.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MyDbContext c = new MyDbContext();
        public MusteriController()
        {
            List<SelectListItem> sehir = (from item in c.sehirlers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.SehirAd,
                                              Value = item.SehirID.ToString()
                                          }).ToList();
            ViewBag.Sehir = sehir;
        }
        public ActionResult Index(string ara, int sayfa = 1)
        {
            var list = c.musterilers.Where(x => x.MusteriDurum == true).Where(x => x.MusteriAD.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 8);
            return View(list);
        }
        public ActionResult MSil(int id)
        {
            var Msil = c.musterilers.Find(id);
            Msil.MusteriDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(Musteriler p)
        {

            MusterilerValidator mv = new MusterilerValidator();
            ValidationResult result = mv.Validate(p);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string Daadi = Path.GetFileName(Request.Files[0].FileName);
                    string Duzanti = Path.GetExtension(Request.Files[0].FileName);
                    string Dyol = "~/Images/" + Daadi + Duzanti;
                    Request.Files[0].SaveAs(Server.MapPath(Dyol));
                    p.MusteriFoto = "/Images/" + Daadi + Duzanti;
                }
                p.MusteriDurum = true;
                c.musterilers.Add(p);
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
        public ActionResult MSGecmis(int id)
        {
            var listele = c.satislars.Where(x => x.MusteriID == id).ToList();
            var Ad = c.satislars.Where(x => x.MusteriID == id).Select(z => z.Musteriler.MusteriAD + " " + z.Musteriler.MusteriSoyad).FirstOrDefault();
            ViewBag.ads = Ad;
            return View(listele);
        }
        public ActionResult MGetir(int id)
        {
            var mList = c.musterilers.Find(id);
            ViewBag.dt = mList.MusteriDT;

            return View("MGetir", mList);
        }
        public ActionResult MGuncelle(Musteriler m)
        {
            MusterilerValidator mv = new MusterilerValidator();
            ValidationResult result = mv.Validate(m);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string Daadi = Path.GetFileName(Request.Files[0].FileName);
                    string Duzanti = Path.GetExtension(Request.Files[0].FileName);
                    string Dyol = "~/Images/" + Daadi + Duzanti;
                    Request.Files[0].SaveAs(Server.MapPath(Dyol));
                    m.MusteriFoto = "/Images/" + Daadi + Duzanti;
                }
                var mBilgi = c.musterilers.Find(m.MusteriID);
                mBilgi.MusteriAD = m.MusteriAD;
                mBilgi.MusteriSoyad = m.MusteriSoyad;
                mBilgi.MusteriSifre = m.MusteriSifre;
                mBilgi.MusteriTelNo = m.MusteriTelNo;
                mBilgi.MusteriAdres = m.MusteriAdres;
                mBilgi.MusteriMail = m.MusteriMail;
                mBilgi.MusteriFoto = m.MusteriFoto;
                mBilgi.Cinsiyet = m.Cinsiyet;
                mBilgi.SehirID = m.SehirID;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("MGetir");
                }
            }
            return View();
        }
        public PartialViewResult Goruntule(int id)
        {
            var list = c.musterilers.Where(x => x.MusteriID == id).ToList();
            return PartialView(list);
        }
        public PartialViewResult ProfilBilgi(int id)
        {
            var list = c.musterilers.Where(x => x.MusteriID == id).ToList();
            var SumShop = c.satislars.Where(x => x.MusteriID == id).Count();
            ViewBag.toplam = SumShop;
            return PartialView(list);
        }
        public PartialViewResult Ylist(int id, string ara)
        {
            var list = c.yorumPuans.Where(x => x.MusteriID == id).Where(x => x.Urunlerim.UrunAd.Contains(ara) || ara == null).ToList();
            return PartialView(list);
        }

    }
}