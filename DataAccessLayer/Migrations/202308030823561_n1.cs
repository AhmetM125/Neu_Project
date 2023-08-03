namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StockEntries");
            DropPrimaryKey("dbo.Sales");
            DropColumn("dbo.Sales", "ChartId");
            AlterColumn("dbo.StockEntries", "TransactionNo", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Sales", "SaleId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StockEntries", "TransactionNo");
            AddPrimaryKey("dbo.Sales", "SaleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "ChartId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Sales");
            DropPrimaryKey("dbo.StockEntries");
            AlterColumn("dbo.StockEntries", "TransactionNo", c => c.Int(nullable: false));
            DropColumn("dbo.Sales", "SaleId");
            AddPrimaryKey("dbo.Sales", "ChartId");
            AddPrimaryKey("dbo.StockEntries", new[] { "TransactionNo", "ProducId" });
        }
    }
}
