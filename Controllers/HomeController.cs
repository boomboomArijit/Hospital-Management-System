using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hospital_Management_System.Controllers
{
    
    public class HomeController : Controller
    {
        HospitalDbContext db = new HospitalDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminCred adminCred)
        {
            if(adminCred.Username == null)
            {
                ViewBag.Username = true;
            }
            if(adminCred.Password == null)
            {
                ViewBag.Password = true;
            }
            var admin = db.AdminCreds.Where(m => m.Username == adminCred.Username && m.Password == adminCred.Password).FirstOrDefault();
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(adminCred.Username, false);

                return RedirectToAction("Index", "Doctors1");
            }
            else
            {
                ViewBag.WrongCred = true;

                return View();
            }
        }

        public ActionResult Login(Patient patient)
        {

            var p = db.Patients.Where(m => m.PatientEmailAddress == patient.PatientEmailAddress && m.Password == patient.Password).FirstOrDefault();
            if (p != null)
            {
                FormsAuthentication.SetAuthCookie(patient.PatientEmailAddress, false);

                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }

              
        }
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");

        }


    }

}