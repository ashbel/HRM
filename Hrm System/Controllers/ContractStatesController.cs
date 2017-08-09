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
    public class ContractStatesController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: ContractStates
        public ActionResult Index()
        {
            return View(db.tblContractStates.ToList());
        }

        // GET: ContractStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContractState tblContractState = db.tblContractStates.Find(id);
            if (tblContractState == null)
            {
                return HttpNotFound();
            }
            return View(tblContractState);
        }

        // GET: ContractStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cntrct_st_id,cntrct_state,cntrct_st_desc")] tblContractState tblContractState)
        {
            if (ModelState.IsValid)
            {
                db.tblContractStates.Add(tblContractState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblContractState);
        }

        // GET: ContractStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContractState tblContractState = db.tblContractStates.Find(id);
            if (tblContractState == null)
            {
                return HttpNotFound();
            }
            return View(tblContractState);
        }

        // POST: ContractStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cntrct_st_id,cntrct_state,cntrct_st_desc")] tblContractState tblContractState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblContractState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblContractState);
        }

        // GET: ContractStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContractState tblContractState = db.tblContractStates.Find(id);
            if (tblContractState == null)
            {
                return HttpNotFound();
            }
            return View(tblContractState);
        }

        // POST: ContractStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblContractState tblContractState = db.tblContractStates.Find(id);
            db.tblContractStates.Remove(tblContractState);
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
