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
    public class ProvinceController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /Province/

        public ActionResult Index()
        {
            return View(db.tblProvinces.ToList());
        }

        //
        // GET: /Province/Details/5

        public ActionResult Details(int id = 0)
        {
            tblProvince tblprovince = db.tblProvinces.Find(id);
            if (tblprovince == null)
            {
                return HttpNotFound();
            }
            return View(tblprovince);
        }

        //
        // GET: /Province/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Province/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tblProvince tblprovince)
        {
            if (ModelState.IsValid)
            {
                db.tblProvinces.Add(tblprovince);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblprovince);
        }

        //
        // GET: /Province/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tblProvince tblprovince = db.tblProvinces.Find(id);
            if (tblprovince == null)
            {
                return HttpNotFound();
            }
            return View(tblprovince);
        }

        //
        // POST: /Province/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tblProvince tblprovince)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblprovince).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblprovince);
        }

        //
        // GET: /Province/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblProvince tblprovince = db.tblProvinces.Find(id);
            if (tblprovince == null)
            {
                return HttpNotFound();
            }
            return View(tblprovince);
        }

        //
        // POST: /Province/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProvince tblprovince = db.tblProvinces.Find(id);
            db.tblProvinces.Remove(tblprovince);
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