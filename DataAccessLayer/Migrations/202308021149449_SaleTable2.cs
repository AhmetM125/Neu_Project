namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleTable2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Sales");
            AddColumn("dbo.Sales", "ChartId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sales", "TransactionNo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Sales", "ChartId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Sales");
            AlterColumn("dbo.Sales", "TransactionNo", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Sales", "ChartId");
            AddPrimaryKey("dbo.Sales", "TransactionNo");
        }
    }
}
