using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class ProductTransaction
    {
        public int ID { get; set; }

        public string ProductName { get; set; }
        [Range(0, 9999999999999, ErrorMessage = "The value must be greater than 0")]
        public decimal InitialValue { get; set; }
        [Range(0, 9999999999999, ErrorMessage = "The value must be greater than 0")]
        public decimal AddedValue { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
                ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public decimal FactoryUsed { get; set; }
    }
}