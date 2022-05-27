using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Concrete;
using TicariOtomasyon.Models.IEnumerable;
using TicariOtomasyon.ValidationRules;
using PagedList;
using System.IO;

namespace TicariOtomasyon.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MyDbContext c = new MyDbContext();
        public UrunlerController()
        {
            List<SelectListItem> sehir = (from item in c.sehirlers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.SehirAd,
                                              Value = item.SehirID.ToString()
                                          }).ToList();
            List<SelectListItem> Drop = (from item in c.kategorilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.KategoriAd,
                                             Value = item.KategoriID.ToString()
                                         }).ToList();
            List<SelectListItem> DropMarka = (from item in c.Markalars.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = item.MarkaAd,
                                                  Value = item.MarkaID.ToString()
                                              }).ToList();
            List<SelectListItem> personel = (from x in c.personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = (x.PersonelAd + "" + x.PersonelSoyad),
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.per = personel;
            ViewBag.drop1 = Drop;
            ViewBag.dropMarka = DropMarka;
            ViewBag.sehir = sehir;
        }
        public ActionResult Index(string ara)
        {
            var urunlis = c.urunlerims.Where(x => x.UrunDurum == true).Where(x => x.UrunAd.Contains(ara) || ara == null).ToList();

            return View(urunlis);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urunlerim u)
        {
            UrunlerimValidator uv = new UrunlerimValidator();
            ValidationResult result = uv.Validate(u);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fad = Path.GetFileName(Request.Files[0].FileName);
                    string fuzati = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Images/" + fad + fuzati;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.UrunFoto = "/Images/" + fad + fuzati;
                }
                u.UrunDurum = true;
                c.urunlerims.Add(u);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var items in result.Errors)
                {
                    ModelState.AddModelError(items.PropertyName, items.ErrorMessage);
                    return View();
                }
            }
            return View();
        }
        public ActionResult urunSil(int id)
        {
            var urunSil = c.urunlerims.Find(id);
            urunSil.UrunDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UurnGetir(int id)
        {
            var urungetir = c.urunlerims.Find(id);
            ViewBag.foto = urungetir.UrunFoto;
            ViewBag.id = urungetir.UrunID;
            return View("UurnGetir", urungetir);
        }
        public ActionResult UrunGuncelle(Urunlerim u, Detay d)
        {
            UrunlerimValidator uv = new UrunlerimValidator();
            ValidationResult result = uv.Validate(u);
            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string ad = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Images/" + ad + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    u.UrunFoto = "/Images/" + ad + uzanti;
                }
                var urun = c.urunlerims.Find(u.UrunID);
                urun.UrunAd = u.UrunAd;
                urun.UrunBilgi = u.UrunBilgi;
                urun.UrunStok = u.UrunStok;
                urun.UrunFoto = u.UrunFoto;
                urun.UrunSatisFiyat = u.UrunSatisFiyat;
                urun.UrunAlisFiyat = u.UrunAlisFiyat;
                urun.KategoriID = u.KategoriID;
                urun.MarkaID = u.MarkaID;
                urun.UrunDurum = true;
                //-----------------
                var de = c.detays.Find(d.UrunID);
                de.Acıklama = d.Acıklama;
                //-----------------
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View("UurnGetir");
                }
            }
            return View();
        }
        public ActionResult urunDetay(int id)
        {
            var list = c.urunlerims.Where(x => x.UrunID == id).ToList();
            var yorumPuan = c.yorumPuans.Where(q => q.UrunID == id);
            double avg = 0;
            if (yorumPuan.Any())
                avg = yorumPuan.Average(x => x.Puan);
            var sum = c.yorumPuans.Where(x => x.UrunID == id).Count();
            var urunhakkinda = c.detays.Where(x => x.UrunID == id).Select(y => y.Acıklama).FirstOrDefault();
            ViewBag.UHakkında = urunhakkinda;
            ViewBag.avg = avg;
            ViewBag.sum = sum;
            return View(list);
        }
        public PartialViewResult Yorumlar(int id)
        {
            var yList = c.yorumPuans.Where(x => x.UrunID == id).ToList();
            double avg = 0;
            if (yList.Any())
                avg = yList.Average(x => x.Puan);
            ViewBag.avg = avg;
            return PartialView(yList);
        }
        public PartialViewResult yorumGetir(int id)
        {
            var yorum = c.detays.Find(id);
            var yid = c.detays.Where(x => x.UrunID == id).Select(x => x.UrunID);
            ViewBag.id = yid;
            return PartialView("yorumGetir", yorum);
        }
        public PartialViewResult yorumSil(int id)
        {
            var yList = c.yorumPuans.Where(x => x.YorumDurum == true).Where(x => x.UrunID == id).ToList();
            double avg = 0;
            if (yList.Any())
                avg = yList.Average(x => x.Puan);
            ViewBag.avg = avg;
            return PartialView(yList);
        }
        public ActionResult yorumKaldir(int id)
        {
            var ySİl = c.yorumPuans.Find(id);
            ySİl.YorumDurum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UrunSatis(int id)
        {
            var data = c.urunlerims.Find(id);
            ViewBag.Did = data.UrunID;
            ViewBag.Dad = data.UrunAd;
            ViewBag.Dfiyat = data.UrunSatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult UrunSatis(Satislar s, int id)
        {
            SatislarValidator sv = new SatislarValidator();
            ValidationResult result = sv.Validate(s);
            if (result.IsValid)
            {
                var deneme = c.urunlerims.Select(z => z.UrunSatisFiyat).FirstOrDefault();
                s.SatisFiyat = deneme;
                s.SatisToplamFiyat = s.SatisFiyat * s.SatisAdet;
                s.SatisTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
                s.SatisDurum = true;
                s.UrunID = id;
                c.satislars.Add(s);
                c.SaveChanges();
                return RedirectToAction("Index", "Satislar");
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
    }
}