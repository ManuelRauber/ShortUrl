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
		public DbSet<Url> Urls { get; set; }

		public ShortUrlContext()
			: base("ShortUrlDatabaseConnection")
		{ }
	}
}
