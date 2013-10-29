using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.DataAccessLayer.Migrations;

namespace ShortUrl.DataAccessLayer
{
	public class DatabaseFactory : IDatabaseFactory
	{
		private ShortUrlContext _shortUrlContext;

		// TODO: Maybe refactor this?
		static DatabaseFactory()
		{
			(new DatabaseInitializer<ShortUrlContext, Configuration>()).Initialize();
		}

		public ShortUrlContext GetShortUrlContext()
		{
			return _shortUrlContext ?? (_shortUrlContext = new ShortUrlContext());
		}
	}
}
