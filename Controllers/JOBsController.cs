using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ROUTEJOBS1.Models;

namespace ROUTEJOBS1.Controllers
{
    public class JOBsController : Controller
    {
        private ROUTEEntities db = new ROUTEEntities();

        // GET: JOBs
        public ActionResult Index()
        {
            var jOBS = db.JOBS.Include(j => j.DESTINATION).Include(j => j.EMPLOYEE).Include(j => j.Warehouse);
            return View(jOBS.ToList());
        }

        // GET: JOBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOB jOB = db.JOBS.Find(id);
            if (jOB == null)
            {
                return HttpNotFound();
            }
            return View(jOB);
        }

        // GET: JOBs/Create
        public ActionResult Create()
        {
            ViewBag.DestinationID = new SelectList(db.DESTINATIONS, "DestinationID", "Name");
            ViewBag.EmployeeID = new SelectList(db.EMPLOYEES, "EmployeeID", "FirstName");
            ViewBag.WarehouseID = new SelectList(db.WAREHOUSES, "WarehouseID", "Name");
            return View();
        }

        // POST: JOBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeID,DateJob,DestinationID,WarehouseID")] JOB jOB)
        {
            if (ModelState.IsValid)
            {
                db.JOBS.Add(jOB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinationID = new SelectList(db.DESTINATIONS, "DestinationID", "Name", jOB.DestinationID);
            ViewBag.EmployeeID = new SelectList(db.EMPLOYEES, "EmployeeID", "FirstName", jOB.EmployeeID);
            ViewBag.WarehouseID = new SelectList(db.WAREHOUSES, "WarehouseID", "Name", jOB.WarehouseID);
            return View(jOB);
        }

        // GET: JOBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOB jOB = db.JOBS.Find(id);
            if (jOB == null)
            {
                return HttpNotFound();
            }
            ViewBag.DestinationID = new SelectList(db.DESTINATIONS, "DestinationID", "Name", jOB.DestinationID);
            ViewBag.EmployeeID = new SelectList(db.EMPLOYEES, "EmployeeID", "FirstName", jOB.EmployeeID);
            ViewBag.WarehouseID = new SelectList(db.WAREHOUSES, "WarehouseID", "Name", jOB.WarehouseID);
            return View(jOB);
        }

        // POST: JOBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,DateJob,DestinationID,WarehouseID")] JOB jOB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jOB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DestinationID = new SelectList(db.DESTINATIONS, "DestinationID", "Name", jOB.DestinationID);
            ViewBag.EmployeeID = new SelectList(db.EMPLOYEES, "EmployeeID", "FirstName", jOB.EmployeeID);
            ViewBag.WarehouseID = new SelectList(db.WAREHOUSES, "WarehouseID", "Name", jOB.WarehouseID);
            return View(jOB);
        }

        // GET: JOBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOB jOB = db.JOBS.Find(id);
            if (jOB == null)
            {
                return HttpNotFound();
            }
            return View(jOB);
        }

        // POST: JOBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JOB jOB = db.JOBS.Find(id);
            db.JOBS.Remove(jOB);
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
