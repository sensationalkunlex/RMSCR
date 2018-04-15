using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryRMSCR.Models;
using PagedList.Mvc;
using PagedList;

namespace InventoryRMSCR.Controllers
{
    
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        decimal totallAvai = 0;
        public ActionResult Transaction()
        {

            int? page = 0;
            if (page ==null) {
                page = 1;
            }
            
            var listProduct = db.products.ToList();
            object paging = page;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            foreach (var q in listProduct)
            {
               totallAvai+= q.qty;
            }
            ViewBag.TotalAvai = totallAvai;
            return View(listProduct);
//return View();
//
        }




        DateTime Startn = DateTime.Now;
        DateTime Endn = DateTime.Now;
        public ActionResult getRecord(string Factory, string startDate, string endDate)
        {
            ViewBag.Message = "Pagedlist";
            //List<Factory> factory = db.factoryP.ToList();
            // ViewBag.Factory = new SelectList(factory, "FactoryName", "FactoryName");

            if (Factory != null)
            {
                
                if (!DateTime.TryParse(startDate, out Startn))
                    {

                    return RedirectToAction("ViewRecord","Home");
                }
               
                if (!DateTime.TryParse(endDate, out Endn))
                {

                   return RedirectToAction("ViewRecord", "Home");
                }
                DateTime Start = Convert.ToDateTime(startDate); ;
                //if(DateTime.TryParse())
                DateTime g = Convert.ToDateTime(endDate).AddDays(1);
                DateTime End = Convert.ToDateTime(g);
                if (Start > End)
                {
                    return RedirectToAction("ViewRecord", "Home");

                }
                var master = from getter1 in db.mastertb
                             join getter2 in db.FactoriesTransactions on getter1.MasterID equals getter2.MasterID
                             where getter1.FactoryName == Factory && (getter1.GetDate >= Start && getter1.GetDate <= End)
                             orderby getter1.MasterID ascending
                             select new MasterFactorViewModel { Masterrr=getter1, Transaction=getter2};
                                 // Id = getter1.MasterID, TotalVal = getter1.Total, MDate = getter1.GetDate, FactoryNamee = getter1.FactoryName, getProduct = getter2.ProductName, getUsed = getter2.FactoryQtyU, getDate = getter2.date };




                return View(master);
            }
            return View();
        }


        public ActionResult GetProductResult(string startDates, string endDates)
        {
            if (!DateTime.TryParse(startDates, out Startn))
            {

                return RedirectToAction("ViewRecord", "Home");
            }

            if (!DateTime.TryParse(endDates, out Endn))
            {

                return RedirectToAction("ViewRecord", "Home");
            }
            
            DateTime Start = Convert.ToDateTime(startDates); ;
            //if(DateTime.TryParse())
            DateTime g = Convert.ToDateTime(endDates).AddDays(1);
            DateTime End = Convert.ToDateTime(g);
            if (Start > End)
            {
                return RedirectToAction("ViewRecord", "Home");

            }
            var query = from qq in db.productTrans
                        where qq.Date >= Start && qq.Date <= End
                        orderby qq.Date descending
                        select qq;

            return View(query);
        }


        public ActionResult ViewProductTrans()
        {
            return View();
        }

        public ActionResult ViewRecord( )
        {
            string fa="";
            DateTime startDate=DateTime.Now;
            DateTime endDate=DateTime.Now;


            ViewBag.Message = "Pagedlist";
            List<Factory> factory = db.factoryP.ToList();
            ViewBag.Factory = new SelectList(factory, "FactoryName", "FactoryName");

            if (fa != null)
            {
                //DateTime


                //var master = from getter1 in db.mastertb
                //             join getter2 in db.FactoriesTransactions on getter1.MasterID equals getter2.MasterID
                //             where getter1.FactoryName == fa && (getter1.GetDate.Date >= startDate.Date && getter1.GetDate.Date <= endDate.Date)
                //             orderby getter1.MasterID ascending
                //             select new { Id = getter1.MasterID, TotalVal = getter1.Total, MDate = getter1.GetDate, FactoryNamee = getter1.FactoryName, getProduct = getter2.ProductName, getUsed = getter2.FactoryQtyU, getDate = getter2.date };




                return View();
            }
            return View();



        }



        [NonAction]
        private void displayFactoryUsed(string fa, DateTime startDate, DateTime endDate)
        {

           // decimal totalUsed = 0;
            var master = from getter1 in db.mastertb
                          join getter2 in db.FactoriesTransactions on getter1.MasterID equals getter2.MasterID
                          where getter1.FactoryName == fa && (getter1.GetDate.Date >= startDate.Date && getter1.GetDate.Date <= endDate.Date)
                                      orderby getter1.MasterID ascending
                                      select  new { Id=getter1.MasterID, TotalVal= getter1.Total, MDate=getter1.GetDate,FactoryNamee= getter1.FactoryName, getProduct=getter2.ProductName, getUsed=getter2.FactoryQtyU, getDate=getter2.date};

            

            //List<FactoriesTransaction> factoryTran = (from getter in db.FactoriesTransactions
            //                                          where getter.FactoryName == fa && (getter.date.Date >= startDate.Date && getter.date.Date <= endDate.Date)
            //                                          orderby getter.MasterID ascending
            //                                          select getter).ToList();


            int id = 0;
            var query = (from getter1 in db.mastertb
                         join getter2 in db.FactoriesTransactions on getter1.MasterID equals getter2.MasterID
                         join getter3 in db.productTrans on getter2.MasterID equals getter3.ID
                         where getter1.MasterID == id
                         select new
                         {
                             uu = getter3.ID,
                             fjf=getter2.MasterID
                         }
                         ).Take(273729);


            var queryProduct = (from getter in db.productTrans
                                where (getter.Date.Date >= startDate.Date && getter.Date.Date <= endDate.Date) select getter);
            foreach (var q in queryProduct)
            {
               // q.InitialValue;
            }
           /* Searching using Factory Used
Date A between Date B
getting all the records in the Factory
*/
            //Learning Purposes... not needed now
        }


        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "";
            return View();
        }

    }
}