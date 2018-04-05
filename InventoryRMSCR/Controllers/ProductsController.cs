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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {

            int getInit = 0;
            int i = 0;
            if (ModelState.IsValid)
            {
                var query = from d in db.products
                            where d.ProductName == product.ProductName
                            select d.ProductID;
                foreach (var g in query)
                {
                    return View();


                }
                     
                   

               


                Product ue = new Product();
                ue.iniqty= product.qty;
                ue.ProductName = product.ProductName;
                ue.qty = product.qty;
                db.products.Add(ue);
                
                db.SaveChanges();


                ProductTransaction ne = new ProductTransaction();
                ne.InitialValue = 0;
                ne.AddedValue = product.qty;
                ne.ProductName = product.ProductName;
                ne.Date = System.DateTime.Now;
                db.productTrans.Add(ne);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.products.Find(id);
            

           // getInit = (query.)
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            int i = 0;
            int getInit = 0;
            if (ModelState.IsValid)
            {
            //    var query = from d in db.products
            //                where d.ProductName == product.ProductName
            //                select d.ProductID;
            //    foreach (var g in query)
            //    {
            //        i = g;
            //        getInit++;


            //    }
            //if (getInit == 1 || i==null)
            //    {
                    
            //    }
            //    else
            //    {
            //        return View(product);
            //    }

                Product pro = db.products.Single(a => a.ProductID == product.ProductID);
                

                
                decimal x = Convert.ToDecimal(product.iniqty) + Convert.ToDecimal(product.qty);
                decimal y = x;
                pro.qty = y;
                pro.iniqty = y;
                db.SaveChanges();



                ProductTransaction ne = new ProductTransaction();
                ne.InitialValue = Convert.ToDecimal(product.iniqty);
                ne.AddedValue = product.qty;
                ne.ProductName = product.ProductName;
                ne.Date = System.DateTime.Now;
                db.productTrans.Add(ne);
                db.SaveChanges();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.products.Find(id);
            db.products.Remove(product);
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
