using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;
using System.Collections;

namespace Hrm_System.Controllers
{
    [CustomAuthorize]
    public class LeavesController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /Leaves/

        public ActionResult Index()
        {
            List<String[]> p = new List<String[]>();
            ArrayList types = new ArrayList();
           
            var tblleaves = db.tblLeaves.Include(t => t.tblEmployee).Include(t => t.tblLvType);
            var leavetypes = db.tblLvTypes;
           
            foreach(var item in leavetypes)
            {
                types.Add(item.lvtyp_title);
            }

            var employees = db.tblEmployees;
            foreach (var emp in employees)
            {
                ArrayList add = new ArrayList();
                String employee = emp.emp_name+" "+emp.emp_lname;
                String date = "";
                Decimal bal = 0;
                var leaves = db.tblLeaves.Where(c => c.emp_id==emp.emp_id);
                foreach (var item in leaves)
                {
                    date = "," + item.lv_period.Value.Year;
                    add.Add(item.tblLvType.lvtyp_title);
                    foreach (var y in types)
                    {
                            if (y.ToString() == item.tblLvType.lvtyp_title)
                            {
                                bal = item.lv_bal ?? 0;
                                employee = employee + "," + bal;
                            }
                    }

                }
                foreach (var y in types)
                {
                    if (add.Contains(y.ToString())) {   }
                    else
                    {
                        bal = 0;
                        employee = employee + "," + bal;
                    }
                }
                if (String.IsNullOrEmpty(date)) { date = "," + DateTime.Now.Year; }
                employee = employee + date;
                String[] emp_array = employee.Split(',');
                p.Add(emp_array);
            }
            var leave_groups = db.tblLeaves.GroupBy(c=>c.tblLvType.lvtyp_title);
            var leave_list = db.LeaveList();
            ViewBag.LeaveGroup = leavetypes;
            ViewBag.LeaveTypes = p;
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