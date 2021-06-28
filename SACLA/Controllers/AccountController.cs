using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SACLA.Models;

namespace SACLA.Controllers
{
    public class AccountController : Controller
    {
        private StudentSumSec2Entities db = new StudentSumSec2Entities();

        public ActionResult Home()
        {
            return View();
        }
        // GET: Account
        public ActionResult Login(login login)
        {  
            var user = db.logins.Where(x => x.Username == login.Username && x.Password == login.Password).Count();
            if(login.Username == "admin")
            {
                if (user > 0)
                {
                    TempData["Username"] = login.Username;
                    Session["Username"] = login.Username;
                    return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "Home", Action = "Index", id = UrlParameter.Optional }));
                }
                else
                {
                    return View(login);
                }
            }
            else
            {
                if (user > 0)
                {
                    Session["Username"] = login.Username;
                    Session["Username2"] = login.Username;
                    Session["Username3"] = login.Username;
                    return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "Home", Action = "Index", id = UrlParameter.Optional }));
                }
                else
                {
                    return View(login);
                }
            }
        }
    }
}