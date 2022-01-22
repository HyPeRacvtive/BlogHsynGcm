using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogHsynGcm.Models;

namespace BlogHsynGcm.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Blog).Include(c => c.User).OrderByDescending(x => x.Id);
            return View(comments.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Include(x => x.User).Where(x => x.Id == id).SingleOrDefault();
            if (!comments.isRead)
            {
                comments.isRead = true;
            }
            db.SaveChanges();
            if (comments == null)
            {
                return HttpNotFound();
            }
            return View(comments);
        }
        public ActionResult Create()
        {
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Header");
            ViewBag.UsersId = new SelectList(db.Users, "Id", "NameSurName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comment,Date,isActive,UsersId,BlogId")] Comments comments)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (ModelState.IsValid)
            {
                comments.User.ipAdress = ip;
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Header", comments.BlogId);
            ViewBag.UsersId = new SelectList(db.Users, "Id", "NameSurName", comments.UsersId);
            return View(comments);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Header", comments.BlogId);
            ViewBag.UsersId = new SelectList(db.Users, "Id", "NameSurName", comments.UsersId);
            return View(comments);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comment,Date,isActive,UsersId,BlogId")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogId = new SelectList(db.Blogs, "Id", "Header", comments.BlogId);
            ViewBag.UsersId = new SelectList(db.Users, "Id", "NameSurName", comments.UsersId);
            return View(comments);
        }
        public ActionResult Delete(int? id)
        {
            Comments comments = db.Comments.Find(id);
            db.Comments.Remove(comments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CommentConfirm(int id)
        {
            Comments comments = db.Comments.Find(id);
            if (!comments.isActive)
            {
                comments.isActive = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CommentUnConfirm(int id)
        {
            Comments comments = db.Comments.Find(id);
            if (comments.isActive)
            {
                comments.isActive = false;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
