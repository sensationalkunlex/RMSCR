using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class ViewModelRecord
    {
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
                   ApplyFormatInEditMode = true)]
        public DateTime DateFrm { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy HH:mm}",
                ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }
    }
}