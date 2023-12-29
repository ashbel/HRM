using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsersController : Controller
    {
        private readonly HRMEntities db;

        public UsersController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /Users/

        public ActionResult Index()
        {
            var tblusers = db.tblUsers.Include(t => t.tblEmployee);
            return View(tblusers.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            tblUser tbluser = db.tblUsers.Find(id);
            if (tbluser == null)
            {
                return NotFound();
            }
            return View(tbluser);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name");
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblUser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tbluser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tbluser.emp_id);
            return View(tbluser);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblUser tbluser = db.tblUsers.Find(id);
            if (tbluser == null)
            {
                return NotFound();
            }
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tbluser.emp_id);
            return View(tbluser);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblUser tbluser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbluser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tbluser.emp_id);
            return View(tbluser);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblUser tbluser = db.tblUsers.Find(id);
            if (tbluser == null)
            {
                return NotFound();
            }
            return View(tbluser);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUser tbluser = db.tblUsers.Find(id);
            db.tblUsers.Remove(tbluser);
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