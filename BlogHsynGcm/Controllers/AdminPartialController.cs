using BlogHsynGcm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace BlogHsynGcm.Controllers
{
    [Authorize]
    public class AdminPartialController : Controller
    {
        DataContext context = new DataContext();
        public ActionResult _LoginUser(int? id)
        {
            var LoginUser = context.Writers.Where(x => x.Id == id).FirstOrDefault();
            return View(LoginUser);
        }
        public ActionResult _LeftSideBar()
        {
            return PartialView();
        }
        public ActionResult _RightSideBar()
        {

            return PartialView(context.Users.ToList());
        }
        public ActionResult _AdminMessages()
        {
            return PartialView(context.Messages.OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult _HomeNotification()
        {
            return PartialView(context.Comments.Include(x=>x.User).Where(x=>x.isRead==false).OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult _SideBarAdminUser()
        {
            return PartialView(context.Writers.FirstOrDefault());
        }




    }
}