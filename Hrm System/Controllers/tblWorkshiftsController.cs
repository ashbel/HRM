using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;

namespace Hrm_System.Controllers
{
    [CustomAuthorize]
    public class tblWorkshiftsController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: tblWorkshifts
        public ActionResult Index()
        {
            return View(db.tblWorkshifts.ToList());
        }

        // GET: tblWorkshifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWorkshift tblWorkshift = db.tblWorkshifts.Find(id);
            if (tblWorkshift == null)
            {
                return HttpNotFound();
            }
            return View(tblWorkshift);
        }

        // GET: tblWorkshifts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblWorkshifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wkshft_id,wkshft_title,wkshft_hrs,wkshft_from,wkshft_to,wkshft_lunch_from,wkshft_lunch_to,wkshft_brk_from,wkshft_brk_to,wkshft_xtrabrk_from,wkshft_xtrabrk_to,wkshft_notes,inputter,create_date")] tblWorkshift tblWorkshift)
        {
            tblUser tblusers = db.tblUsers.FirstOrDefault(c => c.user_name == User.Identity.Name);
            if (ModelState.IsValid)
            {
                tblWorkshift.inputter = (int)tblusers.emp_id;
                tblWorkshift.create_date = DateTime.Now;
                db.tblWorkshifts.Add(tblWorkshift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblWorkshift);
        }

        // GET: tblWorkshifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWorkshift tblWorkshift = db.tblWorkshifts.Find(id);
            if (tblWorkshift == null)
            {
                return HttpNotFound();
            }
            return View(tblWorkshift);
        }

        // POST: tblWorkshifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wkshft_id,wkshft_title,wkshft_hrs,wkshft_from,wkshft_to,wkshft_lunch_from,wkshft_lunch_to,wkshft_brk_from,wkshft_brk_to,wkshft_xtrabrk_from,wkshft_xtrabrk_to,wkshft_notes,inputter,create_date")] tblWorkshift tblWorkshift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblWorkshift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblWorkshift);
        }

        // GET: tblWorkshifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWorkshift tblWorkshift = db.tblWorkshifts.Find(id);
            if (tblWorkshift == null)
            {
                return HttpNotFound();
            }
            return View(tblWorkshift);
        }

        // POST: tblWorkshifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWorkshift tblWorkshift = db.tblWorkshifts.Find(id);
            db.tblWorkshifts.Remove(tblWorkshift);
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
