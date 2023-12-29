using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        private readonly HRMEntities db;

        public CityController(HRMEntities db)
        {
            this.db = db;
        }

        //
        // GET: /City/

        public ActionResult Index()
        {
            var tblcities = db.tblCities.Include(t => t.tblProvince);
            return View(tblcities.ToList());
        }

        //
        // GET: /City/Details/5

        public ActionResult Details(int id = 0)
        {
            tblCity tblcity = db.tblCities.Find(id);
            if (tblcity == null)
            {
                return NotFound();
            }
            return View(tblcity);
        }

        //
        // GET: /City/Create

        public ActionResult Create()
        {
            ViewBag.prov_id = new SelectList(db.tblProvinces, "prov_id", "prov_name");
            return View();
        }

        //
        // POST: /City/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblCity tblcity)
        {
            if (ModelState.IsValid)
            {
                db.tblCities.Add(tblcity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.prov_id = new SelectList(db.tblProvinces, "prov_id", "prov_name", tblcity.prov_id);
            return View(tblcity);
        }

        //
        // GET: /City/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblCity tblcity = db.tblCities.Find(id);
            if (tblcity == null)
            {
                return NotFound();
            }
            ViewBag.prov_id = new SelectList(db.tblProvinces, "prov_id", "prov_name", tblcity.prov_id);
            return View(tblcity);
        }

        //
        // POST: /City/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblCity tblcity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.prov_id = new SelectList(db.tblProvinces, "prov_id", "prov_name", tblcity.prov_id);
            return View(tblcity);
        }

        //
        // GET: /City/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblCity tblcity = db.tblCities.Find(id);
            if (tblcity == null)
            {
                return NotFound();
            }
            return View(tblcity);
        }

        //
        // POST: /City/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCity tblcity = db.tblCities.Find(id);
            db.tblCities.Remove(tblcity);
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