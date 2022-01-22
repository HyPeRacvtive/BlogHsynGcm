using BlogHsynGcm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogHsynGcm.Controllers
{
    public class SecurityController : Controller
    {
        DataContext context = new DataContext();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Writers w)
        {
            var Login = context.Writers.FirstOrDefault(x => x.UserName == w.UserName && x.Password == w.Password);

            if (Login != null)
            {
                Session["AdminUser"] = Login.NameSurname;
                FormsAuthentication.SetAuthCookie(Login.UserName, false);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.ErrorLogin = "Kullanıcı Adı Veya Parola Hatalı";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}