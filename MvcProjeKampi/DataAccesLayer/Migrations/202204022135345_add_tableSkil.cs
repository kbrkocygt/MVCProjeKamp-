namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tableSkil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skils",
                c => new
                    {
                        SkilID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 20),
                        UserImage = c.String(maxLength: 100),
                        Yetenek = c.String(maxLength: 50),
                        YetenekBaşarı = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.SkilID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skils");
        }
    }
}
