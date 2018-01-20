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
using DisconnectedGenericRepository;


namespace CRUDB_Utility.Controllers
{
    public class DataStructureTypesController : Controller
    {
        private GenericRepository<DataStructureType> repo;

        public DataStructureTypesController(GenericRepository<DataStructureType> _repo)
        {
            repo = _repo;
        }
     
        // GET: DataStructureTypes
        public ActionResult Index()
        {
            return View(repo.All());
        }

        // GET: DataStructureTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            DataStructureType dataStructureType = repo.FindByKey(id.Value);
            if (dataStructureType == null)
            {
                return HttpNotFound();
            }
            return View(dataStructureType);
        }

        // GET: DataStructureTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataStructureTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DataStructureTypeID,Name,Description,PD_INS_Date,PD_INS_By,PD_UPD_Date,PD_UPD_By")] DataStructureType dataStructureType)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(dataStructureType);
                return RedirectToAction("Index");
            }

            return View(dataStructureType);
        }

        // GET: DataStructureTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            DataStructureType dataStructureType = repo.FindByKey(id.Value);
            if (dataStructureType == null)
            {
                return HttpNotFound();
            }
            return View(dataStructureType);
        }

        // POST: DataStructureTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DataStructureTypeID,Name,Description,PD_INS_Date,PD_INS_By,PD_UPD_Date,PD_UPD_By")] DataStructureType dataStructureType)
        {
            if (ModelState.IsValid)
            {
                repo.Update(dataStructureType);
                return RedirectToAction("Index");
            }
            return View(dataStructureType);
        }

        // GET: DataStructureTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            DataStructureType dataStructureType = repo.FindByKey(id.Value);
            if (dataStructureType == null)
            {
                return HttpNotFound();
            }
            return View(dataStructureType);
        }

        // POST: DataStructureTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
