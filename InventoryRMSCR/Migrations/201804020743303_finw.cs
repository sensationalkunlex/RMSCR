namespace InventoryRMSCR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        FactoryID = c.Int(nullable: false, identity: true),
                        FactoryName = c.String(),
                    })
                .PrimaryKey(t => t.FactoryID);
            
            DropTable("dbo.FactoryPs");
        }
        
        public override void Down()
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
    }
}
