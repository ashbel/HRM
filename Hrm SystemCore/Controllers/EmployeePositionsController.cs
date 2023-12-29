using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class EmployeePositionsController : Controller
    {
        private readonly HRMEntities db;

        public EmployeePositionsController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /EmployeePositions/

        public ActionResult Index()
        {
            var tblpositionhistories = db.tblPositionHistories.Include(t => t.tblBranch).Include(t => t.tblDepartment).Include(t => t.tblEmployee).Include(t => t.tblPosition);
            return View(tblpositionhistories.ToList());
        }

        //
        // GET: /EmployeePositions/Details/5

        public ActionResult Details(int id = 0)
        {
            tblPositionHistory tblpositionhistory = db.tblPositionHistories.Find(id);
            if (tblpositionhistory == null)
            {
                return NotFound();
            }
            return View(tblpositionhistory);
        }

        //
        // GET: /EmployeePositions/Create

        public ActionResult Create()
        {
            ViewBag.br_id = new SelectList(db.tblBranches, "br_id", "br_name");
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name");
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name");
            ViewBag.pos_id = new SelectList(db.tblPositions, "pos_id", "pos_title");
            return View();
        }

        //
        // POST: /EmployeePositions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblPositionHistory tblpositionhistory)
        {
            if (ModelState.IsValid)
            {
                db.tblPositionHistories.Add(tblpositionhistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.br_id = new SelectList(db.tblBranches, "br_id", "br_name", tblpositionhistory.br_id);
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblpositionhistory.dpt_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblpositionhistory.emp_id);
            ViewBag.pos_id = new SelectList(db.tblPositions, "pos_id", "pos_title", tblpositionhistory.pos_id);
            return View(tblpositionhistory);
        }

        //
        // GET: /EmployeePositions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblPositionHistory tblpositionhistory = db.tblPositionHistories.Find(id);
            if (tblpositionhistory == null)
            {
                return NotFound();
            }
            ViewBag.br_id = new SelectList(db.tblBranches, "br_id", "br_name", tblpositionhistory.br_id);
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblpositionhistory.dpt_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblpositionhistory.emp_id);
            ViewBag.pos_id = new SelectList(db.tblPositions, "pos_id", "pos_title", tblpositionhistory.pos_id);
            return View(tblpositionhistory);
        }

        //
        // POST: /EmployeePositions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblPositionHistory tblpositionhistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblpositionhistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.br_id = new SelectList(db.tblBranches, "br_id", "br_name", tblpositionhistory.br_id);
            ViewBag.dpt_id = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblpositionhistory.dpt_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblpositionhistory.emp_id);
            ViewBag.pos_id = new SelectList(db.tblPositions, "pos_id", "pos_title", tblpositionhistory.pos_id);
            return View(tblpositionhistory);
        }

        //
        // GET: /EmployeePositions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblPositionHistory tblpositionhistory = db.tblPositionHistories.Find(id);
            if (tblpositionhistory == null)
            {
                return NotFound();
            }
            return View(tblpositionhistory);
        }

        //
        // POST: /EmployeePositions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPositionHistory tblpositionhistory = db.tblPositionHistories.Find(id);
            db.tblPositionHistories.Remove(tblpositionhistory);
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