using System.Net;
using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class tblCourseTypesController : Controller
    {
        private readonly HRMEntities db;

        public tblCourseTypesController(HRMEntities db)
        {
            this.db = db;
        }

        // GET: tblCourseTypes
        public ActionResult Index()
        {
            return View(db.tblCourseTypes.ToList());
        }

        // GET: tblCourseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblCourseType tblCourseType = db.tblCourseTypes.Find(id);
            if (tblCourseType == null)
            {
                return NotFound();
            }
            return View(tblCourseType);
        }

        // GET: tblCourseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCourseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblCourseType tblCourseType)
        {
            if (ModelState.IsValid)
            {
                db.tblCourseTypes.Add(tblCourseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCourseType);
        }

        // GET: tblCourseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblCourseType tblCourseType = db.tblCourseTypes.Find(id);
            if (tblCourseType == null)
            {
                return NotFound();
            }
            return View(tblCourseType);
        }

        // POST: tblCourseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblCourseType tblCourseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCourseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCourseType);
        }

        // GET: tblCourseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblCourseType tblCourseType = db.tblCourseTypes.Find(id);
            if (tblCourseType == null)
            {
                return NotFound();
            }
            return View(tblCourseType);
        }

        // POST: tblCourseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCourseType tblCourseType = db.tblCourseTypes.Find(id);
            db.tblCourseTypes.Remove(tblCourseType);
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
