namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quest1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SaleCarts", "TotalPrice", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SaleCarts", "TotalPrice", c => c.Single(nullable: false));
        }
    }
}
