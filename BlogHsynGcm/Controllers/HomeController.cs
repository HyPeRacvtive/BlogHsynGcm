using BlogHsynGcm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web.Security;
using PagedList;


namespace BlogHsynGcm.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View(context.Writers.FirstOrDefault());
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,NameSurname,Phone,Mail,isRead,Subject,Message")] Messages messages)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (ModelState.IsValid)
            {
                messages.ipAdress = ip;
                context.Messages.Add(messages);
                context.SaveChanges();
                return RedirectToAction("Contact");
            }

            return View(messages);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Details = context.Blogs.Include(x => x.Categories).Include(x => x.Comments).Include(x => x.Writers).Where(y => y.Id == id).FirstOrDefault();

            ViewBag.After = id + 1;
            ViewBag.Before = id - 1;
            Session["blogId"] = id;
            return View(Details);
        }
        public ActionResult Category(int? id, int? page)
        {
            int _sayfaNo = page ?? 1;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cat = context.Blogs.Include(x => x.Categories).Include(x => x.Comments).Where(x => x.CategoriesId == id && x.isActive == true && x.isAdminActive == true).OrderByDescending(x => x.Id).AsQueryable();
            return View(cat.ToPagedList(_sayfaNo, 5));
        }
        public ActionResult SignUp()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "Id,NameSurName,Password,Mail,Image")] Users users)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (ModelState.IsValid)
            {
                users.ipAdress = ip;
                context.Users.Add(users);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(users);
        }
        public ActionResult SignIn()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SignIn(Users U)
        {
            var user = context.Users.FirstOrDefault(x => x.Mail == U.Mail && x.Password == U.Password);
            if (user != null)
            {
                Session["HomeUser"] = user.NameSurName;
                Session["UserMail"] = user.Mail;
                Session["UserId"] = user.Id;
                Session["UserPassword"] = user.Password;
                FormsAuthentication.SetAuthCookie(user.Mail, false);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.UserError = "Kullanıcı Adı veya Parola Hatalı";
                return PartialView();

            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("HomeUser");
            return RedirectToAction("Index");

        }
    }
}