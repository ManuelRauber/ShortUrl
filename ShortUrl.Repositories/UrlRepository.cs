using ShortUrl.DataAccessLayer;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Model;
using ShortUrl.Repositories.Contracts;

namespace ShortUrl.Repositories
{
	public class UrlRepository : Repository<Url>, IUrlRepository
	{
		public UrlRepository(IDatabaseFactory factory) : base(factory)
		{ }
	}
}