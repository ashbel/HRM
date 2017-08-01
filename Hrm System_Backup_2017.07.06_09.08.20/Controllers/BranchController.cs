using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Hrm_System.Controllers
{
    public class BranchController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /Branch/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EditingPopup_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetAll().ToDataSourceResult(request));
        }


        public IList<BranchModelView> GetAll()
        {
            IList<BranchModelView> result = new List<BranchModelView>();

            result = db.tblBranches.Select(p => new BranchModelView
            {
                BranchId = p.br_id,
                BranchName = p.br_name,
                BranchAddress = p.br_address,
                BranchDescription = p.br_descr,
                BranchContact = p.br_contact
            
            }).ToList();


            return result;
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Create([DataSourceRequest] DataSourceRequest request, BranchModelView branch)
        {
            if (branch != null && ModelState.IsValid)
            {
                var br = new tblBranch
                {
                    br_id = branch.BranchId,
                    br_address = branch.BranchAddress,
                    br_contact = branch.BranchContact,
                    br_descr = branch.BranchDescription,
                    br_name = branch.BranchName

                };
                db.tblBranches.Add(br);
                db.SaveChanges();
            }

            return Json(new[] { branch }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Update([DataSourceRequest] DataSourceRequest request, BranchModelView branch)
        {
            if (branch != null && ModelState.IsValid)
            {
                var br = new tblBranch
                {
                    br_id = branch.BranchId,
                    br_address = branch.BranchAddress,
                    br_contact = branch.BranchContact,
                    br_descr = branch.BranchDescription,
                    br_name = branch.BranchName

                };

                db.Entry(br).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { branch }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingPopup_Destroy([DataSourceRequest] DataSourceRequest request, BranchModelView branch)
        {
            if (branch != null)
            {
                var br = new tblBranch
                {
                    br_id = branch.BranchId,
                    br_address = branch.BranchAddress,
                    br_contact = branch.BranchContact,
                    br_descr = branch.BranchDescription,
                    br_name = branch.BranchName

                };
                db.tblBranches.Remove(br);
                db.SaveChanges();
            }

            return Json(new[] { branch }.ToDataSourceResult(request, ModelState));
        }

        //
        public ActionResult Excel_Export_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetAll().ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}