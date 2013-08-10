using ShortUrl.DataAccessLayer;

namespace ShortUrl.Contracts.Repositories
{
	public interface IDatabaseFactory
	{
		ShortUrlContext GetShortUrlContext();
	}
}