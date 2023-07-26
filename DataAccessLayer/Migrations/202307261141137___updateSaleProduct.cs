namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class __updateSaleProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleProducts", "user_Id", "dbo.Users");
            DropIndex("dbo.SaleProducts", new[] { "user_Id" });
            RenameColumn(table: "dbo.SaleProducts", name: "user_Id", newName: "UserId");
            AlterColumn("dbo.SaleProducts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.SaleProducts", "UserId");
            AddForeignKey("dbo.SaleProducts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleProducts", "UserId", "dbo.Users");
            DropIndex("dbo.SaleProducts", new[] { "UserId" });
            AlterColumn("dbo.SaleProducts", "UserId", c => c.Int());
            RenameColumn(table: "dbo.SaleProducts", name: "UserId", newName: "user_Id");
            CreateIndex("dbo.SaleProducts", "user_Id");
            AddForeignKey("dbo.SaleProducts", "user_Id", "dbo.Users", "Id");
        }
    }
}
