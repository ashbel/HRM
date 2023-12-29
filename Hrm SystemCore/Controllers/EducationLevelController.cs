using System.Net;
using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class EducationLevelController : Controller
    {
        private readonly HRMEntities db;

        public EducationLevelController(HRMEntities db)
        {
            this.db = db;
        }

        // GET: EducationLevel
        public ActionResult Index()
        {
            return View(db.tblEduLevels.ToList());
        }

        // GET: EducationLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblEduLevel tblEduLevel = db.tblEduLevels.Find(id);
            if (tblEduLevel == null)
            {
                return NotFound();
            }
            return View(tblEduLevel);
        }

        // GET: EducationLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblEduLevel tblEduLevel)
        {
            if (ModelState.IsValid)
            {
                db.tblEduLevels.Add(tblEduLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEduLevel);
        }

        // GET: EducationLevel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblEduLevel tblEduLevel = db.tblEduLevels.Find(id);
            if (tblEduLevel == null)
            {
                return NotFound();
            }
            return View(tblEduLevel);
        }

        // POST: EducationLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblEduLevel tblEduLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEduLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEduLevel);
        }

        // GET: EducationLevel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblEduLevel tblEduLevel = db.tblEduLevels.Find(id);
            if (tblEduLevel == null)
            {
                return NotFound();
            }
            return View(tblEduLevel);
        }

        // POST: EducationLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEduLevel tblEduLevel = db.tblEduLevels.Find(id);
            db.tblEduLevels.Remove(tblEduLevel);
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
