using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Charts;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        MyDbContext c = new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunList(), JsonRequestBehavior.AllowGet);
        }
        public List<UrunStok> UrunList()
        {
            List<UrunStok> us = new List<UrunStok>();
            using (var c = new MyDbContext())
            {
                us = c.urunlerims.Select(x => new UrunStok
                {
                    uAdi = x.UrunAd,
                    uStk = x.UrunStok
                }).ToList();
            }
            return us;
        }

    }
}