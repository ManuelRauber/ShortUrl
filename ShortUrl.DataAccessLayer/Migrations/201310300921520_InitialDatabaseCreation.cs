namespace ShortUrl.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Urls",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LongUrl = c.String(maxLength: 400),
                        ExpirationDate = c.DateTime(),
                        HitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
								.Index(x => x.LongUrl);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Urls");
        }
    }
}
