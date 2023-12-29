using System.Net;
using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class PerfomanceController : Controller
    {
        private readonly HRMEntities db;

        public PerfomanceController(HRMEntities db)
        {
            this.db = db;
        }

        // GET: Perfomance
        public ActionResult Index()
        {
            var tblKPIs = db.tblKPIs.Include(t => t.tblEmployee);
            return View(tblKPIs.ToList());
        }

        // GET: Perfomance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblKPI tblKPI = db.tblKPIs.Find(id);
            if (tblKPI == null)
            {
                return NotFound();
            }
            return View(tblKPI);
        }

        // GET: Perfomance/Create
        public ActionResult Create()
        {
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name");
            return View();
        }

        // POST: Perfomance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblKPI tblKPI)
        {
            if (ModelState.IsValid)
            {
                db.tblKPIs.Add(tblKPI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblKPI.emp_id);
            return View(tblKPI);
        }

        // GET: Perfomance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblKPI tblKPI = db.tblKPIs.Find(id);
            if (tblKPI == null)
            {
                return NotFound();
            }
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblKPI.emp_id);
            return View(tblKPI);
        }

        // POST: Perfomance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblKPI tblKPI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblKPI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblKPI.emp_id);
            return View(tblKPI);
        }

        // GET: Perfomance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblKPI tblKPI = db.tblKPIs.Find(id);
            if (tblKPI == null)
            {
                return NotFound();
            }
            return View(tblKPI);
        }

        // POST: Perfomance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblKPI tblKPI = db.tblKPIs.Find(id);
            db.tblKPIs.Remove(tblKPI);
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
