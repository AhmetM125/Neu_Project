namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 100),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.SaleCarts",
                c => new
                    {
                        Chart_Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Chart_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Status = c.String(maxLength: 10),
                        AdminRole = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleProducts",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        TransactionNo = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Sales_SaleId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sales_SaleId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.UserId)
                .Index(t => t.Sales_SaleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId);
            
            CreateTable(
                "dbo.StockEntries",
                c => new
                    {
                        StockEntryId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StockEntryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleProducts", "UserId", "dbo.Users");
            DropForeignKey("dbo.SaleProducts", "Sales_SaleId", "dbo.Sales");
            DropForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SaleCarts", "UserId", "dbo.Users");
            DropForeignKey("dbo.SaleCarts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SaleProducts", new[] { "Sales_SaleId" });
            DropIndex("dbo.SaleProducts", new[] { "UserId" });
            DropIndex("dbo.SaleProducts", new[] { "ProductId" });
            DropIndex("dbo.SaleCarts", new[] { "UserId" });
            DropIndex("dbo.SaleCarts", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.StockEntries");
            DropTable("dbo.Sales");
            DropTable("dbo.SaleProducts");
            DropTable("dbo.Customers");
            DropTable("dbo.Users");
            DropTable("dbo.SaleCarts");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
