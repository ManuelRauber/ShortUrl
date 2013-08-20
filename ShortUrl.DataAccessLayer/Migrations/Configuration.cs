using System.Configuration;
using System.Web.Security;
using WebMatrix.WebData;

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
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ShortUrl.DataAccessLayer.ShortUrlContext context)
		{
			if (DatabaseInitializer.IsInitialized)
			{
				DatabaseInitializer.InitializeDatabase();
			}
			
			bool tmp;

			if (Boolean.TryParse(ConfigurationManager.AppSettings["CreateAdminUser"], out tmp)
				&& (tmp))
			{
				SeedAdminUser(context);
			}
		}

		private void SeedAdminUser(ShortUrlContext context)
		{
			if (!WebSecurity.UserExists(_adminUserName))
			{
				WebSecurity.CreateUserAndAccount(_adminUserName, _adminUserName);
			}

			if (!Roles.RoleExists("Administrator"))
			{
				Roles.CreateRole("Administrator");
			}

			if (!Roles.IsUserInRole("Admin", "Administrator"))
			{
				Roles.AddUserToRole("Admin", "Administrator");
			}
		}
	}
}
