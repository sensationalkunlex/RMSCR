namespace InventoryRMSCR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fac : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "FactoryUsed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "FactoryUsed");
        }
    }
}
