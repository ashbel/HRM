using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;
using PagedList;

namespace Hrm_System.Controllers
{
    [CustomAuthorize]
    public class TrainingController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Training
        public ActionResult Index(int page = 1)
        {
            var tblTrainings = db.tblTrainings.Include(t => t.tblCours).Include(t => t.tblEmployee);
            var course = from c in db.tblCourses  select c;
            var training_sessions = from c in db.tblTrainingSessions select c;
            var active_employees = db.tblEmployees.Where(c => c.tblEmployeeStatu.empst_title == "Active");
            ViewBag.Departments = db.tblDepartments;
            ViewBag.Positions = db.tblPositions;
            ViewBag.Branches = db.tblBranches;
            ViewBag.Employees = active_employees;
            ViewBag.TrainingSessions = training_sessions;
            ViewBag.Courses = course;
            ViewBag.CourseTypes = db.tblCourseTypes;
            return View(tblTrainings.OrderBy(c => c.tr_id).ToPagedList(page, 50));
        }


         public ActionResult AddSession(FormCollection formCollection)
        {
            if (Request != null)
            {
                var name = formCollection["session_name"];
                var course = Convert.ToInt32(formCollection["course"]);
                var comments = formCollection["comments"];
                var sdate = formCollection["sdate"];
                var edate = formCollection["edate"];
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

                tblTrainingSession tblsession = new tblTrainingSession();
                tblsession.course_id = course;
                tblsession.tr_edate = edu_edate;
                tblsession.tr_sdate = edu_sdate;
                tblsession.tr_sess_desc = comments;
                tblsession.tr_sess_name = name;

                if (edu_sdate > DateTime.Now) { tblsession.tr_sess_status = "SCHEDULED"; }
                if (edu_sdate < DateTime.Now && edu_edate > DateTime.Now) { tblsession.tr_sess_status = "ACTIVE"; }
                if (edu_edate < DateTime.Now) { tblsession.tr_sess_status = "EXPIRED"; }


                db.tblTrainingSessions.Add(tblsession);
                db.SaveChanges();

                return RedirectToAction("Index", "Training");
            }
            return View();
        }

        public ActionResult EnrollUsers(FormCollection formCollection)
        {
            if (Request != null)
            {
                var employee = formCollection["emp_id"];
                var department = formCollection["dpt_id"];
                var position = formCollection["pos_id"];
                var branch = formCollection["br_id"];
                var course = Convert.ToInt32(formCollection["course"]);
                var session = Convert.ToInt32(formCollection["session"]);
                tblTrainingSession tblsession = db.tblTrainingSessions.Find(session);

                if (employee!=null)
                {
                    string[] employees = null;
                    try
                    {
                      employees=  employee.Split(',');
                    }
                    catch { employees[0] = employee; }

                    foreach(var emp_id in employees)
                    {
                       tblTraining tbltraining = new tblTraining();
                        tbltraining.course_id = course;
                        tbltraining.emp_id = Convert.ToInt32(emp_id);
                        tbltraining.tr_sess_id = session;
                        tbltraining.tr_status = tblsession.tr_sess_status;
                        tbltraining.tr_sdate = tblsession.tr_sdate;
                        tbltraining.tr_edate = tblsession.tr_edate;
                        tbltraining.tr_comments = tblsession.tr_sess_desc;
                       db.tblTrainings.Add(tbltraining);
                       db.SaveChanges();
                    }
                }
                if (department != null)
                {
                    string[] departments = null;
                    try
                    {
                        departments = department.Split(',');
                    } catch { departments[0] = department; }

                    foreach (var dpt in departments)
                    {
                        int dpt_id = Convert.ToInt32(dpt);

                        var employees = from c in db.tblEmployees where c.emp_dpt == dpt_id select c.emp_id;

                        foreach (var emp_id in employees.ToList())
                        {
                            tblTraining tbltraining = new tblTraining();
                            tbltraining.course_id = course;
                            tbltraining.emp_id = Convert.ToInt32(emp_id);
                            tbltraining.tr_sess_id = session;
                            tbltraining.tr_status = tblsession.tr_sess_status;
                            tbltraining.tr_sdate = tblsession.tr_sdate;
                            tbltraining.tr_edate = tblsession.tr_edate;
                            tbltraining.tr_comments = tblsession.tr_sess_desc;
                            db.tblTrainings.Add(tbltraining);
                            db.SaveChanges();
                        }
                    }
                }
                if (position != null)
                {
                    string[] positions = null;
                    try
                    {
                        positions = position.Split(',');
                    }
                    catch { positions[0] = position; }

                    foreach (var pos in positions)
                    {
                        int pos_id = Convert.ToInt32(pos);

                        var employees = from c in db.tblEmployees where c.emp_pos_id == pos_id select c.emp_id;

                        foreach (var emp_id in employees.ToList())
                        {
                            tblTraining tbltraining = new tblTraining();
                            tbltraining.course_id = course;
                            tbltraining.emp_id = Convert.ToInt32(emp_id);
                            tbltraining.tr_sess_id = session;
                            tbltraining.tr_status = tblsession.tr_sess_status;
                            tbltraining.tr_sdate = tblsession.tr_sdate;
                            tbltraining.tr_edate = tblsession.tr_edate;
                            tbltraining.tr_comments = tblsession.tr_sess_desc;
                            db.tblTrainings.Add(tbltraining);
                            db.SaveChanges();
                        }
                    }
                }
                if (branch != null)
                {
                    string[] branches = null;
                    try
                    {
                        branches = branch.Split(',');
                    }
                    catch { branches[0] = branch; }

                    foreach (var br in branches)
                    {
                        int br_id = Convert.ToInt32(br);

                        var employees = from c in db.tblEmployees where c.emp_branch == br_id select c.emp_id;

                        foreach (var emp_id in employees.ToList())
                        {
                            tblTraining tbltraining = new tblTraining();
                            tbltraining.course_id = course;
                            tbltraining.emp_id = Convert.ToInt32(emp_id);
                            tbltraining.tr_sess_id = session;
                            tbltraining.tr_status = tblsession.tr_sess_status;
                            tbltraining.tr_sdate = tblsession.tr_sdate;
                            tbltraining.tr_edate = tblsession.tr_edate;
                            tbltraining.tr_comments = tblsession.tr_sess_desc;
                            db.tblTrainings.Add(tbltraining);
                            db.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index", "Training");
            }
            return View();
        }

        // GET: Training/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTraining tblTraining = db.tblTrainings.Find(id);
            if (tblTraining == null)
            {
                return HttpNotFound();
            }
            return View(tblTraining);
        }

        // GET: Training/Create
        public ActionResult Create()
        {
            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm");
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name");
            return View();
        }

        // POST: Training/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tr_id,emp_id,course_id,tr_sdate,tr_edate,tr_status,tr_score,tr_comments")] tblTraining tblTraining)
        {
            if (ModelState.IsValid)
            {
                db.tblTrainings.Add(tblTraining);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm", tblTraining.course_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblTraining.emp_id);
            return View(tblTraining);
        }

        // GET: Training/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTraining tblTraining = db.tblTrainings.Find(id);
            if (tblTraining == null)
            {
                return HttpNotFound();
            }
            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm", tblTraining.course_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblTraining.emp_id);
            return View(tblTraining);
        }

        // POST: Training/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tr_id,emp_id,course_id,tr_sdate,tr_edate,tr_status,tr_score,tr_comments")] tblTraining tblTraining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTraining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.course_id = new SelectList(db.tblCourses, "course_id", "course_nm", tblTraining.course_id);
            ViewBag.emp_id = new SelectList(db.tblEmployees, "emp_id", "emp_name", tblTraining.emp_id);
            return View(tblTraining);
        }

        // GET: Training/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTraining tblTraining = db.tblTrainings.Find(id);
            if (tblTraining == null)
            {
                return HttpNotFound();
            }
            return View(tblTraining);
        }

        // POST: Training/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTraining tblTraining = db.tblTrainings.Find(id);
            db.tblTrainings.Remove(tblTraining);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
