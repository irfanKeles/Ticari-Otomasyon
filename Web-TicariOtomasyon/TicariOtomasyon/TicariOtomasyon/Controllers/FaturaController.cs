using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Concrete;
using TicariOtomasyon.Models.IEnumerable;
using TicariOtomasyon.ValidationRules;

namespace TicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        MyDbContext c = new MyDbContext();
        public FaturaController()
        {
            List<SelectListItem> fList = (from item in c.faturalars.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.FaturaSıraNo,
                                              Value = item.FaturaID.ToString()
                                          }).ToList();
            ViewBag.fList = fList;
        }
        public ActionResult Index()
        {
            return View(c.faturalars.ToList());
        }
        [HttpGet]
        public ActionResult FaturaEKle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEKle(Faturalar f)
        {
            FaturalarValidator fv = new FaturalarValidator();
            ValidationResult result = fv.Validate(f);
            if (result.IsValid)
            {
                f.FaturDurum = true;
                f.FaturaSaat = DateTime.Parse(DateTime.Now.ToShortTimeString());
                f.FaturaTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.faturalars.Add(f);
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
        public ActionResult Ggetir(int id)
        {
            var getir = c.faturalars.Find(id);
            return View("Ggetir", getir);
        }
        public ActionResult FGuncelle(Faturalar f)
        {
            FaturalarValidator fv = new FaturalarValidator();
            ValidationResult result = fv.Validate(f);
            if (result.IsValid)
            {
                var guncel = c.faturalars.Find(f.FaturaID);
                guncel.FaturaSaat = f.FaturaSaat;
                guncel.FaturaTarih = f.FaturaTarih;
                guncel.FaturDurum = f.FaturDurum;
                guncel.ToplamTutar = f.ToplamTutar;
                guncel.FaturaSeriNO = f.FaturaSeriNO;
                guncel.FaturaSıraNo = f.FaturaSıraNo;
                guncel.FaturaVergiDairesi = f.FaturaVergiDairesi;
                guncel.FaturKesen = f.FaturKesen;
                guncel.FaturAlan = f.FaturAlan;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("Ggetir");
                }
            }
            return View();
        }
        public ActionResult Ficerik(int id)
        {
            var icerik = c.faturaIceriks.Where(x => x.FaturaID == id).ToList();
            return View(icerik);
        }
        public PartialViewResult Ficerigi(int id)
        {
            var icerik = c.faturaIceriks.Where(x => x.FaturaID == id).ToList();
            return PartialView(icerik);
        }
        [HttpGet]
        public ActionResult FIcerğiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FIcerğiEkle(FaturaIcerik fi)
        {
            c.faturaIceriks.Add(fi);
            fi.FaturaTutar = fi.FaturaBirimFiyat * fi.FaturaMiktar;
            fi.FaturaDurum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DinamikF()
        {
            GlobalIEnumerable ge = new GlobalIEnumerable();
            ge.Ifaturalar = c.faturalars.ToList();
            ge.Ifaturaicerik = c.faturaIceriks.ToList();
            return View(ge);
        }
    }
}