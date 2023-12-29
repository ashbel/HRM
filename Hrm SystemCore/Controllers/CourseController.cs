using System.Net;
using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly HRMEntities db;

        public CourseController(HRMEntities db)
        {
            this.db = db;
        }

        // GET: Course
        public async Task<ActionResult> IndexAsync(int page=1)
        {
            var tblCourses = await db.tblCourses.Include(t => t.tblCourseType).ToListAsync();
            return View(tblCourses.OrderBy(c => c.course_id));
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return NotFound();
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
        public ActionResult Create(tblCours tblCours)
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
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return NotFound();
            }
            ViewBag.type_id = new SelectList(db.tblCourseTypes, "type_id", "type_name", tblCours.type_id);
            return View(tblCours);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblCours tblCours)
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
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return NotFound();
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
