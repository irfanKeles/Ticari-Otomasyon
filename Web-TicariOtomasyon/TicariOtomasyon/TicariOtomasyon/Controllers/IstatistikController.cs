using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Concrete;
using TicariOtomasyon.Models.IEnumerableGroup;

namespace TicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        MyDbContext c = new MyDbContext();
        public IstatistikController()
        {
            var msuteri = c.musterilers.Count().ToString();
            ViewBag.musteri = msuteri;
            //---------------------------------------------
            var urun = c.urunlerims.Count().ToString();
            ViewBag.urun = urun;
            //---------------------------------------------
            var personel = c.personels.Count().ToString();
            ViewBag.personel = personel;
            //---------------------------------------------
            var kat = c.kategorilers.Count().ToString();
            ViewBag.kat = kat;
            //---------------------------------------------
            var stok = c.urunlerims.Sum(x => x.UrunStok).ToString();
            ViewBag.stok = stok;
            //---------------------------------------------
            var marka = c.Markalars.Count().ToString();
            ViewBag.marka = marka;
            //---------------------------------------------
            var kritik = c.urunlerims.Count(x => x.UrunStok <= 20).ToString();
            ViewBag.kritik = kritik;
            //---------------------------------------------
            var yuksek = (from item in c.urunlerims orderby item.UrunSatisFiyat descending select item.UrunAd).FirstOrDefault();
            ViewBag.yuksek = yuksek;
            //---------------------------------------------
            var encok = (from item in c.satislars orderby item.SatisAdet descending select item.Urunlerim.UrunAd).FirstOrDefault();
            ViewBag.encok = encok;
            //---------------------------------------------
            var tsatis = c.satislars.Count().ToString();
            ViewBag.tsatis = tsatis;
            //---------------------------------------------
            var enmusteri = c.satislars.GroupBy(x => x.Musteriler.MusteriAD + " " + x.Musteriler.MusteriSoyad)
                .OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.enmusteri = enmusteri;
            //---------------------------------------------
            var encoksatan = c.satislars.GroupBy(x => x.Urunlerim.UrunAd)
                .OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.encoksatan = encoksatan;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HızlıErisim()
        {
            var kategori = from item in c.satislars
                           group item by item.Urunlerim.Kategoriler.KategoriAd into g
                           select new KategoriGrup
                           {
                               KategoriAd = g.Key,
                               KategoriSayi = g.Count()
                           };
            return View(kategori.ToList());
        }
        public PartialViewResult DataTable()
        {
            var datatable = from item in c.urunlerims
                            group item by item.Markalar.MarkaAd into g
                            select new MarkaGrup
                            {
                                UrunMarka = g.Key,
                                UrunSayi = g.Count()
                            };
            return PartialView(datatable.ToList());
        }
        public PartialViewResult DataTable2()
        {
            var persatis = from item in c.satislars
                           group item by item.Personel.PersonelAd into g
                           select new PersonelGrup
                           {
                               PerAd = g.Key,
                               PerSatis = g.Count()
                           };
            return PartialView(persatis.ToList());
        }
        public PartialViewResult ToDoList()
        {
            var Tolist = c.yapilacaklars.ToList();
            return PartialView(Tolist);
        }
    }
}