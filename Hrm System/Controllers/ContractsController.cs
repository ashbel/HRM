using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hrm_System.Models;


namespace Hrm_System.Controllers
{
    [CustomAuthorize]
    public class ContractsController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Contracts
        public ActionResult Index()
        {
            ViewBag.ContractTypes = db.tblContractTypes;
            ViewBag.ContractState = db.tblContractStates;
            ViewBag.Branch = db.tblBranches;
            ViewBag.Department = db.tblDepartments;
            ViewBag.Position = db.tblPositions;
            ViewBag.Employees = db.tblEmployees;
            ViewBag.ActiveContracts = db.tblContracts.Where(c => c.tblContractState.cntrct_state == "ACTIVE").Count();
            ViewBag.ActiveContracts = db.tblContracts.Where(c => c.tblContractState.cntrct_state == "OFFER").Count();
            ViewBag.ActiveContracts = db.tblContracts.Where(c => c.tblContractState.cntrct_state == "SIGNED").Count();
            var tblContracts = db.tblContracts.Include(t => t.tblEmployee).Include(t => t.tblContractType).Include(t => t.tblContractState).Include(t => t.tblBranch).Include(t => t.tblDepartment).Include(t => t.tblPosition);
            return View(tblContracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContract tblContract = db.tblContracts.Find(id);
            if (tblContract == null)
            {
                return HttpNotFound();
            }
            return View(tblContract);
        }

        [HttpPost]
        public ActionResult AddContract(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["emp_id"]);
                var cntrct_title = formCollection["cntrct_title"];
                var cntrct_typ = Convert.ToInt32(formCollection["cntrct_type"]);
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
                tblcontract.cntcrt_typ_id = cntrct_typ;
                db.tblContracts.Add(tblcontract);
                db.SaveChanges();

                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult EditContract(FormCollection formCollection)
        {
            if (Request != null)
            {
                var emp_id = Convert.ToInt32(formCollection["emp_id"]);
                var cntrct_id = Convert.ToInt32(formCollection["cntrct_id"]);
                var cntrct_title = formCollection["cntrct_title"];
                var cntrct_state = Convert.ToInt32(formCollection["cntrct_state"]);
                var cntrct_typ = Convert.ToInt32(formCollection["cntrct_type"]);
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

                tblContract tblcontract = db.tblContracts.Find(cntrct_id);
                tblcontract.emp_id = emp_id;
                tblcontract.cntrct_desc = cntrct_desc;
                tblcontract.cntrct_edate = cs_edate;
                tblcontract.cntrct_sdate = cs_sdate;
                tblcontract.cntrct_title = cntrct_title;
                tblcontract.cntrct_state = cntrct_state;
                tblcontract.create_date = DateTime.Now;
                tblcontract.dpt_id = cntrct_dpt;
                tblcontract.pos_id = cntrct_pos;
                tblcontract.br_id = cntrct_br;
                tblcontract.cntcrt_typ_id = cntrct_typ;
                db.Entry(tblcontract).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddType(FormCollection formCollection)
        {
            if (Request != null)
            {
                var cntrct_title = formCollection["type_title"];
                var cntrct_desc = formCollection["type_desc"];

                tblContractType tbltype = new tblContractType();
                tbltype.cntrct_desc = cntrct_desc;
                tbltype.cntrct_typ = cntrct_title;
                db.tblContractTypes.Add(tbltype);
                db.SaveChanges();

                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult AddState(FormCollection formCollection)
        {
            if (Request != null)
            {
                var cntrct_title = formCollection["state_title"];
                var cntrct_desc = formCollection["state_desc"];

                tblContractState tblstate = new tblContractState();
                tblstate.cntrct_st_desc = cntrct_desc;
                tblstate.cntrct_state = cntrct_title;
                db.tblContractStates.Add(tblstate);
                db.SaveChanges();

                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult EditState(FormCollection formCollection)
        {
            if (Request != null)
            {
                var cntrct_title = formCollection["state_title"];
                var cntrct_desc = formCollection["state_desc"];
                var id = Convert.ToInt32(formCollection["state_id"]);

                tblContractState tblstate = db.tblContractStates.Find(id);
                tblstate.cntrct_st_desc = cntrct_desc;
                tblstate.cntrct_state = cntrct_title;
                db.Entry(tblstate).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult EditType(FormCollection formCollection)
        {
            if (Request != null)
            {
                var cntrct_title = formCollection["type_title"];
                var cntrct_desc = formCollection["type_desc"];
                var id = Convert.ToInt32(formCollection["type_id"]);

                tblContractType tbltype = db.tblContractTypes.Find(id);
                tbltype.cntrct_desc = cntrct_desc;
                tbltype.cntrct_typ = cntrct_title;
                db.Entry(tbltype).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeleteContract(FormCollection formCollection)
        {
            if (Request != null)
            {
                var cntrct_id = Convert.ToInt32(formCollection["cntrct_id"]);
                tblContract tblcontract = db.tblContracts.Find(cntrct_id);
                db.tblContracts.Remove(tblcontract);
                db.SaveChanges();
                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeleteState(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["state_id"]);
                tblContractState tblstate = db.tblContractStates.Find(id);
                db.tblContractStates.Remove(tblstate);
                db.SaveChanges();
                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        [HttpPost]
        public ActionResult DeleteType(FormCollection formCollection)
        {
            if (Request != null)
            {
                var id = Convert.ToInt32(formCollection["type_id"]);
                tblContractType tbltype = db.tblContractTypes.Find(id);
                db.tblContractTypes.Remove(tbltype);
                db.SaveChanges();
                return RedirectToAction("Index", "Contracts");

            }
            return RedirectToAction("Home", "Home");
        }

        public JsonResult BarChartData()
        {
            Models.Chart _chart = new Models.Chart();
            _chart.labels = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novemeber", "December" };
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "Current Year",
                data = new int[] { 28, 48, 40, 19, 86, 27, 90, 20, 45, 65, 34, 22 },
                backgroundColor = new string[] { "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)" },
                borderColor = new string[] { "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)", "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DonutChartData()
        {
            Models.Chart _chart = new Models.Chart();
            _chart.labels = new string[] { "January", "February", "March", "April", "May", "June", "July" };
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "Current Year",
                data = new int[] { 28, 48, 40, 19, 86, 27, 90 },
                backgroundColor = new string[] { "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)", "rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)", "rgba(255, 206, 86, 0.2)", "rgba(75, 192, 192, 0.2)", "rgba(153, 102, 255, 0.2)", "rgba(255, 159, 64, 0.2)" },
                borderColor = new string[] { "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)", "rgba(255,99,132,1)", "rgba(54, 162, 235, 1)", "rgba(255, 206, 86, 1)", "rgba(75, 192, 192, 1)", "rgba(153, 102, 255, 1)", "rgba(255, 159, 64, 1)" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LineChartData()
        {
            Models.Chart _chart = new Models.Chart();
            _chart.labels = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novemeber", "December" };
            _chart.datasets = new List<Datasets>();
            List<Datasets> _dataSet = new List<Datasets>();
            _dataSet.Add(new Datasets()
            {
                label = "Current Year",
                data = new int[] { 28, 48, 40, 19, 86, 27, 90, 20, 45, 65, 34, 22 },
                borderColor = new string[] { "#800080" },
                borderWidth = "1"
            });
            _chart.datasets = _dataSet;
            return Json(_chart, JsonRequestBehavior.AllowGet);
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
