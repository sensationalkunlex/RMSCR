using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryRMSCR.Models;

namespace InventoryRMSCR.Controllers
{
    
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Transaction()
        {
            ViewBag.listProduct = db.products.ToList();
            return View();
        }

        public ActionResult ViewRecord()
        {
            ViewBag.Message = "Pagedlist";
            List<Factory> factory = db.factoryP.ToList();
            ViewBag.Factory = new SelectList(factory, "FactoryName", "FactoryName");
            //string fa, DateTime startDate, DateTime endDate

            string fa = "";

            DateTime startDate=DateTime.Now;
            DateTime endDate = DateTime.Now;


            decimal totalUsed = 0;
            List<MasterTbl> master = (from getter in db.mastertb
                                      where getter.FactoryName == fa && (getter.GetDate.Date >= startDate.Date && getter.GetDate.Date <= endDate.Date)
                                      orderby getter.MasterID ascending
                                      select getter).ToList();

            foreach (var q in master)
            {
                totalUsed += q.Total;


            }

            List<FactoriesTransaction> factoryTran = (from getter in db.FactoriesTransactions
                                                      where getter.FactoryName == fa && (getter.date.Date >= startDate.Date && getter.date.Date <= endDate.Date)
                                                      orderby getter.MasterID ascending
                                                      select getter).ToList();


            return View();
        }
        [NonAction]
        private void displayFactoryUsed(string fa, DateTime startDate, DateTime endDate)
        {

            decimal totalUsed = 0;
            List<MasterTbl> master = (from getter in db.mastertb
                                      where getter.FactoryName == fa && (getter.GetDate.Date >= startDate.Date && getter.GetDate.Date <= endDate.Date)
                                      orderby getter.MasterID ascending
                                      select getter).ToList();

            foreach (var q in master)
            {
                totalUsed += q.Total;


            }

            List<FactoriesTransaction> factoryTran = (from getter in db.FactoriesTransactions
                                                      where getter.FactoryName == fa && (getter.date.Date >= startDate.Date && getter.date.Date <= endDate.Date)
                                                      orderby getter.MasterID ascending
                                                      select getter).ToList();


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