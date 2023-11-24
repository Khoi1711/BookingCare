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
    public class StaffSystemsController : Controller
    {
        private BookingCareEntities1 db = new BookingCareEntities1();

        // GET: StaffSystems
        public ActionResult Index()
        {
            var staffSystems = db.StaffSystems.Include(s => s.Role);
            return View(staffSystems.ToList());
        }

        // GET: StaffSystems/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffSystem staffSystem = db.StaffSystems.Find(id);
            if (staffSystem == null)
            {
                return HttpNotFound();
            }
            return View(staffSystem);
        }

        // GET: StaffSystems/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: StaffSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,StaffName,RoleID,UserName,Password")] StaffSystem staffSystem)
        {
            if (ModelState.IsValid)
            {
                db.StaffSystems.Add(staffSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", staffSystem.RoleID);
            return View(staffSystem);
        }

        // GET: StaffSystems/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffSystem staffSystem = db.StaffSystems.Find(id);
            if (staffSystem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", staffSystem.RoleID);
            return View(staffSystem);
        }

        // POST: StaffSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,StaffName,RoleID,UserName,Password")] StaffSystem staffSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", staffSystem.RoleID);
            return View(staffSystem);
        }

        // GET: StaffSystems/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffSystem staffSystem = db.StaffSystems.Find(id);
            if (staffSystem == null)
            {
                return HttpNotFound();
            }
            return View(staffSystem);
        }

        // POST: StaffSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StaffSystem staffSystem = db.StaffSystems.Find(id);
            db.StaffSystems.Remove(staffSystem);
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
