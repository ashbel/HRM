using System.Net;
using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class ContractStatesController : Controller
    {
        private readonly HRMEntities db;

        public ContractStatesController(HRMEntities db)
        {
            this.db = db;
        }

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
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblContractState tblContractState = db.tblContractStates.Find(id);
            if (tblContractState == null)
            {
                return NotFound();
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
        public ActionResult Create(tblContractState tblContractState)
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
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblContractState tblContractState = db.tblContractStates.Find(id);
            if (tblContractState == null)
            {
                return NotFound();
            }
            return View(tblContractState);
        }

        // POST: ContractStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblContractState tblContractState)
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
                return new StatusCodeResult((int) HttpStatusCode.BadRequest);
            }
            tblContractState tblContractState = db.tblContractStates.Find(id);
            if (tblContractState == null)
            {
                return NotFound();
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
