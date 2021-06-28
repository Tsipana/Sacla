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
    public class PaperController : Controller
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-57E53CS;Initial Catalog=StudentSumSec2; Integrated Security = True");
        private StudentSumSec2Entities db = new StudentSumSec2Entities();

        public ActionResult Home()
        {
            return View();
        }

        // GET: Paper
        public ActionResult Papers()
        {
            var papers = db.Papers.Include(p => p.topic);
            return View(papers.ToList());
        }

        public ActionResult MyPapers(Paper paper)
        {
            string user2 = Convert.ToString(Session["Username2"]);
            var papers = db.Papers.Include(p => p.topic);
            var paper2 = papers.Where(x => x.PaperAuthor.Contains(user2));
            return View(paper2.OrderByDescending(p => p.PaperId).ToList());
            
        }

        // GET: Paper/Create
        public ActionResult Submit()
        {
            ViewBag.TopicId = new SelectList(db.topics, "TopicId", "TopicName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperDateSubmitted,TopicId")] Paper paper)
        {
            Session["id"] = paper.PaperId;
            paper.PaperDateSubmitted = DateTime.Now;
            paper.PaperAuthor = Session["Username3"].ToString();
            if (ModelState.IsValid)
            {
                db.Papers.Add(paper);
                db.SaveChanges();
                return RedirectToAction("MyPapers");
            }

            ViewBag.TopicId = new SelectList(db.topics, "TopicId", "TopicName", paper.TopicId);
            return View(paper);
        }

        // GET: Paper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicId = new SelectList(db.topics, "TopicId", "TopicName", paper.TopicId);
            return View(paper);
        }

        // POST: Paper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperDateSubmitted,TopicId")] Paper paper)
        {
            paper.PaperDateSubmitted = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(paper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyPapers");
            }
            ViewBag.TopicId = new SelectList(db.topics, "TopicId", "TopicName", paper.TopicId);
            return View(paper);
        }

        // GET: Paper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Paper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string confirm_value)
        {
            if(confirm_value == "Yes")
            {
                Paper paper = db.Papers.Find(id);
                db.Papers.Remove(paper);
                db.SaveChanges();
                ViewBag.Message = "Your value delete successfully";
                return RedirectToAction("MyPapers");
            }
            else
            {
                ViewBag.Message = "You cancel the transaction";
                return RedirectToAction("MyPapers");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }
    }
}
