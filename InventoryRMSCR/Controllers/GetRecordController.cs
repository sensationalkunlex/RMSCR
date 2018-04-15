using InventoryRMSCR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryRMSCR.Controllers
{
    public class GetRecordController : Controller
    {
        ApplicationDbContext Db = new ApplicationDbContext();
        // GET: GetRecord
        public ActionResult Index()
        {
            int count = 0;
            var query = from qq in Db.mastertb
                        orderby qq.GetDate
                        select qq;

            ViewBag.Data = new SelectList(query, "MasterID", "MasterID");
            foreach(var q in query)
            {
                count++;

            }
            if (count >=1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpPost]
        public ActionResult Index(MasterTbl masterTbl)
        {
            int count = masterTbl.MasterID;
            return RedirectToAction("SuccessPage","ShoppingCart", new { id = count });
        }


        public ActionResult GetEachProductTrans(ProductTransaction pro)
        {


            var query = from qq in Db.productTrans
                        where qq.ProductName == pro.ProductName
                        select qq;
            var quer = from gt in Db.FactoriesTransactions
                        where gt.ProductName == pro.ProductName
                        select gt;

            return View();

        }

       
    }
}