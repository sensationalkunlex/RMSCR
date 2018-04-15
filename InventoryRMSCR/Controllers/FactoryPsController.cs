using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryRMSCR.Models;

namespace InventoryRMSCR.Controllers
{
    public class FactoryPsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FactoryPs
        public ActionResult Index()
        {
            return View(db.factoryP.ToList());
        }
        
        // GET: FactoryPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factoryP = db.factoryP.Find(id);
            if (factoryP == null)
            {
                return HttpNotFound();
            }
            return View(factoryP);
        }

        // GET: FactoryPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactoryPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FactoryID,FactoryName,CreatedDate")] Factory factoryP)
        {
            if (ModelState.IsValid)
            {
                db.factoryP.Add(factoryP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factoryP);
        }

        // GET: FactoryPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factoryP = db.factoryP.Find(id);
            if (factoryP == null)
            {
                return HttpNotFound();
            }
            return View(factoryP);
        }

        // POST: FactoryPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FactoryID,FactoryName,CreatedDate")] Factory factoryP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factoryP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factoryP);
        }

        // GET: FactoryPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factory factoryP = db.factoryP.Find(id);
            if (factoryP == null)
            {
                return HttpNotFound();
            }
            return View(factoryP);
        }

        // POST: FactoryPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factory factoryP = db.factoryP.Find(id);
            db.factoryP.Remove(factoryP);
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
