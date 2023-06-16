using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BootCampDB_App.Models;

namespace BootCampDB_App.Controllers
{
    public class InterviewersController : Controller
    {
        private BootCampDatabaseEntities db = new BootCampDatabaseEntities();

        // GET: Interviewers
        public ActionResult Index()
        {
            return View(db.Interviewers.ToList());
        }

        // GET: Interviewers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interviewer interviewer = db.Interviewers.Find(id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        // GET: Interviewers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interviewers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DasId,Interviewer_Name,Password,Phone_no,GCM_Level,Manager_Id")] Interviewer interviewer)
        {
            if (ModelState.IsValid)
            {
                db.Interviewers.Add(interviewer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interviewer);
        }

        // GET: Interviewers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interviewer interviewer = db.Interviewers.Find(id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        // POST: Interviewers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DasId,Interviewer_Name,Password,Phone_no,GCM_Level,Manager_Id")] Interviewer interviewer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interviewer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interviewer);
        }

        // GET: Interviewers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interviewer interviewer = db.Interviewers.Find(id);
            if (interviewer == null)
            {
                return HttpNotFound();
            }
            return View(interviewer);
        }

        // POST: Interviewers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Interviewer interviewer = db.Interviewers.Find(id);
            db.Interviewers.Remove(interviewer);
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
