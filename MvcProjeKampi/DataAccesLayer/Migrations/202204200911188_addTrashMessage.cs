namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrashMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Trash", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Trash");
        }
    }
}
