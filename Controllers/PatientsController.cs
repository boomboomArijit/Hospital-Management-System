using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Controllers
{
   
    public class PatientsController : Controller
    {
        private HospitalDbContext db = new HospitalDbContext();

        // GET: Patients
        [Authorize]

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patients/Details/5

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        

        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Create([Bind(Include = "PatientID,PatientName,PatientAge,ContactNumber,,PatientEmailAddress,Password")] Patient patient)
        {
            if (db.Patients.Any(p => p.PatientEmailAddress == patient.PatientEmailAddress))
            {
                ViewBag.Email = true;
                return View(patient);
            }
            if (ModelState.IsValid)
            {
               
                db.Patients.Add(patient);
                var a=db.SaveChanges();
                if (a > 0)
                {
                    return RedirectToAction("Login", "Patients");
                }
                else
                {
                    return View();
                }
            }


            return View();
        }

        // GET: Patients/Edit/5
        [Authorize]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
        

        public ActionResult Bill(int? DoctorId, int? patientId)
        {
            if (DoctorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patient = db.Patients.Find(patientId);
            var doctor = db.Doctors.Find(DoctorId);
            if (patient == null)
            {
                return HttpNotFound();
            }
            Billing bill = new Billing()
            {
                PatientName = patient.PatientName,
                PatientAge = patient.PatientAge,
                DoctorName = doctor.DoctorName,
                TotalBill = doctor.DoctorFees
            };
            bill.patient = patient;
            bill.doctor = doctor;
            db.Billings.Add(bill);
            db.SaveChanges();
            var bills = db.Billings.Include(p=>p.patient).Include(d=>d.doctor).First(b => b.BillID == bill.BillID);
            return View(bills);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.



        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Edit([Bind(Include = "PatientID,PatientName,PatientAge,ContactNumber,,PatientEmailAddress,Password")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5


        [Authorize]

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Patient p = db.Patients.FirstOrDefault(x => x.PatientName == name);
            if (name == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Patients/Delete/5


        [Authorize]

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string name)
        { 
            Patient p = db.Patients.FirstOrDefault(x => x.PatientName == name);
            var bill=db.Billings.Where(b=>b.PatientName==name);
            db.Billings.RemoveRange(bill);
            db.Patients.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       // [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Login(Patient log)
        {
          var Patient=  db.Patients.FirstOrDefault(x=>x.PatientEmailAddress ==log.PatientEmailAddress && x.Password==log.Password);
            if (Patient !=null)
            {
                ViewBag.Flag = false;
                return RedirectToAction("Begin", "Patients", Patient);
                //change the detaILS
            }
            else
            {
                ViewBag.Flag = true;
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        
        public ActionResult Begin(Patient patient)
        {
            ViewBag.Patient = patient.PatientID;
            return View(db.Doctors);
        }
        public ActionResult FinalBill()
        {
            return View(db.Billings);
        }
      
    }
}