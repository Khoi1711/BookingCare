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
    public class AdminOfHospitalsController : Controller
    {
        private BookingCareEntities1 db = new BookingCareEntities1();

        // GET: AdminOfHospitals
        public ActionResult Index()
        {
            var adminOfHospitals = db.AdminOfHospitals.Include(a => a.Hospital).Include(a => a.Role);
            return View(adminOfHospitals.ToList());
        }

        // GET: AdminOfHospitals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOfHospital adminOfHospital = db.AdminOfHospitals.Find(id);
            if (adminOfHospital == null)
            {
                return HttpNotFound();
            }
            return View(adminOfHospital);
        }

        // GET: AdminOfHospitals/Create
        public ActionResult Create()
        {
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName");
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: AdminOfHospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,RoleID,HospitalID,UserName,Password,Token")] AdminOfHospital adminOfHospital)
        {
            if (ModelState.IsValid)
            {
                db.AdminOfHospitals.Add(adminOfHospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", adminOfHospital.HospitalID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", adminOfHospital.RoleID);
            return View(adminOfHospital);
        }

        // GET: AdminOfHospitals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOfHospital adminOfHospital = db.AdminOfHospitals.Find(id);
            if (adminOfHospital == null)
            {
                return HttpNotFound();
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", adminOfHospital.HospitalID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", adminOfHospital.RoleID);
            return View(adminOfHospital);
        }

        // POST: AdminOfHospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminID,RoleID,HospitalID,UserName,Password,Token")] AdminOfHospital adminOfHospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminOfHospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HospitalID = new SelectList(db.Hospitals, "HospitalID", "HospitalName", adminOfHospital.HospitalID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", adminOfHospital.RoleID);
            return View(adminOfHospital);
        }

        // GET: AdminOfHospitals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminOfHospital adminOfHospital = db.AdminOfHospitals.Find(id);
            if (adminOfHospital == null)
            {
                return HttpNotFound();
            }
            return View(adminOfHospital);
        }

        // POST: AdminOfHospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminOfHospital adminOfHospital = db.AdminOfHospitals.Find(id);
            db.AdminOfHospitals.Remove(adminOfHospital);
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
