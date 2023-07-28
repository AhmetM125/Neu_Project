namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migStockEntry : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StockEntries");
            DropColumn("dbo.StockEntries", "StockEntryId");
            AddColumn("dbo.StockEntries", "InvoiceNumber", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.StockEntries", "TotalPrice", c => c.Single(nullable: false));
            AddPrimaryKey("dbo.StockEntries", "InvoiceNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockEntries", "StockEntryId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.StockEntries");
            DropColumn("dbo.StockEntries", "TotalPrice");
            DropColumn("dbo.StockEntries", "InvoiceNumber");
            AddPrimaryKey("dbo.StockEntries", "StockEntryId");
        }
    }
}
