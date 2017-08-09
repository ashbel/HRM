using Hrm_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hrm_System.Controllers
{
    public class HomeController : Controller
    {
        private HRMEntities db = new HRMEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize]
        public ActionResult Home()
        {
            tblUser tblusers = db.tblUsers.FirstOrDefault(c => c.user_name == User.Identity.Name);
            ViewBag.Name = tblusers.tblEmployee.emp_name + " " + tblusers.tblEmployee.emp_lname;
            
            if (tblusers.tblEmployee.img_id == null)
            {
                var picture = db.tblImages.Find(1);
                ViewBag.url = null;
                Session["UserImage"] = null;
            }
            else
            {
                Session["UserImage"] = Convert.ToBase64String(tblusers.tblEmployee.tblImage.img_data);
                ViewBag.url = tblusers.tblEmployee.tblImage.img_data;
            }
            return View();
        }
        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult LoginModal(string uname, string psw, string returnUrl)
        {
            string password = "";
            if (!String.IsNullOrEmpty(psw)) { password = psw; }
            string username = uname;

            bool userValid = db.tblUsers.Any(user => user.user_name == username && user.user_password == password);
            if (userValid)
            {
                int? usrId = db.tblUsers.SingleOrDefault(c => c.user_name == username).user_id;
                tblUser tblusers = db.tblUsers.Find(usrId);
                FormsAuthentication.SetAuthCookie(username, false);
                Session["Name"] = tblusers.tblEmployee.emp_name + " " + tblusers.tblEmployee.emp_lname;
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Home", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }
    }
}
