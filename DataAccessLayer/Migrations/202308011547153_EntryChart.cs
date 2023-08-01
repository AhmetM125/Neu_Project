namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryChart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntryCarts",
                c => new
                    {
                        ChartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChartId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntryCarts", "UserId", "dbo.Users");
            DropForeignKey("dbo.EntryCarts", "ProductId", "dbo.Products");
            DropIndex("dbo.EntryCarts", new[] { "UserId" });
            DropIndex("dbo.EntryCarts", new[] { "ProductId" });
            DropTable("dbo.EntryCarts");
        }
    }
}
