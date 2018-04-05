using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        [Display(Name="Quantity")]
        [Range(0, 9999999999999, ErrorMessage = "The value must be greater than 0")]
        public decimal qty { get; set; }
        public System.DateTime Date { get; set; }
        public int getID { get; }
    }
}