﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Quantity");
        }
    }
}
