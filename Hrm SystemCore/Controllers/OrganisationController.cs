using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrganisationController : Controller
    {
        private readonly HRMEntities db;

        public OrganisationController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /Organisation/

        public ActionResult Index()
        {
            return View(db.tblOrganisations.ToList());
        }

        //
        // GET: /Organisation/Details/5

        public ActionResult Details(int id = 0)
        {
            tblOrganisation tblorganisation = db.tblOrganisations.Find(id);
            if (tblorganisation == null)
            {
                return NotFound();
            }
            return View(tblorganisation);
        }

        //
        // GET: /Organisation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Organisation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblOrganisation tblorganisation)
        {
            if (ModelState.IsValid)
            {
                db.tblOrganisations.Add(tblorganisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblorganisation);
        }

        //
        // GET: /Organisation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblOrganisation tblorganisation = db.tblOrganisations.Find(id);
            if (tblorganisation == null)
            {
                return NotFound();
            }
            return View(tblorganisation);
        }

        //
        // POST: /Organisation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblOrganisation tblorganisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblorganisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblorganisation);
        }

        //
        // GET: /Organisation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblOrganisation tblorganisation = db.tblOrganisations.Find(id);
            if (tblorganisation == null)
            {
                return NotFound();
            }
            return View(tblorganisation);
        }

        //
        // POST: /Organisation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOrganisation tblorganisation = db.tblOrganisations.Find(id);
            db.tblOrganisations.Remove(tblorganisation);
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