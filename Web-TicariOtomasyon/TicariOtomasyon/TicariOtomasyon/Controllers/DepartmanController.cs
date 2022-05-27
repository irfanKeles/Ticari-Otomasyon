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
namespace TicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        MyDbContext c = new MyDbContext();
        public ActionResult Index(string ara, int sayfa = 1)
        {
            var dList = c.departmanlars.Where(x => x.DepartmanAd.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 5);
            return View(dList);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departmanlar d)
        {
            DepartmanlarValidator dv = new DepartmanlarValidator();
            ValidationResult result = dv.Validate(d);
            if (result.IsValid)
            {
                c.departmanlars.Add(d);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("Index", c.departmanlars.ToList());
                }
            }
            return View();
        }
        public ActionResult DeSil(int id)
        {
            var desil = c.departmanlars.Find(id);
            desil.DepartmanDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeGetir(int id)
        {
            var DPgetir = c.departmanlars.Find(id);
            return View("DeGetir", DPgetir);
        }
        public ActionResult DpGuncelle(Departmanlar d)
        {
            DepartmanlarValidator dv = new DepartmanlarValidator();
            ValidationResult result = dv.Validate(d);
            if (result.IsValid)
            {
                var dGuncelle = c.departmanlars.Find(d.DepartmanID);
                dGuncelle.DepartmanAd = d.DepartmanAd;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("DeGetir");
                }
            }
            return View();
        }
        public PartialViewResult DpDetay(int id)
        {
            var pList = c.personels.Where(x => x.DepartmanID == id).ToList();
            var pAd = c.departmanlars.Where(x => x.DepartmanID == id).Select(z => z.DepartmanAd).FirstOrDefault();
            ViewBag.pAds = pAd;
            return PartialView(pList);
        }
        public ActionResult DePerSatis(int id)
        {
            var PSList = c.satislars.Where(x => x.PersonelID == id).ToList();
            var pAd = c.personels.Where(x => x.PersonelID == id).Select(z => (z.PersonelAd + " " + z.PersonelSoyad)).FirstOrDefault();
            ViewBag.pAds = pAd;
            return View(PSList);
        }
        public PartialViewResult ToplamSatis(int id)
        {
            var list = from item in c.satislars.Where(x => x.Personel.DepartmanID == id)
                       group item by item.Personel.Departman.DepartmanAd into g
                       select new DepartmanSatis
                       {
                           departmanAd = g.Key,
                           Ds = g.Count()
                       };
            return PartialView(list);
        }
    }
}