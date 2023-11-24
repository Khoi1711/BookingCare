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
    public class AdminSystemsController : Controller
    {
        private BookingCareEntities1 db = new BookingCareEntities1();

        // GET: AdminSystems
        public ActionResult Index()
        {
            var adminSystems = db.AdminSystems.Include(a => a.Role);
            return View(adminSystems.ToList());
        }

        // GET: AdminSystems/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminSystem adminSystem = db.AdminSystems.Find(id);
            if (adminSystem == null)
            {
                return HttpNotFound();
            }
            return View(adminSystem);
        }

        // GET: AdminSystems/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }

        // POST: AdminSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,RoleID")] AdminSystem adminSystem)
        {
            if (ModelState.IsValid)
            {
                db.AdminSystems.Add(adminSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", adminSystem.RoleID);
            return View(adminSystem);
        }

        // GET: AdminSystems/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminSystem adminSystem = db.AdminSystems.Find(id);
            if (adminSystem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", adminSystem.RoleID);
            return View(adminSystem);
        }

        // POST: AdminSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,RoleID")] AdminSystem adminSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", adminSystem.RoleID);
            return View(adminSystem);
        }

        // GET: AdminSystems/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminSystem adminSystem = db.AdminSystems.Find(id);
            if (adminSystem == null)
            {
                return HttpNotFound();
            }
            return View(adminSystem);
        }

        // POST: AdminSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminSystem adminSystem = db.AdminSystems.Find(id);
            db.AdminSystems.Remove(adminSystem);
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
