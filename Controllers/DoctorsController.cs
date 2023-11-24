using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DoctorsController : Controller
    {
        private BookingCareEntities1 db = new BookingCareEntities1();

        // GET: Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Hospital).Include(d => d.Price).Include(d => d.Speciaty);
            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName");
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceName");
            ViewBag.SpeciatyID = new SelectList(db.Speciaties, "SpeciatyID", "SpeciatyName");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorID,RoleID,HospitalID,SpeciatyID,PriceID,UserName,Password,Name,Gender,Birthday,PhoneNumber")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", doctor.HospitalID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceName", doctor.PriceID);
            ViewBag.SpeciatyID = new SelectList(db.Speciaties, "SpeciatyID", "SpeciatyName", doctor.SpeciatyID);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", doctor.HospitalID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceName", doctor.PriceID);
            ViewBag.SpeciatyID = new SelectList(db.Speciaties, "SpeciatyID", "SpeciatyName", doctor.SpeciatyID);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorID,RoleID,HospitalID,SpeciatyID,PriceID,UserName,Password,Name,Gender,Birthday,PhoneNumber")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", doctor.HospitalID);
            ViewBag.PriceID = new SelectList(db.Prices, "PriceID", "PriceName", doctor.PriceID);
            ViewBag.SpeciatyID = new SelectList(db.Speciaties, "SpeciatyID", "SpeciatyName", doctor.SpeciatyID);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
