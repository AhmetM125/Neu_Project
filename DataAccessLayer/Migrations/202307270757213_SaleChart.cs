namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleChart : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SaleCarts");
            DropColumn("dbo.SaleCarts", "Chart_Id");
            AddColumn("dbo.SaleCarts", "ChartId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SaleCarts", "ChartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleCarts", "Chart_Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.SaleCarts");
            DropColumn("dbo.SaleCarts", "ChartId");
            AddPrimaryKey("dbo.SaleCarts", "Chart_Id");
        }
    }
}
