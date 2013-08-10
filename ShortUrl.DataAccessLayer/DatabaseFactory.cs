using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortUrl.Contracts.Repositories;

namespace ShortUrl.DataAccessLayer
{
	public class DatabaseFactory : IDatabaseFactory
	{
		private ShortUrlContext _shortUrlContext;

		public ShortUrlContext GetShortUrlContext()
		{
			return _shortUrlContext ?? (_shortUrlContext = new ShortUrlContext());
		}
	}
}
