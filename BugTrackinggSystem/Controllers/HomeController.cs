using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

using BugTrackinggSystem.Models;


namespace BugTrackinggSystem.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(tblLogin model, string returnUrl)
        {
            BugTrackingSystemEntities db = new BugTrackingSystemEntities();
            var dataItem = db.tblLogins.Where(x => x.Username == model.Username && x.Password == model.Password).First();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Username, false);

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                   && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {

                    return RedirectToAction("Index");
                }

            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View();

            }

           
        }
    }
}