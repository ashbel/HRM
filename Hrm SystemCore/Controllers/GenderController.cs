using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class GenderController : Controller
    {
        private readonly HRMEntities db;

        public GenderController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /Gender/

        public ActionResult Index()
        {
            return View(db.tblGenders.ToList());
        }

        //
        // GET: /Gender/Details/5

        public ActionResult Details(int id = 0)
        {
            tblGender tblgender = db.tblGenders.Find(id);
            if (tblgender == null)
            {
                return NotFound();
            }
            return View(tblgender);
        }

        //
        // GET: /Gender/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gender/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblGender tblgender)
        {
            if (ModelState.IsValid)
            {
                db.tblGenders.Add(tblgender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblgender);
        }

        //
        // GET: /Gender/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblGender tblgender = db.tblGenders.Find(id);
            if (tblgender == null)
            {
                return NotFound();
            }
            return View(tblgender);
        }

        //
        // POST: /Gender/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblGender tblgender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblgender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblgender);
        }

        //
        // GET: /Gender/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblGender tblgender = db.tblGenders.Find(id);
            if (tblgender == null)
            {
                return NotFound();
            }
            return View(tblgender);
        }

        //
        // POST: /Gender/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGender tblgender = db.tblGenders.Find(id);
            db.tblGenders.Remove(tblgender);
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