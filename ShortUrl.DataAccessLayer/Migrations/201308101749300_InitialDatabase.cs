namespace ShortUrl.DataAccessLayer.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class InitialDatabase : DbMigration
	{
		public override void Up()
		{
			CreateTable(
					"dbo.Users",
					c => new
							{
								Id = c.Int(nullable: false, identity: true),
								Name = c.String(),
								ApiKey = c.String(),
							})
					.PrimaryKey(t => t.Id);

			CreateTable(
					"dbo.Urls",
					c => new
							{
								Id = c.String(nullable: false, maxLength: 128),
								LongUrl = c.String(),
								ExpirationDate = c.DateTime(),
								HitCount = c.Int(nullable: false),
								UserId = c.Int(nullable: false),
							})
					.PrimaryKey(t => t.Id)
					.ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
					.Index(t => t.UserId);

		}

		public override void Down()
		{
			DropIndex("dbo.Urls", new[] { "UserId" });
			DropForeignKey("dbo.Urls", "UserId", "dbo.Users");
			DropTable("dbo.Urls");
			DropTable("dbo.Users");
		}
	}
}
