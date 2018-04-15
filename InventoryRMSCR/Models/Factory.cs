using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class Factory
    {

        public int FactoryID { get; set; }
        public string FactoryName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}