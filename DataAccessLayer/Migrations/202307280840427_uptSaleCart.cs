namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uptSaleCart : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SaleCarts", "TotalPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SaleCarts", "TotalPrice", c => c.Single());
        }
    }
}
