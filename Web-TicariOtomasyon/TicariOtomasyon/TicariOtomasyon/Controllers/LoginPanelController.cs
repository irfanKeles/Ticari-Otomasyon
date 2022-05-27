using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Concrete;
using TicariOtomasyon.ValidationRules;

namespace TicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginPanelController : Controller
    {
        // GET: LoginPanel
        MyDbContext c = new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MUyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MUyeOl(Musteriler m)
        {
            LoginValidator lv = new LoginValidator();
            ValidationResult result = lv.Validate(m);
            if (result.IsValid)
            {
                c.musterilers.Add(m);
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
            return View("Index");
        }
        [HttpGet]
        public ActionResult MLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MLogin(Musteriler m)
        {
            var quest = c.musterilers.FirstOrDefault(x => x.MusteriMail == m.MusteriMail && x.MusteriSifre == m.MusteriSifre);
            if (quest != null)
            {
                FormsAuthentication.SetAuthCookie(quest.MusteriMail, false);
                Session["MusteriMail"] = quest.MusteriMail.ToString();
                return RedirectToAction("Index", "MusteriKontrolPanel");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult Ornek()
        {
            return View();
        }
    }
}