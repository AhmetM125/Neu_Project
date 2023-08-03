namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockEntryU : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StockEntries");
            AddColumn("dbo.StockEntries", "EntryId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.StockEntries", "TransactionNo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StockEntries", "EntryId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StockEntries");
            AlterColumn("dbo.StockEntries", "TransactionNo", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.StockEntries", "EntryId");
            AddPrimaryKey("dbo.StockEntries", "TransactionNo");
        }
    }
}
