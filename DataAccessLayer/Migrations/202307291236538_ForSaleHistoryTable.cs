namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForSaleHistoryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SaleProducts", "Sales_SaleId", "dbo.Sales");
            DropIndex("dbo.SaleProducts", new[] { "ProductId" });
            DropIndex("dbo.SaleProducts", new[] { "Sales_SaleId" });
            DropPrimaryKey("dbo.SaleProducts");
            AddColumn("dbo.SaleProducts", "TotalPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.SaleProducts", "TransactionNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SaleProducts", "TransactionNo");
            DropColumn("dbo.SaleProducts", "SaleId");
            DropColumn("dbo.SaleProducts", "Quantity");
            DropColumn("dbo.SaleProducts", "Price");
            DropColumn("dbo.SaleProducts", "ProductId");
            DropColumn("dbo.SaleProducts", "Sales_SaleId");
            DropTable("dbo.Sales");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId);
            
            AddColumn("dbo.SaleProducts", "Sales_SaleId", c => c.Int());
            AddColumn("dbo.SaleProducts", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.SaleProducts", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.SaleProducts", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.SaleProducts", "SaleId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.SaleProducts");
            AlterColumn("dbo.SaleProducts", "TransactionNo", c => c.String());
            DropColumn("dbo.SaleProducts", "TotalPrice");
            AddPrimaryKey("dbo.SaleProducts", "SaleId");
            CreateIndex("dbo.SaleProducts", "Sales_SaleId");
            CreateIndex("dbo.SaleProducts", "ProductId");
            AddForeignKey("dbo.SaleProducts", "Sales_SaleId", "dbo.Sales", "SaleId");
            AddForeignKey("dbo.SaleProducts", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
