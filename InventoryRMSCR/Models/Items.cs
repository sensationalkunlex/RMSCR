using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class Items
    {
 

            private Product product = new Product(); // Instantiate tblProduct class object 

            #region Properties
            public Product Produc
            {
                get { return product; }
                set { product = value; }
        }
        private decimal quantity;

        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        // Default constructor
        public Items()
            {

            }

        //Parameterised constructor
        public Items(Product product, decimal quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }


        //public Items(Product product)
        //{
        //    this.product = product;

        //}

        #endregion

    }

}
