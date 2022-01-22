using BlogHsynGcm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.IO;

namespace BlogHsynGcm.Controllers
{
    public class AdminController : Controller
    {
        DataContext context = new DataContext();
        [Authorize]
        public ActionResult Index()
        {
            var Blog = context.Blogs.Where(x => x.isAdminActive == true).ToList().Count();
            ViewBag.InfoBlog = Blog;
            var Comment = context.Comments.ToList().Count();
            ViewBag.InfoComment = Comment;
            var Message = context.Messages.ToList().Count();
            ViewBag.InfoMessage = Message;
            var User = context.Users.ToList().Count();
            ViewBag.InfoUser = User;

            return View();
        }
        [Authorize]
        public ActionResult Social(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialFeed socialFeed = context.SocialFeed.Find(id);
            if (socialFeed == null)
            {
                return HttpNotFound();
            }
            return View(socialFeed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Social([Bind(Include = "Id,FaceBook,Twitter,Instagram,Youtube,LinkEdIn")] SocialFeed socialFeed)
        {
            if (ModelState.IsValid)
            {
                context.Entry(socialFeed).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Social/1");
            }
            return View(socialFeed);
        }
        public ActionResult Users()
        {
            return View(context.Users.ToList());
        }
        public ActionResult About(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writers w = context.Writers.Find(id);
            if (w == null)
            {
                return HttpNotFound();
            }
            return View(w);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult About([Bind(Include = "Id,NameSurname,Phone,Mail,Password,About,AboutHeader,ShortAbout,Address,Image")] Writers w)
        {

            if (Request.Files.Count > 0)
            {
                string FileName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string Map = @"~\Content\UploadImage\" + FileName;
                Request.Files[0].SaveAs(Server.MapPath(Map));
                w.Image = FileName;
            }

            context.Entry(w).State = EntityState.Modified;
            context.SaveChanges();
            return View(w);
        }

       public ActionResult UserProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writers writers = context.Writers.Find(id);
            if (writers == null)
            {
                return HttpNotFound();
            }
            return View(writers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfile([Bind(Include = "Id,NameSurname,UserName,Phone,Mail,Password,About,AboutHeader,ShortAbout,Address,Image")] Writers writers)
        {
            if (Request.Files.Count > 0)
            {
                string FileName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string Map = @"~\Content\UploadImage\" + FileName;
                Request.Files[0].SaveAs(Server.MapPath(Map));
                writers.Image = FileName;
            }

            context.Entry(writers).State = EntityState.Modified;
                context.SaveChanges();
            
            return View(writers);
        }

        public ActionResult SiteSetting(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings settings = context.Settings.Find(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SiteSetting([Bind(Include = "Id,Logo,VisitorCount,LogoWidth,LogoHeight")] Settings settings)
        {
            if (Request.Files.Count > 0)
            {
                string FileName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string Map = @"~\Content\UploadImage\" + FileName;
                Request.Files[0].SaveAs(Server.MapPath(Map));
                settings.Logo = FileName;

            }
            context.Entry(settings).State = EntityState.Modified;
            context.SaveChanges();

            return View(settings);
        }


    }
}