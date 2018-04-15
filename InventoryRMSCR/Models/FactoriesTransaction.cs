using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class FactoriesTransaction
    {
        // Search by Factory

        public int ID { get; set; }
        public int MasterID { get; set; }
        public string FactoryName { get; set; }
        public string ProductName { get; set; }
        [Range(0, 9999999999999, ErrorMessage = "The value must be greater than 0")]
        public decimal FactoryQtyU { get; set; }
 
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
                ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public virtual MasterTbl MasterTbl { get; set; }

    }
}