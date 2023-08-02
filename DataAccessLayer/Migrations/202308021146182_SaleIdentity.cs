namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleIdentity : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Sales");
            AlterColumn("dbo.Sales", "TransactionNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Sales", "TransactionNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Sales");
            AlterColumn("dbo.Sales", "TransactionNo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Sales", "TransactionNo");
        }
    }
}
