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
using System.IO;
using TicariOtomasyon.Models.IEnumerable;

namespace TicariOtomasyon.Controllers
{
    public class PersonellerController : Controller
    {
        // GET: Personeller
        MyDbContext c = new MyDbContext();
        public PersonellerController()
        {
            List<SelectListItem> drop1 = (from item in c.departmanlars.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.DepartmanAd,
                                              Value = item.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.d1 = drop1;
            List<SelectListItem> sehir = (from item in c.sehirlers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.SehirAd,
                                              Value = item.SehirID.ToString()
                                          }).ToList();
            ViewBag.Sehir = sehir;
        }
        public ActionResult Index(int sayfa = 1)
        {
            return View(c.personels.ToList().ToPagedList(sayfa, 5));
        }
        public ActionResult Psil(int id)
        {
            var Psil = c.personels.Find(id);
            Psil.PersonelDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult pEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult pEkle(Personel p)
        {
            PersonelValidator pv = new PersonelValidator();
            ValidationResult result = pv.Validate(p);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0 && Request.Files != null)
                {
                    string Daadi = Path.GetFileName(Request.Files[0].FileName);
                    string Duzanti = Path.GetExtension(Request.Files[0].FileName);
                    string Dyol = "~/Images/" + Daadi + Duzanti;
                    Request.Files[0].SaveAs(Server.MapPath(Dyol));
                    p.PersonelFoto = "/Images/" + Daadi + Duzanti;
                }
                p.PersonelDurum = true;
                c.personels.Add(p);
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
        public ActionResult pGetir(int id)
        {
            var pListele = c.personels.Find(id);
            var nameSurname = pListele.PersonelAd + " " + pListele.PersonelSoyad;
            ViewBag.veri = nameSurname;
            var image = pListele.PersonelFoto;
            ViewBag.img = image;
            var depertman = pListele.Departman.DepartmanAd;
            ViewBag.dep = depertman;
            return View("pGetir", pListele);
        }
        public ActionResult pGuncelle(Personel p)
        {
            PersonelValidator pv = new PersonelValidator();
            ValidationResult result = pv.Validate(p);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string ad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Images/" + ad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.PersonelFoto = "/Images/" + ad + uzanti;
                }
                var pGun = c.personels.Find(p.PersonelID);
                pGun.PersonelAd = p.PersonelAd;
                pGun.PersonelSoyad = p.PersonelSoyad;
                pGun.PersonelMail = p.PersonelMail;
                pGun.PersonelAdres = p.PersonelAdres;
                pGun.PersonelFoto = p.PersonelFoto;
                pGun.PersonelSifre = p.PersonelSifre;
                pGun.PersonelTelNo = p.PersonelTelNo;
                pGun.PersonelDT = p.PersonelDT;
                pGun.PersonelDurum = true;
                pGun.DepartmanID = p.DepartmanID;
                pGun.SehirID = p.SehirID;
                pGun.Cinsiyet = p.Cinsiyet;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("pGetir");
                }
            }
            return View();
        }
        public PartialViewResult SatisGecmis(int? id, int sayfa = 1)
        {
            var gecmis = c.satislars.Where(x => x.PersonelID == id).ToList().ToPagedList(sayfa, 5);
            var idno = c.personels.Where(d => d.PersonelID == id).Select(z => z.PersonelID);
            ViewBag.id = idno;
            return PartialView(gecmis);
        }
        public PartialViewResult GenelSatisOrt(int id)
        {
            var genelsatis = from item in c.satislars.Where(x => x.PersonelID == id)
                             group item by item.Personel.PersonelAd + " " + item.Personel.PersonelSoyad into g
                             select new PersonelGrup
                             {
                                 PerAd = g.Key,
                                 PerSatis = g.Count()
                             };
            ViewBag.satis = genelsatis;
            return PartialView(genelsatis);
        }
    }
}