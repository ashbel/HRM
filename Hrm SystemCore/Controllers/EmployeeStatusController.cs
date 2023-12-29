using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class EmployeeStatusController : Controller
    {
        private readonly HRMEntities db;

        public EmployeeStatusController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /EmployeeStatus/

        public ActionResult Index()
        {
            return View(db.tblEmployeeStatus.ToList());
        }

        //
        // GET: /EmployeeStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            tblEmployeeStatu tblemployeestatu = db.tblEmployeeStatus.Find(id);
            if (tblemployeestatu == null)
            {
                return NotFound();
            }
            return View(tblemployeestatu);
        }

        //
        // GET: /EmployeeStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EmployeeStatus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblEmployeeStatu tblemployeestatu)
        {
            if (ModelState.IsValid)
            {
                db.tblEmployeeStatus.Add(tblemployeestatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblemployeestatu);
        }

        //
        // GET: /EmployeeStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblEmployeeStatu tblemployeestatu = db.tblEmployeeStatus.Find(id);
            if (tblemployeestatu == null)
            {
                return NotFound();
            }
            return View(tblemployeestatu);
        }

        //
        // POST: /EmployeeStatus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblEmployeeStatu tblemployeestatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblemployeestatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblemployeestatu);
        }

        //
        // GET: /EmployeeStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblEmployeeStatu tblemployeestatu = db.tblEmployeeStatus.Find(id);
            if (tblemployeestatu == null)
            {
                return NotFound();
            }
            return View(tblemployeestatu);
        }

        //
        // POST: /EmployeeStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployeeStatu tblemployeestatu = db.tblEmployeeStatus.Find(id);
            db.tblEmployeeStatus.Remove(tblemployeestatu);
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