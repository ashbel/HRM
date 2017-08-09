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
using PagedList;

namespace Hrm_System.Controllers
{
    [CustomAuthorize]
    public class EmployeeController : Controller
    {
        private HRMEntities db = new HRMEntities();

        //
        // GET: /Employee/

        public ActionResult Index(int page = 1)
        {
            var tblemployees = db.tblEmployees.Include(t => t.tblBranch).Include(t => t.tblDepartment).Include(t => t.tblEmployeeStatu).Include(t => t.tblPosition);

            int count = db.tblEmployees.Where(c => c.tblEmployeeStatu.empst_title == "Active").Count();
            ViewBag.Active = count;
            ViewBag.Positions = db.tblPositions.ToList();
            ViewBag.Levels = db.tblJobLevels.ToList();
            ViewBag.Branch = db.tblBranches;
            ViewBag.Department = db.tblDepartments;
            ViewBag.Departments = db.tblEmployees.GroupBy(c => c.emp_dpt).Count();
            //ViewBag.Positions = db.tblEmployees.GroupBy(c => c.emp_pos_id).Count();
            Double years = 0;
            Double months = 0;
            var active_employees = db.tblEmployees.Where(c => c.tblEmployeeStatu.empst_title == "Active");
            foreach (var i in active_employees)
            {
                years = years + (DateTime.Now.Year - i.emp_bDate.Value.Year);
                months = months + (((DateTime.Now.Year - i.emp_jDate.Value.Year) * 12) + (DateTime.Now.Month - i.emp_jDate.Value.Month));
            }
            ViewBag.AverageAge = (years / count).ToString("0");
            ViewBag.AverageWork = ((months / count) / 12).ToString("0.00");

            return View(tblemployees.OrderBy(c => c.emp_id).ToPagedList(page, 50));

        }
      
        
        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            tblEmployee tblemployee = db.tblEmployees.Find(id);
            tblEmployeeContact ec = (tblEmployeeContact)db.tblEmployeeContacts.FirstOrDefault(c=>c.emp_id == tblemployee.emp_id);
            EmployeeModelView emv = new EmployeeModelView();
            emv.emp_bDate = (DateTime)tblemployee.emp_bDate;
            emv.emp_branch = tblemployee.tblBranch.br_name;
            emv.emp_cDate = tblemployee.emp_cDate;
            emv.emp_city = ec.tblCity.cty_name;
            emv.emp_dpt = tblemployee.tblDepartment.dpt_name;
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
            emv.emp_pos_id = tblemployee.tblPosition.pos_title;
            emv.emp_province = ec.tblProvince.prov_name;
            emv.emp_state = tblemployee.tblEmployeeStatu.empst_title;
            emv.emp_strt = ec.emp_strt;
            emv.emp_status = tblemployee.tblEmplStatu.stat_name;


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
            var contract = from c in db.tblContracts where c.emp_id == tblemployee.emp_id  select c;
            ViewBag.Contracts = contract;
            var courses_enrolled = (from c in db.tblTrainings where c.emp_id == tblemployee.emp_id select c.course_id).ToList();
            var courses_enroll = from c in db.tblTrainings where c.emp_id == tblemployee.emp_id select c;
            ViewBag.Courses_Enrolled = courses_enroll;
            var course = from c in db.tblCourses where !courses_enrolled.Contains(c.course_id) select c;
            ViewBag.Courses = course;
            var document = from c in db.tblDocuments where c.emp_id == tblemployee.emp_id select c;
            ViewBag.Documents = document;
            ViewBag.emp_state = db.tblEmplStatus.ToList();
            ViewBag.Contract_state = db.tblContractStates.ToList();
            ViewBag.Marital_state = db.tblMaritals.ToList();
            ViewBag.emp_branch = db.tblBranches.ToList();//, "br_id", "br_name");
            ViewBag.emp_pos_ID = db.tblPositions.ToList();//, "pos_id", "pos_title");
            ViewBag.emp_dpt = db.tblDepartments.ToList();//, "dpt_id", "dpt_name");
            ViewBag.edu_level = db.tblEduLevels.ToList();
            ViewBag.education = from c in db.tblEducations where c.emp_id == tblemployee.emp_id select c;
            ViewBag.work = from c in db.tblWorks where c.emp_id == tblemployee.emp_id select c;
            ViewBag.Achievement = from c in db.tblAchievements where c.emp_id == tblemployee.emp_id select c;
            ViewBag.Kpi = from c in db.tblKPIs where c.emp_id == tblemployee.emp_id select c;

            DateTime jDate = (DateTime)tblemployee.emp_jDate;
            var dateSpan = DateTimeSpan.CompareDates(jDate, DateTime.Now.Date);
            ViewBag.Duration = dateSpan.Years + " yrs " + dateSpan.Months + " Months";

            if (tblemployee == null)
            {
                return HttpNotFound();
            }

            try
            {
                tblEmployee last = db.tblEmployees.Find(id - 1);
                ViewBag.Last = last.emp_id;
            }
            catch
            {
                ViewBag.Last = 0;
            }
            try
            {
                tblEmployee next = db.tblEmployees.Find(id + 1);
                ViewBag.Next = next.emp_id;
            }
            catch
            {
                ViewBag.Next = 0;
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
            ViewBag.Contract_state = db.tblContractStates.ToList();
            ViewBag.Marital_state = db.tblMaritals.ToList();
            ViewBag.Contract_type = db.tblContractTypes.ToList();
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
            int emp_branch = Convert.ToInt32(form["branch"]);
            int emp_city = Convert.ToInt32(form["city"]);
            int emp_dpt = Convert.ToInt32(form["dpt"]);
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
            int emp_marital = Convert.ToInt32(form["marital"]);
            ev.emp_mid_names = form["mname"];
            ev.emp_mobile = form["phonenum"];
            ev.emp_name = form["fname"];
            ev.emp_nation = form["nation"];
            ev.emp_nghbhd = form["area"];
            try
            {
                ev.emp_passport_date = Convert.ToDateTime(form["pdate"]);
            }
            catch { }
            ev.emp_passport_num = form["pnum"];
            ev.emp_phone = form["name"];
            int emp_pos_id = Convert.ToInt32(form["pos"]);
            int emp_province = Convert.ToInt32(form["province"]);
            int emp_salutation = Convert.ToInt32(form["title"]);
            int emp_sex = Convert.ToInt32(form["sex"]);
            int emp_state = Convert.ToInt32(form["province"]);
            int emp_status = Convert.ToInt32(form["estatus"]);
            int contract_type = Convert.ToInt32(form["contract_type"]);
            ev.emp_strt = form["home"];
            ev.cntrct_desc = form["cntrct_desc"];
            try
            {
                ev.cntrct_edate = Convert.ToDateTime(form["cntrct_edate"]);
            }
            catch { ev.cntrct_edate = null; }
            ev.cntrct_sdate = Convert.ToDateTime(form["cntrct_sdate"]);
            int cntrct_state= Convert.ToInt32(form["contract_state"]);
            ev.cntrct_title = form["contract_title"];

            HttpPostedFileBase photo = Request.Files["photo"];
            HttpPostedFileBase cv = Request.Files["cv"];
            HttpPostedFileBase olevel = Request.Files["olevel"];
            HttpPostedFileBase alevel = Request.Files["alevel"];
            HttpPostedFileBase uni = Request.Files["uni"];
            HttpPostedFileBase idscan = Request.Files["idscan"];
            HttpPostedFileBase passport = Request.Files["passport"];
            HttpPostedFileBase drvlicence = Request.Files["drvlicence"];

            tblEmployee tblemployee = new tblEmployee();
            tblContract tblcontract = new tblContract();
            tblDocument tbldocument = new tblDocument();
            tblDocument tbldocument1 = new tblDocument();
            tblDocument tbldocument2 = new tblDocument();
            tblDocument tbldocument3 = new tblDocument();
            tblDocument tbldocument4 = new tblDocument();
            tblDocument tbldocument5 = new tblDocument();
            tblDocument tbldocument6 = new tblDocument();


            if (ModelState.IsValid)
            {
                tblemployee.emp_name = ev.emp_name;
                tblemployee.emp_lname = ev.emp_lname;
                tblemployee.emp_email = ev.emp_email;
                tblemployee.emp_pos_id = emp_pos_id;
                tblemployee.emp_branch = emp_branch;
                tblemployee.emp_status = emp_status;
                tblemployee.emp_dpt = emp_dpt;
                tblemployee.emp_cDate = DateTime.Now; 
                tblemployee.emp_bDate = ev.emp_bDate;
                tblemployee.emp_jDate = ev.emp_jDate;
                tblemployee.emp_id_num = ev.emp_id_num;
                tblemployee.emp_ec_num = ev.emp_ec_num;
                tblemployee.emp_nation = ev.emp_nation;
                tblemployee.emp_state = emp_state;
                tblemployee.emp_sex = emp_sex;

                tblEmployeeContact ec = new tblEmployeeContact();
                ec.emp_id = tblemployee.emp_id;
                ec.emp_kin = ev.emp_kin;
                ec.emp_kin_add = ev.emp_kin_add;
                ec.emp_kin_ph = ev.emp_kin_ph;
                ec.emp_mobile = ev.emp_mobile;
                ec.emp_nghbhd = ev.emp_nghbhd;
                ec.emp_phone = ev.emp_phone;
                ec.emp_province = emp_province;
                ec.emp_strt = ev.emp_strt;
                ec.emp_city = emp_city;


                tblcontract.cntrct_desc = ev.cntrct_desc;
                tblcontract.cntrct_edate = ev.cntrct_edate;
                tblcontract.cntrct_sdate = ev.cntrct_sdate;
                tblcontract.cntrct_state =  cntrct_state;
                tblcontract.cntrct_title = ev.cntrct_title;
                tblcontract.cntcrt_typ_id = contract_type;
                tblcontract.emp_id = tblemployee.emp_id;
                tblcontract.br_id = emp_branch;
                tblcontract.dpt_id = emp_dpt;
                tblcontract.pos_id = emp_pos_id;
                tblcontract.create_date = DateTime.Now;

                db.tblContracts.Add(tblcontract);
                db.tblEmployees.Add(tblemployee);
                db.tblEmployeeContacts.Add(ec);
                db.SaveChanges();

                if (photo.ContentLength != 0)
                {
                    byte[] array = null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        photo.InputStream.CopyTo(ms);
                        array = ms.GetBuffer();
                    }
                    tblImage imgs = new tblImage();
                    imgs.emp_id = tblemployee.emp_id;
                    imgs.img_desc = photo.FileName;
                    imgs.img_data = array;
                    tblemployee.img_id = imgs.img_id;
                    db.tblImages.Add(imgs);
                }

                if (cv.ContentLength != 0)
                {

                    
                    tbldocument.doc_name = "CV";
                    tbldocument.doc_type = cv.ContentType;
                    tbldocument.doc_date = DateTime.Now;
                    tbldocument.emp_id = tblemployee.emp_id;
                    tbldocument.doc_path = filename(cv, tblemployee.emp_id);
                    db.tblDocuments.Add(tbldocument);
                }
                if (olevel.ContentLength != 0)
                {
                    
                    tbldocument1.doc_name = "O Level Certificate";
                    tbldocument1.doc_type = olevel.ContentType;
                    tbldocument1.doc_date = DateTime.Now;
                    tbldocument1.emp_id = tblemployee.emp_id;
                    tbldocument1.doc_path = filename(olevel, tblemployee.emp_id);
                    db.tblDocuments.Add(tbldocument1);
                }
                if (alevel.ContentLength != 0)
                {
                    
                    tbldocument2.doc_name = "A Level Certificate";
                    tbldocument2.doc_type = alevel.ContentType;
                    tbldocument2.doc_date = DateTime.Now;
                    tbldocument2.emp_id = tblemployee.emp_id;
                    tbldocument2.doc_path = filename(alevel, tblemployee.emp_id);
                    db.tblDocuments.Add(tbldocument2);
                }
                if (uni.ContentLength != 0)
                {
                    
                    tbldocument3.doc_name = "University Certificate";
                    tbldocument3.doc_type = uni.ContentType;
                    tbldocument3.doc_date = DateTime.Now;
                    tbldocument3.emp_id = tblemployee.emp_id;
                    tbldocument3.doc_path = filename(uni, tblemployee.emp_id);
                    db.tblDocuments.Add(tbldocument3);
                }
                if (idscan.ContentLength != 0)
                {
                    
                    tbldocument4.doc_name = "ID Document";
                    tbldocument4.doc_type = idscan.ContentType;
                    tbldocument4.doc_date = DateTime.Now;
                    tbldocument4.emp_id = tblemployee.emp_id;
                    tbldocument4.doc_path = filename(idscan, tblemployee.emp_id);
                    db.tblDocuments.Add(tbldocument4);
                }
                if (passport.ContentLength != 0)
                {
                    
                    tbldocument5.doc_name = "Passport Document";
                    tbldocument5.doc_type = passport.ContentType;
                    tbldocument5.doc_date = DateTime.Now;
                    tbldocument5.emp_id = tblemployee.emp_id;
                    tbldocument5.doc_path = filename(passport, tblemployee.emp_id);
                    db.tblDocuments.Add(tbldocument5);
                }
                if (drvlicence.ContentLength != 0)
                {
                    
                    tbldocument6.doc_name = "Drivers Licence Document";
                    tbldocument6.doc_type = drvlicence.ContentType;
                    tbldocument6.doc_date = DateTime.Now;
                    tbldocument6.emp_id = tblemployee.emp_id;
                    tbldocument6.doc_path = filename(drvlicence, tblemployee.emp_id);
                    db.tblDocuments.Add(tbldocument6);
                }

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
            int? emp_branch = tblemployee.emp_branch;
            emv.emp_cDate = tblemployee.emp_cDate;
            int? emp_city = ec.emp_city;
            int? emp_dpt = tblemployee.emp_dpt;
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
            int? emp_pos_id = tblemployee.emp_pos_id;
            int? emp_province = ec.emp_province;
            int? emp_status = tblemployee.emp_status;
            emv.emp_strt = ec.emp_strt;
            int? emp_state = tblemployee.emp_state;
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
                //tblemployee.emp_pos_id = ev.emp_pos_id;
                //tblemployee.emp_branch = ev.emp_branch;
                //tblemployee.emp_status = ev.emp_status;
                //tblemployee.emp_dpt = ev.emp_dpt;
                tblemployee.emp_cDate = DateTime.Now;
                tblemployee.emp_bDate = ev.emp_bDate;
                tblemployee.emp_jDate = ev.emp_jDate;
                tblemployee.emp_id_num = ev.emp_id_num;
                tblemployee.emp_ec_num = ev.emp_ec_num;
                tblemployee.emp_nation = ev.emp_nation;
                //tblemployee.emp_state = ev.emp_state;

                tblEmployeeContact ec = (tblEmployeeContact)db.tblEmployeeContacts.FirstOrDefault(c => c.emp_id == ev.emp_id);
                ec.emp_kin = ev.emp_kin;
                ec.emp_kin_add = ev.emp_kin_add;
                ec.emp_kin_ph = ev.emp_kin_ph;
                ec.emp_mobile = ev.emp_mobile;
                ec.emp_nghbhd = ev.emp_nghbhd;
                ec.emp_phone = ev.emp_phone;
                //ec.emp_province = ev.emp_province;
                ec.emp_strt = ev.emp_strt;
               // ec.emp_city = ev.emp_city;

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

        public string filename (HttpPostedFileBase uploadFile, int emp_id)
        {
            string fileName = "";

            if (Request != null)
            {
                var path = Server.MapPath("../EmployeeFiles/Docs/" + emp_id + "/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                fileName = Path.Combine(path, Path.GetFileName(uploadFile.FileName));
                uploadFile.SaveAs(fileName);
                
            }
                

            return fileName;
        }

        [HttpPost]
        public ActionResult UploadDocuments(FormCollection formCollection)
        {
            if (Request != null)
            {
                byte[] array = null;
                var id = Convert.ToInt32(formCollection["emp_id"]);
                string doc_name = formCollection["doc_name"];
                HttpPostedFileBase uploadFile = Request.Files["other_doc"];
                if (Request != null)
                {
                    var path = Server.MapPath("../EmployeeFiles/Docs/" + id + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Path.Combine(path, Path.GetFileName(uploadFile.FileName));
                    uploadFile.SaveAs(fileName);



                    tblDocument tbldocument = new tblDocument();
                    tbldocument.doc_name = doc_name;
                    tbldocument.doc_type = uploadFile.ContentType;
                    tbldocument.doc_date = DateTime.Now;
                    tbldocument.emp_id = id;
                    tbldocument.doc_path = fileName;
                    db.tblDocuments.Add(tbldocument);

                    db.SaveChanges();
                }

                    return RedirectToAction("Details", "Employee", new { id = id } );
                
            }
            return RedirectToAction("Home", "Home");
        }

        public ActionResult DeleteDocument(int id)
        {
            tblDocument tbldocument = db.tblDocuments.Find(id);
            int ids = (int)tbldocument.emp_id;
            if (System.IO.File.Exists(tbldocument.doc_path))
            {
                System.IO.File.Delete(tbldocument.doc_path);
            }
            db.tblDocuments.Remove(tbldocument);
            db.SaveChanges();
            return RedirectToAction("Details", "Employee", new { id = ids });
        }

        public FileResult DownloadDocument(int id)
        {
            tblDocument tbldocument = db.tblDocuments.Find(id);
            return File(tbldocument.doc_path, tbldocument.doc_type,tbldocument.doc_name+" - "+tbldocument.tblEmployee.emp_name+tbldocument.tblEmployee.emp_lname);
        }

        [HttpPost]
        public ActionResult EnrolCourse(FormCollection formCollection)
        {
            if (Request != null)
            {
                byte[] array = null;
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var course_id = Convert.ToInt32(formCollection["cs_id"]);
                var course_cmnt = formCollection["cs_cmnt"];
                var sdate = formCollection["cs_start"];
                var edate = formCollection["cs_end"];
                DateTime cs_sdate = DateTime.Now;
                DateTime cs_edate = DateTime.Now;
                try
                {
                     cs_sdate = Convert.ToDateTime(sdate);
                }
                catch { }
                try
                {
                     cs_edate = Convert.ToDateTime(edate);
                }
                catch { }

                tblTraining tbltraining = new tblTraining();
                tbltraining.emp_id = id;
                tbltraining.course_id = course_id;
                tbltraining.tr_sdate = cs_sdate;
                tbltraining.tr_edate = cs_edate;
                tbltraining.tr_status = "ENROLLED";
                tbltraining.tr_comments = course_cmnt;
                db.tblTrainings.Add(tbltraining);
                db.SaveChanges();

                return RedirectToAction("Details", "Employee", new { id = id });

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddContract(FormCollection formCollection)
        {
            if (Request != null)
            {
                byte[] array = null;
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var cntrct_title = formCollection["cntrct_title"];
                var cntrct_state = Convert.ToInt32(formCollection["cntrct_state"]);
                var cntrct_dpt = Convert.ToInt32(formCollection["cntrct_dpt"]);
                var cntrct_br = Convert.ToInt32(formCollection["cntrct_branch"]);
                var cntrct_pos = Convert.ToInt32(formCollection["cntrct_position"]);
                var cntrct_desc = formCollection["cntrct_desc"];
                var sdate = formCollection["cntrct_sdate"];
                var edate = formCollection["cntrct_edate"];
                DateTime cs_sdate = DateTime.Now;
                DateTime cs_edate = DateTime.Now;
                try
                {
                    cs_sdate = Convert.ToDateTime(sdate);
                }
                catch { }
                try
                {
                    cs_edate = Convert.ToDateTime(edate);
                }
                catch { }

                tblContract tblcontract = new tblContract();
                tblcontract.emp_id = id;
                tblcontract.cntrct_desc = cntrct_desc;
                tblcontract.cntrct_edate = cs_edate;
                tblcontract.cntrct_sdate = cs_sdate;
                tblcontract.cntrct_title = cntrct_title;
                tblcontract.cntrct_state = cntrct_state;
                tblcontract.create_date = DateTime.Now;
                tblcontract.dpt_id = cntrct_dpt;
                tblcontract.pos_id = cntrct_pos;
                tblcontract.br_id = cntrct_br;
                db.tblContracts.Add(tblcontract);
                db.SaveChanges();

                return RedirectToAction("Details", "Employee", new { id = id });

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddEducation(FormCollection formCollection)
        {
            if (Request != null)
            {
                byte[] array = null;
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var edu_name = formCollection["edu_school"];
                var level_id = Convert.ToInt32(formCollection["edu_level"]);
                var edu_qlfcn = formCollection["edu_qn"];
                var edu_score = formCollection["edu_score"];
                var edu_comments = formCollection["edu_comments"];
                var sdate = formCollection["edu_sdate"];
                var edate = formCollection["edu_edate"];
                DateTime edu_sdate = DateTime.Now;
                DateTime edu_edate = DateTime.Now;
                try
                {
                    edu_sdate = Convert.ToDateTime(sdate);
                }
                catch { }
                try
                {
                    edu_edate = Convert.ToDateTime(edate);
                }
                catch { }

                tblEducation tbleducation = new tblEducation();
                tbleducation.emp_id = id;
                tbleducation.edu_lvl_id = level_id;
                tbleducation.edu_comment = edu_name;
                tbleducation.edu_name = edu_name;
                tbleducation.edu_qlfcn = edu_qlfcn;
                tbleducation.edu_score = edu_score;
                tbleducation.edu_sdate = edu_sdate;
                tbleducation.edu_edate = edu_edate;
               
                db.tblEducations.Add(tbleducation);
                db.SaveChanges();

                return RedirectToAction("Details", "Employee", new { id = id });

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddWork(FormCollection formCollection)
        {
            if (Request != null)
            {
                byte[] array = null;
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var wk_name = formCollection["wk_org"];
                var wk_pos = formCollection["wk_pos"];
                var wk_desc = formCollection["wk_jd"];
                var wk_comments = formCollection["wk_comments"];
                var sdate = formCollection["wk_sdate"];
                var edate = formCollection["wk_edate"];
                DateTime wk_sdate = DateTime.Now;
                DateTime wk_edate = DateTime.Now;
                try
                {
                    wk_sdate = Convert.ToDateTime(sdate);
                }
                catch { }
                try
                {
                    wk_edate = Convert.ToDateTime(edate);
                }
                catch { }

                tblWork tblwork = new tblWork();
                tblwork.emp_id = id;
                tblwork.wk_comment = wk_comments;
                tblwork.wk_company = wk_name;
                tblwork.wk_desc = wk_desc;
                tblwork.wk_edate = wk_edate;
                tblwork.wk_position = wk_pos;
                tblwork.wk_sdate = wk_sdate;
                db.tblWorks.Add(tblwork);
                db.SaveChanges();

                return RedirectToAction("Details", "Employee", new { id = id });

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddAchievement(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var achvt_name = formCollection["achvt_name"];
                var achvt_comment = formCollection["achvt_comment"];
                var achvt_date = formCollection["achvt_date"];
                DateTime ac_date = DateTime.Now;
                try
                {
                    ac_date = Convert.ToDateTime(achvt_date);
                }
                catch { }

                tblAchievement tblachievement = new tblAchievement();
                tblachievement.emp_id = id;
                tblachievement.achvt_date = ac_date;
                tblachievement.achvt_name = achvt_name;
                tblachievement.achvt_comment = achvt_comment;
                db.tblAchievements.Add(tblachievement);
                db.SaveChanges();

                return RedirectToAction("Details", "Employee", new { id = id });

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddPerfomance(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var kpi_score = formCollection["kpi_score"];
                var kpi_prd = formCollection["kpi_prd"];
                var kpi_date = formCollection["kpi_date"];
                var kpi_comment = formCollection["kpi_comment"];
                var kpi_title = formCollection["kpi_title"];

                DateTime kpi_sdate = DateTime.Now;
                try
                {
                    kpi_sdate = Convert.ToDateTime(kpi_date);
                }
                catch { }


                tblKPI tblkpi = new tblKPI();
                tblkpi.emp_id = id;
                tblkpi.kpi_comment = kpi_comment;
                tblkpi.kpi_date = kpi_sdate;
                tblkpi.kpi_prd = kpi_prd;
                tblkpi.kpi_score = kpi_score;
                tblkpi.kpi_title = kpi_title;
                db.tblKPIs.Add(tblkpi);
                db.SaveChanges();

                return RedirectToAction("Details", "Employee", new { id = id });

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeleteContract(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var cntrct_id = Convert.ToInt32(formCollection["cntrct_id"]);
                tblContract tblcontract = db.tblContracts.Find(cntrct_id);
                db.tblContracts.Remove(tblcontract);
                db.SaveChanges();
                return RedirectToAction("Details", "Employee", new { id = id });

            }
            return RedirectToAction("Home", "Home");
        }

        public JsonResult BarChartData()
        {
            var employees = db.tblEmployees;
            int count_total = 0;
            List<int> new_employees = new List<int>();
            List<int> all_employees = new List<int>();
            int jan = 0, feb = 0, mar = 0, apr = 0, may = 0, jun = 0, jul = 0, aug = 0, sept = 0, oct = 0, nov = 0, dec = 0;
            int year = DateTime.Now.Year;
            foreach(var employee in employees)
            {
                if (employee.emp_jDate.Value.Year < year)
                {
                    count_total++;
                }
                if(employee.emp_jDate.Value.Year == year)
                {
                    if(employee.emp_jDate.Value.Month == 1)
                    {
                        jan++;
                    }
                    if (employee.emp_jDate.Value.Month == 2)
                    {
                        feb++;
                    }
                    if (employee.emp_jDate.Value.Month == 3)
                    {
                        mar++;
                    }
                    if (employee.emp_jDate.Value.Month == 4)
                    {
                        apr++;
                    }
                    if (employee.emp_jDate.Value.Month == 5)
                    {
                        may++;
                    }
                    if (employee.emp_jDate.Value.Month == 6)
                    {
                        jun++;
                    }
                    if (employee.emp_jDate.Value.Month == 7)
                    {
                        jul++;
                    }
                    if (employee.emp_jDate.Value.Month == 8)
                    {
                        aug++;
                    }
                    if (employee.emp_jDate.Value.Month == 9)
                    {
                        sept++;
                    }
                    if (employee.emp_jDate.Value.Month == 10)
                    {
                        oct++;
                    }
                    if (employee.emp_jDate.Value.Month == 11)
                    {
                        nov++;
                    }
                    if (employee.emp_jDate.Value.Month == 12)
                    {
                        dec++;
                    }
                }
                
            }
            new_employees.Add(jan);
            new_employees.Add(feb);
            new_employees.Add(mar);
            new_employees.Add(apr);
            new_employees.Add(may);
            new_employees.Add(jun);
            new_employees.Add(jul);
            new_employees.Add(aug);
            new_employees.Add(sept);
            new_employees.Add(oct);
            new_employees.Add(nov);
            new_employees.Add(dec);
            Models.Chart _chart = new Models.Chart();
            _chart.labels = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novemeber", "December" };
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "New Employees",
                data = new_employees.ToArray(),
                backgroundColor = new string[] { "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)" },
                borderColor = new string[] { "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)", "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DonutChartData()
        {
            var departments = from c in db.tblEmployees
                              group c by c.tblDepartment.dpt_name into grp
                              select new { key = grp.Key, cnt = grp.Count() };
            List<string> labels = new List<string>();
            List<int> data = new List<int>();
            foreach (var dpt in departments)
            {
                labels.Add(dpt.key);
                data.Add(dpt.cnt);
            }

            Models.Chart _chart = new Models.Chart();
            _chart.labels = labels.ToArray();
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "Departments",
                data = data.ToArray(),
                backgroundColor = new string[] { "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)" },
                borderColor = new string[] { "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)", "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LineChartData()
        {
            var employees = db.tblEmployees;
            int count_total = 0;
            List<int> new_employees = new List<int>();
            List<int> all_employees = new List<int>();
            int jan = 0, feb = 0, mar = 0, apr = 0, may = 0, jun = 0, jul = 0, aug = 0, sept = 0, oct = 0, nov = 0, dec = 0;
            int year = DateTime.Now.Year;
            foreach (var employee in employees)
            {
                if (employee.emp_jDate.Value.Year < year)
                {
                    count_total++;
                }
                if (employee.emp_jDate.Value.Year == year)
                {
                    if (employee.emp_jDate.Value.Month == 1)
                    {
                        jan++;
                    }
                    if (employee.emp_jDate.Value.Month == 2)
                    {
                        feb++;
                    }
                    if (employee.emp_jDate.Value.Month == 3)
                    {
                        mar++;
                    }
                    if (employee.emp_jDate.Value.Month == 4)
                    {
                        apr++;
                    }
                    if (employee.emp_jDate.Value.Month == 5)
                    {
                        may++;
                    }
                    if (employee.emp_jDate.Value.Month == 6)
                    {
                        jun++;
                    }
                    if (employee.emp_jDate.Value.Month == 7)
                    {
                        jul++;
                    }
                    if (employee.emp_jDate.Value.Month == 8)
                    {
                        aug++;
                    }
                    if (employee.emp_jDate.Value.Month == 9)
                    {
                        sept++;
                    }
                    if (employee.emp_jDate.Value.Month == 10)
                    {
                        oct++;
                    }
                    if (employee.emp_jDate.Value.Month == 11)
                    {
                        nov++;
                    }
                    if (employee.emp_jDate.Value.Month == 12)
                    {
                        dec++;
                    }
                }

            }
            new_employees.Add(count_total + jan);
            new_employees.Add(count_total + feb + jan);
            new_employees.Add(count_total + mar + feb + jan);
            new_employees.Add(count_total + apr + mar + feb + jan);
            new_employees.Add(count_total + may + apr + mar + feb + jan);
            new_employees.Add(count_total + jun + may + apr + mar + feb + jan);
            new_employees.Add(count_total + jul + jun + may + apr + mar + feb + jan);
            new_employees.Add(count_total + aug + jul + jun + may + apr + mar + feb + jan);
            new_employees.Add(count_total + sept + aug + jul + jun + may + apr + mar + feb + jan);
            new_employees.Add(count_total + oct + sept + aug + jul + jun + may + apr + mar + feb + jan);
            new_employees.Add(count_total + nov + oct + sept + aug + jul + jun + may + apr + mar + feb + jan);
            new_employees.Add(count_total + dec + nov + oct + sept + aug + jul + jun + may + apr + mar + feb + jan);

            Models.Chart _chart = new Models.Chart();
            _chart.labels = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novemeber", "December" };
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "Employees",
                data = new_employees.ToArray(),
                borderColor = new string[] { "#800080" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddPosition(FormCollection formCollection)
        {
            if (Request != null)
            {
                var dp_id = Convert.ToInt32(formCollection["pos_dpt"]);
                var lvl_id = Convert.ToInt32(formCollection["lvl_id"]);
                var pos_desc = formCollection["pos_desc"];
                var pos_title = formCollection["pos_title"];


                tblPosition tblposition = new tblPosition();
                tblposition.lvl_id = lvl_id;
                tblposition.dp_id = dp_id;
                tblposition.pos_desc = pos_desc;
                tblposition.pos_title = pos_title;
                db.tblPositions.Add(tblposition);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult EditPosition(FormCollection formCollection)
        {
            if (Request != null)
            {
                var dp_id = Convert.ToInt32(formCollection["pos_dpt"]);
                var lvl_id = Convert.ToInt32(formCollection["lvl_id"]);
                var pos_desc = formCollection["pos_desc"];
                var pos_title = formCollection["pos_title"];
                var pos_id = Convert.ToInt32(formCollection["pos_id"]);

                tblPosition tblposition = db.tblPositions.Find(pos_id);
                tblposition.lvl_id = lvl_id;
                tblposition.dp_id = dp_id;
                tblposition.pos_desc = pos_desc;
                tblposition.pos_title = pos_title;
                db.Entry(tblposition).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeletePosition(FormCollection formCollection)
        {
            if (Request != null)
            {
                var pos_id = Convert.ToInt32(formCollection["pos_id"]);

                tblPosition tblposition = db.tblPositions.Find(pos_id);
                db.tblPositions.Remove(tblposition);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }


        [HttpPost]
        public ActionResult AddBranch(FormCollection formCollection)
        {
            if (Request != null)
            {
                var br_name = formCollection["br_name"];
                var br_address = formCollection["br_address"];
                var br_contact = formCollection["br_contact"];
                var br_desc = formCollection["br_desc"];
               

                tblBranch tblbranch = new tblBranch();
                tblbranch.br_name = br_name;
                tblbranch.br_address = br_address;
                tblbranch.br_contact = br_contact;
                tblbranch.br_descr = br_desc;
                db.tblBranches.Add(tblbranch);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult EditBranch(FormCollection formCollection)
        {
            if (Request != null)
            {
                var br_name = formCollection["br_name"];
                var br_address = formCollection["br_address"];
                var br_contact = formCollection["br_contact"];
                var br_desc = formCollection["br_desc"];
                var id = Convert.ToInt32(formCollection["br_id"]);


                tblBranch tblbranch = db.tblBranches.Find(id);
                tblbranch.br_name = br_name;
                tblbranch.br_address = br_address;
                tblbranch.br_contact = br_contact;
                tblbranch.br_descr = br_desc;
                db.Entry(tblbranch).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeleteBranch(FormCollection formCollection)
        {
            if (Request != null)
            {

                var id = Convert.ToInt32(formCollection["br_id"]);


                tblBranch tblbranch = db.tblBranches.Find(id);
                db.tblBranches.Remove(tblbranch);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddLevel(FormCollection formCollection)
        {
            if (Request != null)
            {
                var lvl_title = formCollection["lvl_title"];
                var lvl_desc = formCollection["lvl_desc"];

                tblJobLevel tbllevel = new tblJobLevel();
                tbllevel.lvl_title = lvl_title;
                tbllevel.lvl_desc = lvl_desc;
                db.tblJobLevels.Add(tbllevel);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult EditLevel(FormCollection formCollection)
        {
            if (Request != null)
            {
                var lvl_title = formCollection["lvl_title"];
                var lvl_desc = formCollection["lvl_desc"];
                var id = Convert.ToInt32(formCollection["lvl_id"]);

                tblJobLevel tbllevel = db.tblJobLevels.Find(id);
                tbllevel.lvl_title = lvl_title;
                tbllevel.lvl_desc = lvl_desc;
                db.Entry(tbllevel).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeleteLevel(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["lvl_id"]);

                tblJobLevel tbllevel = db.tblJobLevels.Find(id);
                db.tblJobLevels.Remove(tbllevel);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddDepartment(FormCollection formCollection)
        {
            if (Request != null)
            {
                var dpt_title = formCollection["dpt_title"];
                var dpt_desc = formCollection["dpt_desc"];

                tblDepartment tbldpt = new tblDepartment();
                tbldpt.dpt_name = dpt_title;
                tbldpt.dpt_desc = dpt_desc;
                db.tblDepartments.Add(tbldpt);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult EditDepartment(FormCollection formCollection)
        {
            if (Request != null)
            {
                var dpt_title = formCollection["dpt_title"];
                var dpt_desc = formCollection["dpt_desc"];
                var id = Convert.ToInt32(formCollection["dpt_id"]);

                tblDepartment tbldpt = db.tblDepartments.Find(id);
                tbldpt.dpt_name = dpt_title;
                tbldpt.dpt_desc = dpt_desc;
                db.Entry(tbldpt).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeleteDepartment(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["dpt_id"]);

                tblDepartment tbldpt = db.tblDepartments.Find(id);
                db.tblDepartments.Remove(tbldpt);
                db.SaveChanges();

                return RedirectToAction("Index", "Employee");

            }
            return RedirectToAction("Home", "Home");
        }

    }
}