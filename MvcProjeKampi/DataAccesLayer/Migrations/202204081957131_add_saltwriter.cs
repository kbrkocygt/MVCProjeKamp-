namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_saltwriter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "Salt", c => c.String());
            DropColumn("dbo.Admins", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Salt", c => c.String());
            DropColumn("dbo.Writers", "Salt");
        }
    }
}
