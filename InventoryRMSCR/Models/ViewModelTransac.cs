using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class ViewModelTransac
    {
        [Key]
        public int ID { get; set; }
        public string FactoryName { get; set; }
        public System.DateTime GetDate { get; set; }
        public decimal Total { get; set; }
        public string ProductName { get; set; }
        [Range(0, 9999999999999, ErrorMessage = "The value must be greater than 0")]
        public decimal FactoryQtyU { get; set; }
        public System.DateTime date { get; set; }
        public int FactoryID { get; set; }


    }
}