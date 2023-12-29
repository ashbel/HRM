using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class JobLevelController : Controller
    {
        private readonly HRMEntities db;

        public JobLevelController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /JobLevel/

        public ActionResult Index()
        {
            return View(db.tblJobLevels.ToList());
        }

        //
        // GET: /JobLevel/Details/5

        public ActionResult Details(int id = 0)
        {
            tblJobLevel tbljoblevel = db.tblJobLevels.Find(id);
            if (tbljoblevel == null)
            {
                return NotFound();
            }
            return View(tbljoblevel);
        }

        //
        // GET: /JobLevel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /JobLevel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblJobLevel tbljoblevel)
        {
            if (ModelState.IsValid)
            {
                db.tblJobLevels.Add(tbljoblevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbljoblevel);
        }

        //
        // GET: /JobLevel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblJobLevel tbljoblevel = db.tblJobLevels.Find(id);
            if (tbljoblevel == null)
            {
                return NotFound();
            }
            return View(tbljoblevel);
        }

        //
        // POST: /JobLevel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblJobLevel tbljoblevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbljoblevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbljoblevel);
        }

        //
        // GET: /JobLevel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblJobLevel tbljoblevel = db.tblJobLevels.Find(id);
            if (tbljoblevel == null)
            {
                return NotFound();
            }
            return View(tbljoblevel);
        }

        //
        // POST: /JobLevel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblJobLevel tbljoblevel = db.tblJobLevels.Find(id);
            db.tblJobLevels.Remove(tbljoblevel);
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