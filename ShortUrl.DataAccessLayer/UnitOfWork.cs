using ShortUrl.DataAccessLayer.Contacts;

namespace ShortUrl.DataAccessLayer
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ShortUrlContext _context;

		public UnitOfWork(IDatabaseFactory factory)
		{
			_context = factory.GetShortUrlContext();
		}

		public void Commit()
		{
			_context.SaveChanges();
		}
	}
}