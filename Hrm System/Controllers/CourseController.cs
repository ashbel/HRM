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
    public class CourseController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Course
        public ActionResult Index()
        {
            var tblCourses = db.tblCourses.Include(t => t.tblCourseType);
            return View(tblCourses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return HttpNotFound();
            }
            return View(tblCours);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.type_id = new SelectList(db.tblCourseTypes, "type_id", "type_name");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "course_id,course_nm,course_dur,course_descr,type_id")] tblCours tblCours)
        {
            if (ModelState.IsValid)
            {
                db.tblCourses.Add(tblCours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.type_id = new SelectList(db.tblCourseTypes, "type_id", "type_name", tblCours.type_id);
            return View(tblCours);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return HttpNotFound();
            }
            ViewBag.type_id = new SelectList(db.tblCourseTypes, "type_id", "type_name", tblCours.type_id);
            return View(tblCours);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "course_id,course_nm,course_dur,course_descr,type_id")] tblCours tblCours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.type_id = new SelectList(db.tblCourseTypes, "type_id", "type_name", tblCours.type_id);
            return View(tblCours);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return HttpNotFound();
            }
            return View(tblCours);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCours tblCours = db.tblCourses.Find(id);
            db.tblCourses.Remove(tblCours);
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
