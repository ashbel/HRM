using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;

namespace Hrm_System.Controllers
{
    public class TrainingController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Training
        public ActionResult Index()
        {
            var tblTrainings = db.tblTrainings.Include(t => t.tblCours).Include(t => t.tblEmployee);
            return View(tblTrainings.ToList());
        }

        // GET: Training/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTraining tblTraining = db.tblTrainings.Find(id);
            if (tblTraining == null)
            {
                return HttpNotFound();
            }
            return View(tblTraining);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm");
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name");
            return View();
        }

        // POST: Training/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tr_id,emp_id,course_id,tr_sdate,tr_edate,tr_status,tr_score,tr_comments")] tblTraining tblTraining)
        {
            if (ModelState.IsValid)
            {
                db.tblTrainings.Add(tblTraining);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm", tblTraining.course_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblTraining.emp_id);
            return View(tblTraining);
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTraining tblTraining = db.tblTrainings.Find(id);
            if (tblTraining == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm", tblTraining.course_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblTraining.emp_id);
            return View(tblTraining);
        }

        // POST: Training/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tr_id,emp_id,course_id,tr_sdate,tr_edate,tr_status,tr_score,tr_comments")] tblTraining tblTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTraining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm", tblTraining.course_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblTraining.emp_id);
            return View(tblTraining);
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTraining tblTraining = db.tblTrainings.Find(id);
            if (tblTraining == null)
            {
                return HttpNotFound();
            }
            return View(tblTraining);
        }

        // POST: Training/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTraining tblTraining = db.tblTrainings.Find(id);
            db.tblTrainings.Remove(tblTraining);
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
