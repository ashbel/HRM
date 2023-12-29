using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class MaritalController : Controller
    {
        private readonly HRMEntities db;

        public MaritalController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /Marital/

        public ActionResult Index()
        {
            return View(db.tblMaritals.ToList());
        }

        //
        // GET: /Marital/Details/5

        public ActionResult Details(int id = 0)
        {
            tblMarital tblmarital = db.tblMaritals.Find(id);
            if (tblmarital == null)
            {
                return NotFound();
            }
            return View(tblmarital);
        }

        //
        // GET: /Marital/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Marital/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblMarital tblmarital)
        {
            if (ModelState.IsValid)
            {
                db.tblMaritals.Add(tblmarital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblmarital);
        }

        //
        // GET: /Marital/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblMarital tblmarital = db.tblMaritals.Find(id);
            if (tblmarital == null)
            {
                return NotFound();
            }
            return View(tblmarital);
        }

        //
        // POST: /Marital/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblMarital tblmarital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblmarital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblmarital);
        }

        //
        // GET: /Marital/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblMarital tblmarital = db.tblMaritals.Find(id);
            if (tblmarital == null)
            {
                return NotFound();
            }
            return View(tblmarital);
        }

        //
        // POST: /Marital/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMarital tblmarital = db.tblMaritals.Find(id);
            db.tblMaritals.Remove(tblmarital);
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