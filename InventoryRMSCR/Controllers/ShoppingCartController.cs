using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryRMSCR.Models;
namespace InventoryRMSCR.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            try
            {
                List<Items> cart = (List<Items>)Session["cart"];
            
                ViewData["CartCount"] = cart.Count;
                return PartialView("CartSummary");
            }
            catch(Exception ee)
            {
                ViewData["CartCount"] = 0;
                return PartialView("CartSummary");

            }
                
            
          
        }
       
        public ActionResult Update(FormCollection fc)
        {
            String error = "";
            // I left something on done here;
            string[] quantities = fc.GetValues("quantity");
            decimal result = 0;
            List<Items> cart = (List<Items>)Session["cart"];
            int anotherCounter = 0;
            if (!int.TryParse(cart.Count.ToString(), out anotherCounter))
            {error= "Nothing to Update";
                ViewBag.Error = error;
                return RedirectToAction( "Order");
            }
                for (int i = 0; i < cart.Count; i++)
            {
                if (!decimal.TryParse(quantities[i], out result))
                {
                    error += "One of the value supply is not in the format the input No" + (i + 1) + " \n";

                    ViewBag.Error = error;
                        // validation page 

                    
                    return View("Order");
                }
                else if (Convert.ToDecimal(quantities[i]) < 0)
                {
                    error += "Lower than zero  the input no" + (i + 1) + " \n";

                    ViewBag.Error = error;

                     return View("Order");
                }
                else if (decimal.Parse(quantities[i]) >= Convert.ToDecimal(cart[i].Produc.qty))
                {
                    error += "The Value Supplied is greater than the value of the Quantity Available at the input No " + (i + 1) + " \n";
                    

                    ViewBag.Error = error;

                    return View("Order");
                }
                else
                {
                    ViewBag.Success = "Update";

                    cart[i].Quantity = Convert.ToDecimal(quantities[i]);
                    Session["cart"] = cart;

                }
                
            } 
                return View("Order");
            
        }

        public ActionResult SuccessPage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Order()
        {
            List<Items> cart = (List<Items>)Session["cart"]; // Put all the items from the "Session["cart"] into the list cart

            try {

                if (cart.Count == 0)
                {
                    RedirectToAction("Transaction", "Home" );
                }
                return View();
            }
            catch(Exception ee){
                return RedirectToAction("Transaction", "Home");
            }
            
            
        }
        ApplicationDbContext dob = new ApplicationDbContext();
        public ActionResult FinalPage()
        {
            List<Factory> factory = dob.factoryP.ToList();
            ViewBag.Factory = new SelectList(factory, "FactoryName", "FactoryName");

            int count = 1;
            // checking the db for the last value and adding. how to check the next value;
            if (dob.mastertb.ToList().Count != 0) {
                var query1 = (from tbl in dob.mastertb

                              select tbl.MasterID).ToList().Last();

                count = Convert.ToInt32(query1) + 1;
                    }
            @ViewBag.MasterID = count;
            List<Items> cart = (List<Items>)Session["cart"];
            ViewBag.getter = cart;

            // Put all the items from the "Session["cart"] into the list cart
            try
            {
                if (cart.Count < 0) {

                    ViewBag.Error = "Nothing was Selected";
                    return RedirectToAction("Order");
                }
              



            }
            catch(Exception ee)
            {
                ViewBag.Error = "Something was Wrong";
                return RedirectToAction("Order");
            }
            return View();
        }

        decimal total = 0;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinalPage(ViewModelTransac factories)
        {
            // if the value is not selected... Remain on a single page pass msg
            //if()
            
            try
            {
                //Product Updating
                List<Items> prod = (List<Items>)Session["cart"];
                foreach (Items item in prod)
                {
                    Product pro = dob.products.Single(a => a.ProductID == item.Produc.ProductID);
                    pro.qty = Convert.ToDecimal(item.Produc.qty) - Convert.ToDecimal(item.Quantity);
                    pro.iniqty = Convert.ToDecimal(item.Produc.qty) - Convert.ToDecimal(item.Quantity);
                    dob.SaveChanges();
                }

                // How to solve the last problem

                //Total Value
                // get the Id in the MainDb also check;
                //passing all data into the database
                List<Items> tol = (List<Items>)Session["cart"];
                foreach (Items item in tol)
                {
                    total += item.Quantity;

                }
                //Order 
                MasterTbl ms = new MasterTbl()
                {
                    FactoryName =factories.FactoryName,
                    GetDate = DateTime.Now,
                    Total = total,
                };
                dob.mastertb.Add(ms);
              dob.SaveChanges();


                int count = 1;
                // checking the db for the last value and adding. how to check the next value;
                try
                {
                    var query1 = (from tbl in dob.mastertb
                                  select tbl.MasterID).ToList().Last();
                    count = Convert.ToInt32(query1);

                }catch (Exception ee)
                {
                    count = 1;
                }


                // 
                List<Items> detail = (List<Items>)Session["cart"];
                foreach (Items item in detail)
                {
                    FactoriesTransaction ft = new FactoriesTransaction();
                    ft.FactoryName = factories.FactoryName;
                    ft.FactoryQtyU = item.Quantity;
                    ft.ProductName = item.Produc.ProductName;
                    ft.MasterID = count;
                    ft.FactoryQtyU = item.Quantity;
                    ft.date = DateTime.Now;
                    dob.FactoriesTransactions.Add(ft);
                    dob.SaveChanges();
                    // and soon
                    //dn.FactoriesTransaction.Add(db);
                    //Dn.SaveChanges();
                }
                






                // get the last Id of the Order detail
                // get the data from cart
                // saving the data of cart with associated Ids and factoryName and Date
                // Saving the main Data into the database
                //deleting session data
                Session["Cart"] = null;
                
            }
            catch(Exception ee)
            {
                
            }
            //return to home control action method



            //List<Items> cart = (List<Items>)Session["cart"]; // Put all the items from the "Session["cart"] into the list cart

            //if (cart.Count < 1)
            
                return RedirectToAction("SuccessPage");
            
          
        }

       
        #region Is product in the cart Method
        private int isExisting(int id)
        {
            List<Items> cart = (List<Items>)Session["cart"]; // Put all the items from the "Session["cart"] into the list cart

            for (int i = 0; i < cart.Count; i++)

                if (cart[i].Produc.ProductID == id) // If the cart contains the product those ID is provided 

                    return i; // Then return the number of Products in the cart

            return -1; // Else return -1
        }
        #endregion

        #region Delete Action
        
        public ActionResult Delete(int id)
        {
            int index = isExisting(id); // index = Product ID from in the Cart only

            List<Items> cart = (List<Items>)Session["cart"];

            cart.RemoveAt(index); // Remove product based on the Product ID provided.


            Session["cart"] = cart; // Update Session["cart"]
            

            return View("Order");
        }
        #endregion

        #region Order Now Action
        
        public ActionResult OrderNow(int id)
        {
            try
            {

                if (Session["cart"] == null)
                {
                    List<Items> cart = new List<Items>();

                    cart.Add(new Items(db.products.Find(id), 1)); // Add 1 Product based on id provided

                    Session["cart"] = cart; // Update Session["cart"]

                }
                else
                {
                    List<Items> cart = (List<Items>)Session["cart"];

                    int index = isExisting(id); // index = Product ID from in the Cart only

                    if (index == -1) // If the product to be order is not already in the cart

                        cart.Add(new Items(db.products.Find(id), 1)); // Add 1 Product based on id provided

                    else // if product already exists in the cart

                        //cart[index].Quantity++; // increase the quantity of the product based on the ID provided

                        Session["cart"] = cart; // Update Session["cart"]
                }

                 return RedirectToAction("Transaction", "Home" );
            }
            catch { return RedirectToAction("Transaction", "Home" );
            }
        }
        #endregion


       
    }

}
