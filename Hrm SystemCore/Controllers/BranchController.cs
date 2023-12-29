using Hrm_SystemCore.Models;
using Hrm_SystemCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hrm_SystemCore.Controllers
{
    [Authorize]
    public class BranchController : Controller
    {
        private readonly HRMEntities _db;

        public BranchController(HRMEntities db)
        {
            this._db = db;
        }

        //
        // GET: /Branch/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult EditingPopup_Read()
        {
            return Json(GetAll());
        }


        public IList<BranchModelView> GetAll()
        {
            IList<BranchModelView> result = new List<BranchModelView>();

            result = _db.tblBranches.Select(p => new BranchModelView
            {
                BranchId = p.br_id,
                BranchName = p.br_name,
                BranchAddress = p.br_address,
                BranchDescription = p.br_descr,
                BranchContact = p.br_contact

            }).ToList();


            return result;
        }

        [AcceptVerbs("Post")]
        public ActionResult EditingPopup_Create( BranchModelView branch)
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
                _db.tblBranches.Add(br);
                _db.SaveChanges();
            }

            return Json(new[] { branch });
        }

        [AcceptVerbs("Post")]
        public ActionResult EditingPopup_Update(BranchModelView branch)
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

                //db.Entry(br).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return Json(new[] { branch });
        }

        [AcceptVerbs("Post")]
        public ActionResult EditingPopup_Destroy( BranchModelView branch)
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
                _db.tblBranches.Remove(br);
                _db.SaveChanges();
            }

            return Json(new[] { branch });
        }

        //
        public ActionResult Excel_Export_Read()
        {
            return Json(GetAll());
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }


        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}