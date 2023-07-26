namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleProduct_db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleProducts", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SaleProducts", "user_Id", c => c.Int());
            AddColumn("dbo.Sales", "TotalPrice", c => c.Single(nullable: false));
            CreateIndex("dbo.SaleProducts", "user_Id");
            AddForeignKey("dbo.SaleProducts", "user_Id", "dbo.Users", "Id");
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Sales", "SaleDate");
            DropColumn("dbo.Users", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FullName", c => c.String());
            AddColumn("dbo.Sales", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Status", c => c.String());
            DropForeignKey("dbo.SaleProducts", "user_Id", "dbo.Users");
            DropIndex("dbo.SaleProducts", new[] { "user_Id" });
            DropColumn("dbo.Sales", "TotalPrice");
            DropColumn("dbo.SaleProducts", "user_Id");
            DropColumn("dbo.SaleProducts", "SaleDate");
        }
    }
}
