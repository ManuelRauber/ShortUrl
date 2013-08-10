using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ShortUrl.Model;

namespace ShortUrl.DataAccessLayer
{
	public class ShortUrlContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Url> Urls { get; set; }

		public ShortUrlContext()
			: base("ShortUrlDatabaseConnection")
		{ }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasKey(u => u.Id)
				.ToTable("Users");
			modelBuilder.Entity<User>()
				.HasMany(u => u.Urls)
				.WithRequired(u => u.User)
				.Map(c => c.MapKey("UserId"));

			modelBuilder.Entity<Url>()
				.HasKey(u => u.Id)
				.HasRequired(u => u.User);
			modelBuilder.Entity<Url>()
				.ToTable("Urls");
		}
	}
}
