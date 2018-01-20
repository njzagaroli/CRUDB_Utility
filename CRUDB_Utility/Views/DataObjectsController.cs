using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDB_Utility.Data;
using CRUDB_Utility.Domain;

namespace CRUDB_Utility.Views
{
    public class DataObjectsController : Controller
    {
        private CRUModelContext db = new CRUModelContext();

        // GET: DataObjects
        public ActionResult Index()
        {
            return View(db.DataObjects.ToList());
        }

        // GET: DataObjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataObject dataObject = db.DataObjects.Find(id);
            if (dataObject == null)
            {
                return HttpNotFound();
            }
            return View(dataObject);
        }

        // GET: DataObjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DataObjectID,Name,PhysicalName,Description,PD_INS_Date,PD_INS_By,PD_UPD_Date,PD_UPD_By")] DataObject dataObject)
        {
            if (ModelState.IsValid)
            {
                db.DataObjects.Add(dataObject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataObject);
        }

        // GET: DataObjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataObject dataObject = db.DataObjects.Find(id);
            if (dataObject == null)
            {
                return HttpNotFound();
            }
            return View(dataObject);
        }

        // POST: DataObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DataObjectID,Name,PhysicalName,Description,PD_INS_Date,PD_INS_By,PD_UPD_Date,PD_UPD_By")] DataObject dataObject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataObject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataObject);
        }

        // GET: DataObjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataObject dataObject = db.DataObjects.Find(id);
            if (dataObject == null)
            {
                return HttpNotFound();
            }
            return View(dataObject);
        }

        // POST: DataObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataObject dataObject = db.DataObjects.Find(id);
            db.DataObjects.Remove(dataObject);
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
