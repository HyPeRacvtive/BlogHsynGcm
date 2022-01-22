using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogHsynGcm.Models;

namespace BlogHsynGcm.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private DataContext db = new DataContext();


        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Categories).Include(b => b.Writers).Include(x => x.Comments).Where(x=>x.isAdminActive==true).OrderByDescending(x => x.Id);
            return View(blogs.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blogs = db.Blogs.Find(id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            return View(blogs);
        }


        public ActionResult Create()
        {
            ViewBag.CategoriesId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.WritersId = new SelectList(db.Writers, "Id", "NameSurname");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,BlogContent,Date,Image,LikeCount,isSlider,isEditorschoice,isActive,WritersId,CategoriesId")] Blogs blogs)
        {
            if (Request.Files.Count > 0)
            {
                string FileName = Path.GetFileName(Request.Files[0].FileName);
                string Extension = Path.GetExtension(Request.Files[0].FileName);
                string Map = @"~\Content\HomeStyle\images\BlogImages\" + FileName;
                Request.Files[0].SaveAs(Server.MapPath(Map));
                blogs.Image = FileName;
            }
            db.Blogs.Add(blogs);
            db.SaveChanges();

            ViewBag.CategoriesId = new SelectList(db.Categories, "Id", "Name", blogs.CategoriesId);
            ViewBag.WritersId = new SelectList(db.Writers, "Id", "NameSurname", blogs.WritersId);
            return View(blogs);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blogs = db.Blogs.Find(id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesId = new SelectList(db.Categories, "Id", "Name", blogs.CategoriesId);
            ViewBag.WritersId = new SelectList(db.Writers, "Id", "NameSurname", blogs.WritersId);
            return View(blogs);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,BlogContent,Date,Image,LikeCount,isSlider,isEditorschoice,isActive,WritersId,CategoriesId")] Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesId = new SelectList(db.Categories, "Id", "Name", blogs.CategoriesId);
            ViewBag.WritersId = new SelectList(db.Writers, "Id", "NameSurname", blogs.WritersId);
            return View(blogs);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogs blogs = db.Blogs.Find(id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            return View(blogs);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blogs blogs = db.Blogs.Find(id);
            blogs.isAdminActive = false;
            blogs.isActive = false;
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
