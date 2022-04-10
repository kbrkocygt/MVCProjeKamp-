﻿namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ısread_message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "isRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "isRead");
        }
    }
}
