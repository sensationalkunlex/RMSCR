namespace InventoryRMSCR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesbecosdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factories", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Factories", "CreatedDate");
        }
    }
}
