namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_content_ımage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentImage");
        }
    }
}
