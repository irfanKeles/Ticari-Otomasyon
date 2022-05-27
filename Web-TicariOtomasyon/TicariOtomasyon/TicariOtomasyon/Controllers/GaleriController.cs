using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        MyDbContext c = new MyDbContext();
        public ActionResult Index()
        {
            return View(c.urunlerims.ToList()) ;
        }
    }
}