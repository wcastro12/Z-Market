using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Z_Market.Models;

namespace Z_Market.Controllers
{
    public class CustumersController : Controller
    {
        private Z_MarketContext db = new Z_MarketContext();

        // GET: Custumers
        public ActionResult Index()
        {
            var custumers = db.Custumers.Include(c => c.DocumentType);
            return View(custumers.ToList());
        }

        // GET: Custumers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custumer custumer = db.Custumers.Find(id);
            if (custumer == null)
            {
                return HttpNotFound();
            }
            return View(custumer);
        }

        // GET: Custumers/Create
        public ActionResult Create()
        {
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes.OrderBy(c => c.Description), "DocumentTypeId", "Description");
            return View();
        }

        // POST: Custumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustumerId,Name,ContacFirsName,ContacLastName,Phone,Address,Email,DocumentTypeId,Document")] Custumer custumer)
        {
            if (ModelState.IsValid)
            {
                db.Custumers.Add(custumer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", custumer.DocumentTypeId);
            return View(custumer);
        }

        // GET: Custumers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custumer custumer = db.Custumers.Find(id);
            if (custumer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", custumer.DocumentTypeId);
            return View(custumer);
        }

        // POST: Custumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustumerId,Name,ContacFirsName,ContacLastName,Phone,Address,Email,DocumentTypeId,Document")] Custumer custumer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custumer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Description", custumer.DocumentTypeId);
            return View(custumer);
        }

        // GET: Custumers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Custumer custumer = db.Custumers.Find(id);
            if (custumer == null)
            {
                return HttpNotFound();
            }
            return View(custumer);
        }

        // POST: Custumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Custumer custumer = db.Custumers.Find(id);
            db.Custumers.Remove(custumer);
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
