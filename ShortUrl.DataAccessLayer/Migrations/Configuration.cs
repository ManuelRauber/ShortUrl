using System.Configuration;
using System.Web.Security;
using ShortUrl.Model;

namespace ShortUrl.DataAccessLayer.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<ShortUrl.DataAccessLayer.ShortUrlContext>
	{
		private static readonly string _adminUserName = "Admin";
		private static readonly string _adminRoleName = "Administrator";

		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(ShortUrl.DataAccessLayer.ShortUrlContext context)
		{
			bool tmp;

			if (Boolean.TryParse(ConfigurationManager.AppSettings["CreateAdminUser"], out tmp)
				&& (tmp))
			{
				SeedAdminUser(context);
			}
		}

		private void SeedAdminUser(ShortUrlContext context)
		{

		}
	}
}
