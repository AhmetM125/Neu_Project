namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesForStockEntry_User : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AdminRole", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Status", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 50));
        }
    }
}
