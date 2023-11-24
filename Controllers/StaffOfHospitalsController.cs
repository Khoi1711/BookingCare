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
    public class StaffOfHospitalsController : Controller
    {
        private BookingCareEntities1 db = new BookingCareEntities1();

        // GET: StaffOfHospitals
        public ActionResult Index()
        {
            var staffOfHospitals = db.StaffOfHospitals.Include(s => s.Hospital);
            return View(staffOfHospitals.ToList());
        }

        // GET: StaffOfHospitals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffOfHospital staffOfHospital = db.StaffOfHospitals.Find(id);
            if (staffOfHospital == null)
            {
                return HttpNotFound();
            }
            return View(staffOfHospital);
        }

        // GET: StaffOfHospitals/Create
        public ActionResult Create()
        {
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName");
            return View();
        }

        // POST: StaffOfHospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffHId,StaffHName,UserName,Password,HospitalID")] StaffOfHospital staffOfHospital)
        {
            if (ModelState.IsValid)
            {
                db.StaffOfHospitals.Add(staffOfHospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", staffOfHospital.HospitalID);
            return View(staffOfHospital);
        }

        // GET: StaffOfHospitals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffOfHospital staffOfHospital = db.StaffOfHospitals.Find(id);
            if (staffOfHospital == null)
            {
                return HttpNotFound();
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", staffOfHospital.HospitalID);
            return View(staffOfHospital);
        }

        // POST: StaffOfHospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffHId,StaffHName,UserName,Password,HospitalID")] StaffOfHospital staffOfHospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffOfHospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", staffOfHospital.HospitalID);
            return View(staffOfHospital);
        }

        // GET: StaffOfHospitals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffOfHospital staffOfHospital = db.StaffOfHospitals.Find(id);
            if (staffOfHospital == null)
            {
                return HttpNotFound();
            }
            return View(staffOfHospital);
        }

        // POST: StaffOfHospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StaffOfHospital staffOfHospital = db.StaffOfHospitals.Find(id);
            db.StaffOfHospitals.Remove(staffOfHospital);
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
