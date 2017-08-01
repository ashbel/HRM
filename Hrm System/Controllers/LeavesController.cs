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
    public class LeavesController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /Leaves/

        public ActionResult Index()
        {
            var tblleaves = db.tblLeaves.Include(t => t.tblEmployee).Include(t => t.tblLvType);
            return View(tblleaves.ToList());
        }

        //
        // GET: /Leaves/Details/5

        public ActionResult Details(int id = 0)
        {
            tblLeave tblleave = db.tblLeaves.Find(id);
            if (tblleave == null)
            {
                return HttpNotFound();
            }
            return View(tblleave);
        }

        //
        // GET: /Leaves/Create

        public ActionResult Create()
        {
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name");
            ViewBag.lvtyp_id = new SelectList(db.tblLvTypes, "lvtyp_id", "lvtyp_title");
            return View();
        }

        //
        // POST: /Leaves/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblLeave tblleave)
        {
            if (ModelState.IsValid)
            {
                db.tblLeaves.Add(tblleave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblleave.emp_id);
            ViewBag.lvtyp_id = new SelectList(db.tblLvTypes, "lvtyp_id", "lvtyp_title", tblleave.lvtyp_id);
            return View(tblleave);
        }

        //
        // GET: /Leaves/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblLeave tblleave = db.tblLeaves.Find(id);
            if (tblleave == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblleave.emp_id);
            ViewBag.lvtyp_id = new SelectList(db.tblLvTypes, "lvtyp_id", "lvtyp_title", tblleave.lvtyp_id);
            return View(tblleave);
        }

        //
        // POST: /Leaves/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblLeave tblleave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblleave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblleave.emp_id);
            ViewBag.lvtyp_id = new SelectList(db.tblLvTypes, "lvtyp_id", "lvtyp_title", tblleave.lvtyp_id);
            return View(tblleave);
        }

        //
        // GET: /Leaves/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblLeave tblleave = db.tblLeaves.Find(id);
            if (tblleave == null)
            {
                return HttpNotFound();
            }
            return View(tblleave);
        }

        //
        // POST: /Leaves/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLeave tblleave = db.tblLeaves.Find(id);
            db.tblLeaves.Remove(tblleave);
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