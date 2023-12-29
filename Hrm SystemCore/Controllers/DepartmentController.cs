using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly HRMEntities db;

        public DepartmentController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /Department/

        public ActionResult Index()
        {
            return View(db.tblDepartments.ToList());
        }

        //
        // GET: /Department/Details/5

        public ActionResult Details(int id = 0)
        {
            tblDepartment tbldepartment = db.tblDepartments.Find(id);
            if (tbldepartment == null)
            {
                return NotFound();
            }
            return View(tbldepartment);
        }

        //
        // GET: /Department/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Department/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblDepartment tbldepartment)
        {
            if (ModelState.IsValid)
            {
                db.tblDepartments.Add(tbldepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbldepartment);
        }

        //
        // GET: /Department/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblDepartment tbldepartment = db.tblDepartments.Find(id);
            if (tbldepartment == null)
            {
                return NotFound();
            }
            return View(tbldepartment);
        }

        //
        // POST: /Department/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblDepartment tbldepartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbldepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbldepartment);
        }

        //
        // GET: /Department/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblDepartment tbldepartment = db.tblDepartments.Find(id);
            if (tbldepartment == null)
            {
                return NotFound();
            }
            return View(tbldepartment);
        }

        //
        // POST: /Department/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDepartment tbldepartment = db.tblDepartments.Find(id);
            db.tblDepartments.Remove(tbldepartment);
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