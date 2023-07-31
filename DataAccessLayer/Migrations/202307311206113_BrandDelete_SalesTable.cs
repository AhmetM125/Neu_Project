namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandDelete_SalesTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Brands");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 50),
                        TotalProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId);
            
        }
    }
}
