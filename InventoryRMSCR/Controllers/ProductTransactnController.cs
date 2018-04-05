using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryRMSCR.Controllers
{
    public class ProductTransactnController : Controller
    {
        // GET: ProductTransactn
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductTransactn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductTransactn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTransactn/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductTransactn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductTransactn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductTransactn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductTransactn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
