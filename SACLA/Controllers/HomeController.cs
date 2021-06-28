using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SACLA.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace SACLA.Controllers
{
 
    public class HomeController : Controller
    {
        private StudentSumSec2Entities db = new StudentSumSec2Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Papers(Paper paper)
        {
            var papers = db.Papers.Include(p => p.topic);
            return View(papers.ToList());
        }

        public ActionResult News()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}