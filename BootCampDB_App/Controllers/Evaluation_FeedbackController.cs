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
    public class Evaluation_FeedbackController : Controller
    {
        private BootCampDatabaseEntities db = new BootCampDatabaseEntities();

        // GET: Evaluation_Feedback
        public ActionResult Index()
        {
            var evaluation_Feedback = db.Evaluation_Feedback.Include(e => e.Candidate).Include(e => e.Interviewer);
            return View(evaluation_Feedback.ToList());
        }

        // GET: Evaluation_Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_Feedback evaluation_Feedback = db.Evaluation_Feedback.Find(id);
            if (evaluation_Feedback == null)
            {
                return HttpNotFound();
            }
            return View(evaluation_Feedback);
        }

        // GET: Evaluation_Feedback/Create
        public ActionResult Create()
        {
            ViewBag.Candidate_Id = new SelectList(db.Candidates, "Candidate_Id", "Candidate_Name");
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewers, "DasId", "Interviewer_Name");
            return View();
        }

        // POST: Evaluation_Feedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Eval_id,Evaluator_DasId,Candidate_Id,Date,Screening_Level,Feekback,Comments")] Evaluation_Feedback evaluation_Feedback)
        {
            if (ModelState.IsValid)
            {
                db.Evaluation_Feedback.Add(evaluation_Feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Candidate_Id = new SelectList(db.Candidates, "Candidate_Id", "Candidate_Name", evaluation_Feedback.Candidate_Id);
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewers, "DasId", "Interviewer_Name", evaluation_Feedback.Evaluator_DasId);
            return View(evaluation_Feedback);
        }

        // GET: Evaluation_Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_Feedback evaluation_Feedback = db.Evaluation_Feedback.Find(id);
            if (evaluation_Feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.Candidate_Id = new SelectList(db.Candidates, "Candidate_Id", "Candidate_Name", evaluation_Feedback.Candidate_Id);
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewers, "DasId", "Interviewer_Name", evaluation_Feedback.Evaluator_DasId);
            return View(evaluation_Feedback);
        }

        // POST: Evaluation_Feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Eval_id,Evaluator_DasId,Candidate_Id,Date,Screening_Level,Feekback,Comments")] Evaluation_Feedback evaluation_Feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation_Feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Candidate_Id = new SelectList(db.Candidates, "Candidate_Id", "Candidate_Name", evaluation_Feedback.Candidate_Id);
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewers, "DasId", "Interviewer_Name", evaluation_Feedback.Evaluator_DasId);
            return View(evaluation_Feedback);
        }

        // GET: Evaluation_Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_Feedback evaluation_Feedback = db.Evaluation_Feedback.Find(id);
            if (evaluation_Feedback == null)
            {
                return HttpNotFound();
            }
            return View(evaluation_Feedback);
        }

        // POST: Evaluation_Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluation_Feedback evaluation_Feedback = db.Evaluation_Feedback.Find(id);
            db.Evaluation_Feedback.Remove(evaluation_Feedback);
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
