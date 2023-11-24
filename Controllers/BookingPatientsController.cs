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
    public class BookingPatientsController : Controller
    {
        private BookingCareEntities1 db = new BookingCareEntities1();

        // GET: BookingPatients
        public ActionResult Index()
        {
            var bookingPatients = db.BookingPatients.Include(b => b.Patient).Include(b => b.Schedule).Include(b => b.Status);
            return View(bookingPatients.ToList());
        }

        // GET: BookingPatients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingPatient bookingPatient = db.BookingPatients.Find(id);
            if (bookingPatient == null)
            {
                return HttpNotFound();
            }
            return View(bookingPatient);
        }

        // GET: BookingPatients/Create
        public ActionResult Create()
        {
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "RoleID");
            ViewBag.ScheduleID = new SelectList(db.Schedules, "ScheduleID", "DoctorID");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName");
            return View();
        }

        // POST: BookingPatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,ScheduleID,DateTime,StatusID")] BookingPatient bookingPatient)
        {
            if (ModelState.IsValid)
            {
                db.BookingPatients.Add(bookingPatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "RoleID", bookingPatient.PatientID);
            ViewBag.ScheduleID = new SelectList(db.Schedules, "ScheduleID", "DoctorID", bookingPatient.ScheduleID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", bookingPatient.StatusID);
            return View(bookingPatient);
        }

        // GET: BookingPatients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingPatient bookingPatient = db.BookingPatients.Find(id);
            if (bookingPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "RoleID", bookingPatient.PatientID);
            ViewBag.ScheduleID = new SelectList(db.Schedules, "ScheduleID", "DoctorID", bookingPatient.ScheduleID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", bookingPatient.StatusID);
            return View(bookingPatient);
        }

        // POST: BookingPatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,ScheduleID,DateTime,StatusID")] BookingPatient bookingPatient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "RoleID", bookingPatient.PatientID);
            ViewBag.ScheduleID = new SelectList(db.Schedules, "ScheduleID", "DoctorID", bookingPatient.ScheduleID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "StatusName", bookingPatient.StatusID);
            return View(bookingPatient);
        }

        // GET: BookingPatients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingPatient bookingPatient = db.BookingPatients.Find(id);
            if (bookingPatient == null)
            {
                return HttpNotFound();
            }
            return View(bookingPatient);
        }

        // POST: BookingPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BookingPatient bookingPatient = db.BookingPatients.Find(id);
            db.BookingPatients.Remove(bookingPatient);
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
