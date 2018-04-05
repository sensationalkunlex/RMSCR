using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class MasterTbl
    {
        [Key]
        public int MasterID { get; set; }
        public string  FactoryName { get; set; }
        public System.DateTime GetDate { get; set; }
        [Range(0, 9999999999999, ErrorMessage = "The value must be greater than 0")]
        public decimal Total { get; set; }
        public List<FactoriesTransaction> factories { get; set;}

    }
}