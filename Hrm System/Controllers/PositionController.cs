using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;

namespace Hrm_System.Controllers
{
    public class PositionController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /Position/

        public ActionResult Index()
        {
            var tblpositions = db.tblPositions.Include(t => t.tblJobLevel).Include(c=>c.tblDepartment);
            return View(tblpositions.ToList());
        }

        //
        // GET: /Position/Details/5

        public ActionResult Details(int id = 0)
        {
            tblPosition tblposition = db.tblPositions.Find(id);
            if (tblposition == null)
            {
                return HttpNotFound();
            }
            return View(tblposition);
        }

        //
        // GET: /Position/Create

        public ActionResult Create()
        {
            ViewBag.lvl_id = new SelectList(db.tblJobLevels, "lvl_id", "lvl_title");
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name");
            return View();
        }

        //
        // POST: /Position/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblPosition tblposition)
        {
            if (ModelState.IsValid)
            {
                db.tblPositions.Add(tblposition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lvl_id = new SelectList(db.tblJobLevels, "lvl_id", "lvl_title", tblposition.lvl_id);
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name",tblposition.dp_id);
            return View(tblposition);
        }

        //
        // GET: /Position/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblPosition tblposition = db.tblPositions.Find(id);
            if (tblposition == null)
            {
                return HttpNotFound();
            }
            ViewBag.lvl_id = new SelectList(db.tblJobLevels, "lvl_id", "lvl_title", tblposition.lvl_id);
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblposition.dp_id);
            return View(tblposition);
        }

        //
        // POST: /Position/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblPosition tblposition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblposition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lvl_id = new SelectList(db.tblJobLevels, "lvl_id", "lvl_title", tblposition.lvl_id);
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblposition.dp_id);
            return View(tblposition);
        }

        //
        // GET: /Position/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblPosition tblposition = db.tblPositions.Find(id);
            if (tblposition == null)
            {
                return HttpNotFound();
            }
            return View(tblposition);
        }

        //
        // POST: /Position/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPosition tblposition = db.tblPositions.Find(id);
            db.tblPositions.Remove(tblposition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}