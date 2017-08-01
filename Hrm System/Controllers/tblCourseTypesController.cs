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
    public class tblCourseTypesController : Controller
    {
        private HRMEntities db = new HRMEntities();

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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourseType tblCourseType = db.tblCourseTypes.Find(id);
            if (tblCourseType == null)
            {
                return HttpNotFound();
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
        public ActionResult Create([Bind(Include = "type_id,type_name,typ_descr")] tblCourseType tblCourseType)
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourseType tblCourseType = db.tblCourseTypes.Find(id);
            if (tblCourseType == null)
            {
                return HttpNotFound();
            }
            return View(tblCourseType);
        }

        // POST: tblCourseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "type_id,type_name,typ_descr")] tblCourseType tblCourseType)
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourseType tblCourseType = db.tblCourseTypes.Find(id);
            if (tblCourseType == null)
            {
                return HttpNotFound();
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
