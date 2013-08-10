namespace ShortUrl.DataAccessLayer.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<ShortUrl.DataAccessLayer.ShortUrlContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ShortUrl.DataAccessLayer.ShortUrlContext context)
		{
			
		}
	}
}
