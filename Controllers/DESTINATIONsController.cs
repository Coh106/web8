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
    public class DESTINATIONsController : Controller
    {
        private ROUTEEntities db = new ROUTEEntities();

        // GET: DESTINATIONs
        public ActionResult Index()
        {
            return View(db.DESTINATIONS.ToList());
        }

        // GET: DESTINATIONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESTINATION dESTINATION = db.DESTINATIONS.Find(id);
            if (dESTINATION == null)
            {
                return HttpNotFound();
            }
            return View(dESTINATION);
        }

        // GET: DESTINATIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DESTINATIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DestinationID,Name,DestinationCode")] DESTINATION dESTINATION)
        {
            if (ModelState.IsValid)
            {
                db.DESTINATIONS.Add(dESTINATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dESTINATION);
        }

        // GET: DESTINATIONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESTINATION dESTINATION = db.DESTINATIONS.Find(id);
            if (dESTINATION == null)
            {
                return HttpNotFound();
            }
            return View(dESTINATION);
        }

        // POST: DESTINATIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DestinationID,Name,DestinationCode")] DESTINATION dESTINATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dESTINATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dESTINATION);
        }

        // GET: DESTINATIONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DESTINATION dESTINATION = db.DESTINATIONS.Find(id);
            if (dESTINATION == null)
            {
                return HttpNotFound();
            }
            return View(dESTINATION);
        }

        // POST: DESTINATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DESTINATION dESTINATION = db.DESTINATIONS.Find(id);
            db.DESTINATIONS.Remove(dESTINATION);
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
