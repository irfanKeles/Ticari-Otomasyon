using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        MyDbContext c = new MyDbContext();
        public AdminLoginController()
        {

        }
        public ActionResult Index(Admin a)
        {
            var quest = c.admins.FirstOrDefault(x => x.AdminKullaniciAd == a.AdminKullaniciAd && x.AdminSifre == a.AdminSifre);
            if(quest != null)
            {
                FormsAuthentication.SetAuthCookie(quest.AdminKullaniciAd, false);
                Session["AdminKullaniciAd"] = quest.AdminKullaniciAd.ToString();
                return RedirectToAction("HızlıErisim", "Istatistik");
            }
            else
            {
                return View();
            }
        }
    }
}