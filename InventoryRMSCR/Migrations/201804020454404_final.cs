namespace InventoryRMSCR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FactoryPs",
                c => new
                    {
                        FactoryPID = c.Int(nullable: false, identity: true),
                        FactoryName = c.String(),
                    })
                .PrimaryKey(t => t.FactoryPID);
            
            DropTable("dbo.Factories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        FatoryID = c.Int(nullable: false, identity: true),
                        FactoryName = c.String(),
                    })
                .PrimaryKey(t => t.FatoryID);
            
            DropTable("dbo.FactoryPs");
        }
    }
}
