namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleCarts", "UserId", "dbo.Users");
            DropForeignKey("dbo.StockEntries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Sales", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
			DropColumn("dbo.Users", "Id");
			AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "UserId");
            AddForeignKey("dbo.SaleCarts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.StockEntries", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Sales", "UserId", "dbo.Users");
            DropForeignKey("dbo.StockEntries", "UserId", "dbo.Users");
            DropForeignKey("dbo.SaleCarts", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "UserId");
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.Sales", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StockEntries", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SaleCarts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
