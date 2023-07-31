namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSaleTB : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Sales");
            AlterColumn("dbo.Sales", "TransactionNo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Sales", new[] { "TransactionNo", "ProductId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Sales");
            AlterColumn("dbo.Sales", "TransactionNo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Sales", "TransactionNo");
        }
    }
}
