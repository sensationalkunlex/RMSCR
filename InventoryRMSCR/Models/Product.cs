using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryRMSCR.Models
{
    public class Product
    {
        
        public int ProductID { get; set; }
        
        public string ProductName { get; set; }
        [Display(Name="Quantity(s)")]
        [Range(0, 9999999999999, ErrorMessage = "The value must be greater than 0")]
        public decimal qty { get; set; }
        [Display(Name = "Present Quantity(s)")]
        public decimal? iniqty { get; set; }
        public IList<ProductTransaction> prod { get; set; }



    }
}