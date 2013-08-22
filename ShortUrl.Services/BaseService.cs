using ShortUrl.DataAccessLayer.Contacts;

namespace ShortUrl.Services
{
	public abstract class BaseService
	{
		protected readonly IUnitOfWork UnitOfWork;

		public BaseService(IUnitOfWork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}
	}
}