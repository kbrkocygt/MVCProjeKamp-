namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_skilTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skils", "Yetenek", c => c.String(maxLength: 20));
            DropColumn("dbo.Skils", "UserName");
            DropColumn("dbo.Skils", "UserImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skils", "UserImage", c => c.String(maxLength: 100));
            AddColumn("dbo.Skils", "UserName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Skils", "Yetenek", c => c.String(maxLength: 50));
        }
    }
}
