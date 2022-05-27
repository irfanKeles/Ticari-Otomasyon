using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.Controllers
{
    public class MusteriKontrolPanelController : Controller
    {
        // GET: MusteriKontrolPanel
        MyDbContext c = new MyDbContext();

        public MusteriKontrolPanelController()
        {
            List<SelectListItem> sehir = (from item in c.sehirlers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.SehirAd,
                                              Value = item.SehirID.ToString()
                                          }).ToList(); ;
            ViewBag.Sehir = sehir;
        }
        public string loginMail()
        {
            var Lmail = (string)Session["MusteriMail"];
            return Lmail;
        }
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["MusteriMail"];
            var quest = c.musterilers.FirstOrDefault(x => x.MusteriMail == mail);
            var veriler = mail.ToList();
            ViewBag.ve = veriler;
            return View(quest);
        }
        public ActionResult MGunvelle(Musteriler m)
        {
            var mail = (string)Session["MusteriMail"];
            var quest = c.musterilers.FirstOrDefault(x => x.MusteriMail == mail);
            var bul = quest.MusteriID;
            var mList = c.musterilers.Find(m.MusteriID);
            mList.MusteriAD = m.MusteriAD;
            mList.MusteriSoyad = m.MusteriSoyad;
            mList.MusteriSifre = m.MusteriSifre;
            mList.MusteriTelNo = m.MusteriTelNo;
            mList.MusteriMail = m.MusteriMail;
            mList.MusteriDT = m.MusteriDT;
            mList.MusteriAdres = m.MusteriAdres;
            mList.MusteriFoto = m.MusteriFoto;
            mList.MusteriDurum = m.MusteriDurum;
            mList.SehirID = m.SehirID;
            mList.Cinsiyet = m.Cinsiyet;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult Goruntule()
        {
            var mail = (string)Session["MusteriMail"];
            var quest = c.musterilers.FirstOrDefault(x => x.MusteriMail == mail);
            var bul = quest.MusteriID;
            var list = c.musterilers.Where(x => x.MusteriID == bul).ToList();
            return PartialView(list);
        }
        public PartialViewResult PBilgi()
        {
            var mail = (string)Session["MusteriMail"];
            var quest = c.musterilers.FirstOrDefault(x => x.MusteriMail == mail);
            var bul = quest.MusteriID;
            var list = c.musterilers.Where(x => x.MusteriID == bul).ToList();
            var satis = c.satislars.Where(x => x.MusteriID == bul).Count();
            ViewBag.TS = satis;
            return PartialView(list);
        }
        public PartialViewResult YList(string ara)
        {
            var mail = (string)Session["MusteriMail"];
            var quest = c.musterilers.FirstOrDefault(x => x.MusteriMail == mail);
            var bul = quest.MusteriID;
            var list = c.yorumPuans.Where(x => x.MusteriID == bul).Where(x => x.Urunlerim.UrunAd.Contains(ara) || ara == null).ToList();
            return PartialView(list);
        }
        public ActionResult SatisGecmisi(string ara)
        {
            var mail = (string)Session["MusteriMail"];
            var quest = c.musterilers.FirstOrDefault(x => x.MusteriMail == mail);
            var bul = quest.MusteriID;
            var list = c.satislars.Where(x => x.MusteriID == bul).Where(x => x.Urunlerim.UrunAd.Contains(ara) || ara == null).ToList();
            return View(list);
        }
        public ActionResult GelenKutusu()
        {
            var mail = (string)Session["MusteriMail"];
            var list = c.mesajlars.Where(x => x.MesajDurum == true).Where(x => x.Alici == mail).ToList();
            var toplam = c.mesajlars.Where(x => x.Alici == mail).Count();
            var tgonderilen = c.mesajlars.Where(x => x.Gonderici == mail).Count();
            var silinmisi = c.mesajlars.Where(x => x.MesajDurum == false).Where(x => x.Alici == mail).Count();
            ViewBag.toplam = toplam;
            ViewBag.tgonderilen = tgonderilen;
            ViewBag.silinmisi = silinmisi;
            return View(list);
        }
        public ActionResult GidenKutusu()
        {
            var mail = (string)Session["MusteriMail"];
            var list = c.mesajlars.Where(x => x.MesajDurum == true).Where(x => x.Gonderici == mail).ToList();
            var toplam = c.mesajlars.Where(x => x.Alici == mail).Count();
            var tgonderilen = c.mesajlars.Where(x => x.Gonderici == mail).Count();
            var silinmisi = c.mesajlars.Where(x => x.MesajDurum == false).Where(x => x.Alici == mail).Count();
            ViewBag.toplam = toplam;
            ViewBag.tgonderilen = tgonderilen;
            ViewBag.silinmisi = silinmisi;
            return View(list);
        }
        public ActionResult CopKutusu()
        {
            var mail = (string)Session["MusteriMail"];
            var list = c.mesajlars.Where(x => x.MesajDurum == false).Where(x => x.Alici == mail).ToList();
            var toplam = c.mesajlars.Where(x => x.Alici == mail).Count();
            var tgonderilen = c.mesajlars.Where(x => x.Gonderici == mail).Count();
            var silinmisi = c.mesajlars.Where(x => x.MesajDurum == false).Where(x => x.Alici == mail).Count();
            ViewBag.toplam = toplam;
            ViewBag.tgonderilen = tgonderilen;
            ViewBag.silinmisi = silinmisi;
            return View(list);
        }
        public ActionResult mesajCIerik(int id)
        {
            var mail = (string)Session["MusteriMail"];
            var list = c.mesajlars.Where(x => x.MesajID == id).ToList();

            var toplam = c.mesajlars.Where(x => x.Alici == mail).Count();
            var tgonderilen = c.mesajlars.Where(x => x.Gonderici == mail).Count();
            var silinmisi = c.mesajlars.Where(x => x.MesajDurum == false).Where(x => x.Alici == mail).Count();
            ViewBag.toplam = toplam;
            ViewBag.tgonderilen = tgonderilen;
            ViewBag.silinmisi = silinmisi;
            return View(list);
        }
        [HttpGet]
        public ActionResult mesajGonder()
        {
            var mail = (string)Session["MusteriMail"];
            var toplam = c.mesajlars.Where(x => x.Alici == mail).Count();
            var tgonderilen = c.mesajlars.Where(x => x.Gonderici == mail).Count();
            var silinmisi = c.mesajlars.Where(x => x.MesajDurum == false).Where(x => x.Alici == mail).Count();
            ViewBag.toplam = toplam;
            ViewBag.tgonderilen = tgonderilen;
            ViewBag.silinmisi = silinmisi;
            return View();
        }
        [HttpPost]
        public ActionResult mesajGonder(Mesajlar m)
        {
            var mail = (string)Session["MusteriMail"];
            var toplam = c.mesajlars.Where(x => x.Alici == mail).Count();
            var tgonderilen = c.mesajlars.Where(x => x.Gonderici == mail).Count();
            var silinmisi = c.mesajlars.Where(x => x.MesajDurum == false).Where(x => x.Alici == mail).Count();
            ViewBag.toplam = toplam;
            ViewBag.tgonderilen = tgonderilen;
            ViewBag.silinmisi = silinmisi;


            var mesaj = c.mesajlars.Add(m);
            mesaj.Alici = m.Alici;
            mesaj.Gonderici = mail;
            mesaj.Icerik = m.Icerik;
            mesaj.Konu = m.Konu;
            mesaj.MesajDurum = true;
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaveChanges();
            return RedirectToAction("GidenKutusu");
        }
        public ActionResult kargoTakip(string ara)
        {
            var arama = c.kargoTakips.Where(x => x.TakiipKodu.Contains(ara)).ToList();
            return View(arama);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "LoginPanel");
        }
    }
}