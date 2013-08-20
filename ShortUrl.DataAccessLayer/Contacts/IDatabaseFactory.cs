namespace ShortUrl.DataAccessLayer.Contacts
{
	public interface IDatabaseFactory
	{
		ShortUrlContext GetShortUrlContext();
	}
}