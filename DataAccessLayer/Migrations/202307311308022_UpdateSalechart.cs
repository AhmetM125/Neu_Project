namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSalechart : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SaleCarts");
            AddPrimaryKey("dbo.SaleCarts", new[] { "ChartId", "UserId", "ProductId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SaleCarts");
            AddPrimaryKey("dbo.SaleCarts", new[] { "ChartId", "UserId" });
        }
    }
}
