namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useradminrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AdminRole", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AdminRole");
        }
    }
}
