using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryRMSCR.Models
{
    public class MasterFactoryVModel
    {
        private MasterTbl master = new MasterTbl(); // Instantiate tblProduct class object 

        #region Properties
        public MasterTbl Master
        {
            get { return master; }
            set { master = value; }
        }



        private FactoriesTransaction factoryT = new FactoriesTransaction(); // Instantiate tblProduct class object 

        #region Properties
        public FactoriesTransaction FactoryT
        {
            get { return factoryT; }
            set { factoryT = value; }
        }


        #endregion

        #region Constructors
        // Default constructor
        public MasterFactoryVModel()
        {

        }

        //Parameterised constructor
        public MasterFactoryVModel(FactoriesTransaction factories, decimal quantity)
        {
            this.master = factories;
            this.quantity = quantity;
        }


        //public Items(Product product)
        //{
        //    this.product = product;

        //}
    }
}