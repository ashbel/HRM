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
    public class EmployeeStateController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /EmployeeState/

        public ActionResult Index()
        {
            return View(db.tblEmplStatus.ToList());
        }

        //
        // GET: /EmployeeState/Details/5

        public ActionResult Details(int id = 0)
        {
            tblEmplStatu tblemplstatu = db.tblEmplStatus.Find(id);
            if (tblemplstatu == null)
            {
                return HttpNotFound();
            }
            return View(tblemplstatu);
        }

        //
        // GET: /EmployeeState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EmployeeState/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblEmplStatu tblemplstatu)
        {
            if (ModelState.IsValid)
            {
                db.tblEmplStatus.Add(tblemplstatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblemplstatu);
        }

        //
        // GET: /EmployeeState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblEmplStatu tblemplstatu = db.tblEmplStatus.Find(id);
            if (tblemplstatu == null)
            {
                return HttpNotFound();
            }
            return View(tblemplstatu);
        }

        //
        // POST: /EmployeeState/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblEmplStatu tblemplstatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblemplstatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblemplstatu);
        }

        //
        // GET: /EmployeeState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblEmplStatu tblemplstatu = db.tblEmplStatus.Find(id);
            if (tblemplstatu == null)
            {
                return HttpNotFound();
            }
            return View(tblemplstatu);
        }

        //
        // POST: /EmployeeState/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmplStatu tblemplstatu = db.tblEmplStatus.Find(id);
            db.tblEmplStatus.Remove(tblemplstatu);
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