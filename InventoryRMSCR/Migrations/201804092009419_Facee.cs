namespace InventoryRMSCR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Facee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTransactions", "FactoryUsed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "FactoryUsed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "FactoryUsed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ProductTransactions", "FactoryUsed");
        }
    }
}
