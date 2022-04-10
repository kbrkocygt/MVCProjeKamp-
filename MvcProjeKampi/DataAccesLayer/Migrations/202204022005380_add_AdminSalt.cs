namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_AdminSalt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Salt");
        }
    }
}
