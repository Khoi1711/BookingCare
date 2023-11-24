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
    public class SpeciatiesController : Controller
    {
        private BookingCareEntities1 db = new BookingCareEntities1();

        // GET: Speciaties
        public ActionResult Index()
        {
            return View(db.Speciaties.ToList());
        }

        // GET: Speciaties/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciaty speciaty = db.Speciaties.Find(id);
            if (speciaty == null)
            {
                return HttpNotFound();
            }
            return View(speciaty);
        }

        // GET: Speciaties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Speciaties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpeciatyID,SpeciatyName")] Speciaty speciaty)
        {
            if (ModelState.IsValid)
            {
                db.Speciaties.Add(speciaty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speciaty);
        }

        // GET: Speciaties/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciaty speciaty = db.Speciaties.Find(id);
            if (speciaty == null)
            {
                return HttpNotFound();
            }
            return View(speciaty);
        }

        // POST: Speciaties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpeciatyID,SpeciatyName")] Speciaty speciaty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speciaty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speciaty);
        }

        // GET: Speciaties/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciaty speciaty = db.Speciaties.Find(id);
            if (speciaty == null)
            {
                return HttpNotFound();
            }
            return View(speciaty);
        }

        // POST: Speciaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Speciaty speciaty = db.Speciaties.Find(id);
            db.Speciaties.Remove(speciaty);
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
