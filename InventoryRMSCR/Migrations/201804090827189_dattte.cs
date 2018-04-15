namespace InventoryRMSCR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dattte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Date");
        }
    }
}
