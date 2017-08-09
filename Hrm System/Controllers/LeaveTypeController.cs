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
    [CustomAuthorize]
    public class LeaveTypeController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /LeaveType/

        public ActionResult Index()
        {
            return View(db.tblLvTypes.ToList());
        }

        //
        // GET: /LeaveType/Details/5

        public ActionResult Details(int id = 0)
        {
            tblLvType tbllvtype = db.tblLvTypes.Find(id);
            if (tbllvtype == null)
            {
                return HttpNotFound();
            }
            return View(tbllvtype);
        }

        //
        // GET: /LeaveType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LeaveType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblLvType tbllvtype)
        {
            if (ModelState.IsValid)
            {
                db.tblLvTypes.Add(tbllvtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbllvtype);
        }

        //
        // GET: /LeaveType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblLvType tbllvtype = db.tblLvTypes.Find(id);
            if (tbllvtype == null)
            {
                return HttpNotFound();
            }
            return View(tbllvtype);
        }

        //
        // POST: /LeaveType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblLvType tbllvtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbllvtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbllvtype);
        }

        //
        // GET: /LeaveType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblLvType tbllvtype = db.tblLvTypes.Find(id);
            if (tbllvtype == null)
            {
                return HttpNotFound();
            }
            return View(tbllvtype);
        }

        //
        // POST: /LeaveType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLvType tbllvtype = db.tblLvTypes.Find(id);
            db.tblLvTypes.Remove(tbllvtype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult AssignLeave()
        {
            var leaveType =  from t in db.tblLvTypes select t;
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            DateTime lastDay = new DateTime(year, 12, 31);
            foreach (var u in leaveType.ToList())
            {
                var emp_id = from emp in db.tblEmployees select emp;

                foreach (var em in emp_id.ToList())
                {
                    var leave = from i in db.tblLeaves where i.emp_id == em.emp_id && i.lvtyp_id == u.lvtyp_id && i.lv_period == lastDay select i;
                    if (leave.Count() == 0)
                    {
                        tblLeave tblleave = new tblLeave();
                        tblleave.emp_id = em.emp_id;
                        tblleave.lv_bal = u.lvtyp_num;
                        tblleave.lvtyp_id = u.lvtyp_id;
                        tblleave.lv_period = lastDay;
                        db.tblLeaves.Add(tblleave);
                        db.SaveChanges();

                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}