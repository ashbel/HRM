using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.IO;

namespace Hrm_System.Controllers
{
    public class EmployeeController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            var tblemployees = db.tblEmployees.Include(t => t.tblBranch).Include(t => t.tblDepartment).Include(t => t.tblEmployeeStatu).Include(t => t.tblPosition);
            return View(tblemployees.ToList());
        }
      
        
        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            tblEmployeeContact ec = (tblEmployeeContact)db.tblEmployeeContacts.FirstOrDefault(c=>c.emp_id == tblemployee.emp_id);
            EmployeeModelView emv = new EmployeeModelView();
            emv.emp_bDate = (DateTime)tblemployee.emp_bDate;
            emv.emp_branch = tblemployee.emp_branch;
            emv.emp_cDate = tblemployee.emp_cDate;
            //emv.emp_city = ec.emp_city;
            emv.emp_dpt = tblemployee.emp_dpt;
            emv.emp_ec_num = tblemployee.emp_ec_num;
            emv.emp_email = tblemployee.emp_email;
            emv.emp_id = tblemployee.emp_id;
            emv.emp_id_num = tblemployee.emp_id_num;
            emv.emp_jDate = tblemployee.emp_jDate;
            emv.emp_kin = ec.emp_kin;
            emv.emp_kin_add = ec.emp_kin_add;
            emv.emp_kin_ph = ec.emp_kin_ph;
            emv.emp_lname = tblemployee.emp_lname;
            emv.emp_mobile = ec.emp_mobile;
            emv.emp_name = tblemployee.emp_name;
            emv.emp_nation = tblemployee.emp_nation;
            emv.emp_nghbhd = ec.emp_nghbhd;
            emv.emp_phone = ec.emp_phone;
            emv.emp_pos_id = tblemployee.emp_pos_id;
            emv.emp_province = ec.emp_province;
            emv.emp_status = tblemployee.emp_status;
            emv.emp_strt = ec.emp_strt;
            emv.emp_status = tblemployee.emp_state;


            if (tblemployee.img_id == null)
            {
                var picture =  db.tblImages.Find(1) ;
                ViewBag.url = null;
            }
            else
            {
                ViewBag.url = tblemployee.tblImage.img_data;
            }

            var lv = from c in db.tblLeaves where c.emp_id == tblemployee.emp_id select c;
            ViewBag.Leave = lv;
            var lvhistory = from c in db.tblLvUsages where c.emp_id == tblemployee.emp_id select c;
            ViewBag.LeaveHistory = lvhistory;
            var contract = from c in db.tblContracts where c.emp_id == tblemployee.emp_id select c;
            ViewBag.Contracts = contract;

            DateTime jDate = (DateTime)tblemployee.emp_jDate;
            var dateSpan = DateTimeSpan.CompareDates(jDate, DateTime.Now.Date);
            ViewBag.Duration = dateSpan.Years + " yrs " + dateSpan.Months + " Months";

            if (tblemployee == null)
            {
                return HttpNotFound();
            }

            return View(emv);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            ViewBag.emp_state = db.tblEmplStatus.ToList();// "stat_id", "stat_name");
            ViewBag.emp_branch = db.tblBranches.ToList();//, "br_id", "br_name");
            ViewBag.emp_pos_ID = db.tblPositions.ToList();//, "pos_id", "pos_title");
            ViewBag.emp_dpt = db.tblDepartments.ToList();//, "dpt_id", "dpt_name");
            ViewBag.emp_status = db.tblEmployeeStatus.ToList();//, "empst_id", "empst_title");
            ViewBag.emp_gender = db.tblGenders.ToList();//, "emp_sx_id", "emp_sex");
            ViewBag.emp_salutation = db.tblSalutations.ToList();
            ViewBag.emp_cty = db.tblCities.ToList();//, "cty_id", "cty_name");
            ViewBag.emp_prv = db.tblProvinces.ToList();//, "prov_id", "prov_name");
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            EmployeeModelView ev = new EmployeeModelView();
            ev.emp_bDate = Convert.ToDateTime(form["dob"]);
            ev.emp_branch = Convert.ToInt32(form["branch"]);
            ev.emp_city = Convert.ToInt32(form["city"]);
            ev.emp_dpt = Convert.ToInt32(form["dpt"]);
            ev.emp_drv_num = form["dlicence"];
            ev.emp_ec_num = form["ecnum"];
            ev.emp_email = form["email"];
            ev.emp_id_num = form["idnum"];
            ev.emp_jDate = Convert.ToDateTime(form["sdate"]);
            ev.emp_kin = form["kin"];
            ev.emp_kin_add = form["kinaddress"];
            ev.emp_kin_ph = form["kin_phone"];
            ev.emp_kin_rel = form["kin_rel"];
            ev.emp_lname = form["sname"];
            ev.emp_marital = Convert.ToInt32(form["marital"]);
            ev.emp_mid_names = form["mname"];
            ev.emp_mobile = form["phonenum"];
            ev.emp_name = form["fname"];
            ev.emp_nation = form["nation"];
            ev.emp_nghbhd = form["area"];
            ev.emp_passport_date = Convert.ToDateTime(form["pdate"]);
            ev.emp_passport_num = form["pnum"];
            ev.emp_phone = form["name"];
            ev.emp_pos_id = Convert.ToInt32(form["pos"]);
            ev.emp_province = Convert.ToInt32(form["province"]);
            ev.emp_salutation = Convert.ToInt32(form["title"]);
            ev.emp_sex = Convert.ToInt32(form["sex"]);
            ev.emp_state = Convert.ToInt32(form["province"]);
            ev.emp_status = Convert.ToInt32(form["estatus"]);
            ev.emp_strt = form["home"];

            tblEmployee tblemployee = new tblEmployee();


            if (ModelState.IsValid)
            {
                tblemployee.emp_name = ev.emp_name;
                tblemployee.emp_lname = ev.emp_lname;
                tblemployee.emp_email = ev.emp_email;
                tblemployee.emp_pos_id = ev.emp_pos_id;
                tblemployee.emp_branch = ev.emp_branch;
                tblemployee.emp_status = ev.emp_status;
                tblemployee.emp_dpt = ev.emp_dpt;
                tblemployee.emp_cDate = DateTime.Now; 
                tblemployee.emp_bDate = ev.emp_bDate;
                tblemployee.emp_jDate = ev.emp_jDate;
                tblemployee.emp_id_num = ev.emp_id_num;
                tblemployee.emp_ec_num = ev.emp_ec_num;
                tblemployee.emp_nation = ev.emp_nation;
                tblemployee.emp_state = ev.emp_state;

                tblEmployeeContact ec = new tblEmployeeContact();
                ec.emp_id = tblemployee.emp_id;
                ec.emp_kin = ev.emp_kin;
                ec.emp_kin_add = ev.emp_kin_add;
                ec.emp_kin_ph = ev.emp_kin_ph;
                ec.emp_mobile = ev.emp_mobile;
                ec.emp_nghbhd = ev.emp_nghbhd;
                ec.emp_phone = ev.emp_phone;
                ec.emp_province = ev.emp_province;
                ec.emp_strt = ev.emp_strt;
                ec.emp_city = ev.emp_city;
  
                db.tblEmployees.Add(tblemployee);
                db.tblEmployeeContacts.Add(ec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_pos = new SelectList(db.tblPositions, "pos_id", "pos_title", tblemployee.emp_pos_id);
            ViewBag.emp_branch = new SelectList(db.tblBranches, "br_id", "br_name", tblemployee.emp_branch);
            ViewBag.emp_cty = new SelectList(db.tblCities, "cty_id", "cty_name");
            ViewBag.emp_dpt = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblemployee.emp_dpt);
            ViewBag.emp_status = new SelectList(db.tblEmployeeStatus, "empst_id", "empst_title", tblemployee.emp_status);
            return View(tblemployee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        { 
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            tblEmployeeContact ec = (tblEmployeeContact)db.tblEmployeeContacts.FirstOrDefault(c => c.emp_id == tblemployee.emp_id);
            EmployeeModelView emv = new EmployeeModelView();
            emv.emp_bDate = (DateTime)tblemployee.emp_bDate;
            emv.emp_branch = tblemployee.emp_branch;
            emv.emp_cDate = tblemployee.emp_cDate;
            emv.emp_city = ec.emp_city;
            emv.emp_dpt = tblemployee.emp_dpt;
            emv.emp_ec_num = tblemployee.emp_ec_num;
            emv.emp_email = tblemployee.emp_email;
            emv.emp_id = tblemployee.emp_id;
            emv.emp_id_num = tblemployee.emp_id_num;
            emv.emp_jDate = tblemployee.emp_jDate;
            emv.emp_kin = ec.emp_kin;
            emv.emp_kin_add = ec.emp_kin_add;
            emv.emp_kin_ph = ec.emp_kin_ph;
            emv.emp_lname = tblemployee.emp_lname;
            emv.emp_mobile = ec.emp_mobile;
            emv.emp_name = tblemployee.emp_name;
            emv.emp_nation = tblemployee.emp_nation;
            emv.emp_nghbhd = ec.emp_nghbhd;
            emv.emp_phone = ec.emp_phone;
            emv.emp_pos_id = tblemployee.emp_pos_id;
            emv.emp_province = ec.emp_province;
            emv.emp_status = tblemployee.emp_status;
            emv.emp_strt = ec.emp_strt;
            emv.emp_status = tblemployee.emp_state;
            if (tblemployee == null)
            {
                return HttpNotFound();
            }

            ViewBag.emp_state = new SelectList(db.tblEmplStatus, "stat_id", "stat_name",tblemployee.emp_state);
            ViewBag.emp_pos_ID = new SelectList(db.tblPositions, "pos_id", "pos_title",tblemployee.emp_pos_id);
            ViewBag.emp_branch = new SelectList(db.tblBranches, "br_id", "br_name", tblemployee.emp_branch);
            ViewBag.emp_dpt = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblemployee.emp_dpt);
            ViewBag.emp_cty = new SelectList(db.tblCities, "cty_id", "cty_name", ec.emp_city);
            ViewBag.emp_status = new SelectList(db.tblEmployeeStatus, "empst_id", "empst_title", tblemployee.emp_status);
            return View(emv);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModelView ev)
        {
            tblEmployee tblemployee = db.tblEmployees.Find(ev.emp_id);


            if (ModelState.IsValid)
            {
                tblemployee.emp_name = ev.emp_name;
                tblemployee.emp_lname = ev.emp_lname;
                tblemployee.emp_email = ev.emp_email;
                tblemployee.emp_pos_id = ev.emp_pos_id;
                tblemployee.emp_branch = ev.emp_branch;
                tblemployee.emp_status = ev.emp_status;
                tblemployee.emp_dpt = ev.emp_dpt;
                tblemployee.emp_cDate = DateTime.Now;
                tblemployee.emp_bDate = ev.emp_bDate;
                tblemployee.emp_jDate = ev.emp_jDate;
                tblemployee.emp_id_num = ev.emp_id_num;
                tblemployee.emp_ec_num = ev.emp_ec_num;
                tblemployee.emp_nation = ev.emp_nation;
                tblemployee.emp_state = ev.emp_state;

                tblEmployeeContact ec = (tblEmployeeContact)db.tblEmployeeContacts.FirstOrDefault(c => c.emp_id == ev.emp_id);
                ec.emp_kin = ev.emp_kin;
                ec.emp_kin_add = ev.emp_kin_add;
                ec.emp_kin_ph = ev.emp_kin_ph;
                ec.emp_mobile = ev.emp_mobile;
                ec.emp_nghbhd = ev.emp_nghbhd;
                ec.emp_phone = ev.emp_phone;
                ec.emp_province = ev.emp_province;
                ec.emp_strt = ev.emp_strt;
                ec.emp_city = ev.emp_city;

                //db.Entry(ec).State = EntityState.Modified;
                //db.Entry(tblemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_state = new SelectList(db.tblEmplStatus, "stat_id", "stat_name", tblemployee.emp_state);
            ViewBag.emp_pos_ID = new SelectList(db.tblPositions, "pos_id", "pos_title", tblemployee.emp_pos_id);
            ViewBag.emp_branch = new SelectList(db.tblBranches, "br_id", "br_name", tblemployee.emp_branch);
            ViewBag.emp_dpt = new SelectList(db.tblDepartments, "dpt_id", "dpt_name", tblemployee.emp_dpt);
            ViewBag.emp_status = new SelectList(db.tblEmployeeStatus, "empst_id", "empst_title", tblemployee.emp_status);

            return View(ev);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            if (tblemployee == null)
            {
                return HttpNotFound();
            }
            return View(tblemployee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            db.tblEmployees.Remove(tblemployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult UploadFile(FormCollection formCollection)
        {
            if (Request != null)
            {
                byte[] array = null;
                var id = Convert.ToInt32(formCollection["emp_id"]);
                HttpPostedFileBase uploadFile = Request.Files["uploadFile"];
                var path = Server.MapPath("../empImg/" + id + "/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.Combine(path,Path.GetFileName(uploadFile.FileName));
                uploadFile.SaveAs(fileName);

                using (MemoryStream ms = new MemoryStream())
                {
                    uploadFile.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                }
 
                tblEmployee tblemployee = db.tblEmployees.Find(id);
                tblImage img = db.tblImages.FirstOrDefault(c=>c.emp_id == tblemployee.emp_id);

                if (img == null)
                {
                    tblImage imgs = new tblImage();
                    imgs.emp_id = tblemployee.emp_id;
                    imgs.img_desc = uploadFile.FileName;
                    imgs.img_data = array;
                    tblemployee.img_id = imgs.img_id;
                    db.tblImages.Add(imgs);
                    db.SaveChanges(); 
                }
                else
                {
                    img.emp_id = tblemployee.emp_id;
                    img.img_desc = uploadFile.FileName;
                    img.img_data = array;
                    tblemployee.img_id = img.img_id;

                    db.Entry(img).State = EntityState.Modified;
                    db.SaveChanges(); 
                }
          
             return RedirectToAction("Details", "Employee", new { id = id });
            }
            return RedirectToAction("Home", "Home");
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
    }
}