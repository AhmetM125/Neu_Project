namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SaleCarts", "Price", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SaleCarts", "Price", c => c.Single(nullable: false));
        }
    }
}
