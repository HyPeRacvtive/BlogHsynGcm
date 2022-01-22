using BlogHsynGcm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web.Security;

namespace BlogHsynGcm.Controllers
{
    public class HomePartialController : Controller
    {
        DataContext context = new DataContext();
        // GET: HomePartial
        public ActionResult _HomeSlider()
        {
            var Slider = context.Blogs.Include(x => x.Categories).Include(x => x.Comments).Where(x => x.isActive == true && x.isSlider == true).OrderByDescending(x => x.Id).Take(5).ToList();
            return PartialView(Slider);
        }
        public ActionResult _TrandingBlogs()
        {
            var Tranding = context.Blogs.Include(x => x.Categories).Include(x => x.Comments).Where(x => x.isActive == true).OrderByDescending(x => x.LikeCount).Take(6).ToList();
            return PartialView(Tranding);
        }
        public ActionResult _HomeLastBlogs()
        {
            var LastBlogs = context.Blogs.Include(x => x.Categories).Include(x => x.Comments).OrderByDescending(x => x.Id).Where(x => x.isActive == true).Take(6).ToList();

            return PartialView(LastBlogs);
        }
        public ActionResult _HomeSideBarAbout()
        {
            var HomeAbout = context.Writers.ToList();
            if (HomeAbout == null)
            {
                return RedirectToAction("Admin", "Index");
            }
            return PartialView(HomeAbout);
        }
        public ActionResult _HomeSideBarCategories()
        {
            var HomeCat = context.Categories.Include(c => c.Blogs).ToList();
            if (HomeCat == null)
            {
                return RedirectToAction("Admin", "Index");
            }

            return PartialView(HomeCat);
        }
        public ActionResult _HomeSideBarSocialFeed()
        {
            var Social = context.SocialFeed.ToList();
            if (Social == null)
            {
                return RedirectToAction("Admin", "Index");
            }

            return PartialView(Social);
        }
        public ActionResult _HomeBottomSlider()
        {
            var BottomSlider = context.Blogs.Include(x => x.Categories).Include(x => x.Comments).Where(x => x.isActive == true).OrderByDescending(x => x.Id).Take(10).ToList();
            return PartialView(BottomSlider);
        }
        public ActionResult _MenuCategories()
        {
            var MenuCat = context.Categories.ToList();
            return PartialView(MenuCat);
        }
        public ActionResult _EditorsBlogs()
        {
            var Editors = context.Blogs.Include(x => x.Categories).Include(x => x.Comments).Where(x => x.isEditorschoice == true && x.isActive == true).ToList();

            return PartialView(Editors);
        }
        public ActionResult _CategoryHeader(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            var catname = context.Categories.Where(x => x.Id == id).FirstOrDefault();
            return PartialView(catname);
        }
        public ActionResult _RelatedBlogs(int? id)
        {
            Random rand = new Random();
            int toSkip = rand.Next(0, context.Blogs.Count());
            var Related = context.Blogs.Include(p => p.Categories).Include(x => x.Comments).OrderBy(x => x.Id).Skip(toSkip).Where(x => x.isActive == true && x.CategoriesId == x.Categories.Id).Take(2).ToList();
            return PartialView(Related);
        }
        public ActionResult _Comments(int? id)
        {
            var comments = context.Comments.Include(x => x.User).Include(x => x.Blog).Where(x => x.BlogId == id && x.isActive == true).ToList();
            return PartialView(comments);
        }
        public ActionResult _CommentWrite()
        {
            ViewBag.BlogId = new SelectList(context.Blogs, "Id", "Header");
            ViewBag.UsersId = new SelectList(context.Users, "Id", "NameSurName");
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _CommentWrite([Bind(Include = "Id,Comment,Date,isActive,UsersId,BlogId")] Comments comments)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (ModelState.IsValid)
            {
                comments.ipAdres = ip;
                context.Comments.Add(comments);
                context.SaveChanges();
                return RedirectToAction("Detail/" + Session["BlogId"] + "", "Home");
            }
            ViewBag.BlogId = new SelectList(context.Blogs, "Id", "Header", comments.BlogId);
            ViewBag.UsersId = new SelectList(context.Users, "Id", "NameSurName", comments.UsersId);
            return PartialView(comments);
        }
        public ActionResult _BlogLike(int? id)
        {
            Blogs blog = context.Blogs.Find(id);
            blog.LikeCount++;
            context.SaveChanges();
            return RedirectToAction("Detail/" + Session["BlogId"] + "", "Home");
        }
        public ActionResult _VisitorCount()
        {
            Settings set = context.Settings.FirstOrDefault();

            if (set != null)
            {
                set.VisitorCount++;

            }
            context.SaveChanges();
            return PartialView(set);
        }
        public ActionResult _Footer()
        {

            return PartialView(context.Writers.FirstOrDefault());
        }
        public ActionResult _ContactHeader()
        {
            return PartialView(context.Writers.FirstOrDefault());

        }
        public ActionResult _Logo()
        {
            return PartialView(context.Settings.FirstOrDefault());
        }

    }
}