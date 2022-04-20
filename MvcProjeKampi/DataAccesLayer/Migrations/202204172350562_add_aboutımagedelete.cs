namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_aboutımagedelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "AboutImage2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
        }
    }
}
