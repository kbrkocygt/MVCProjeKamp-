namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_yetenek_stringlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skils", "Yetenek", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skils", "Yetenek", c => c.String(maxLength: 20));
        }
    }
}
