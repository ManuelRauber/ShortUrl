using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Repositories.Contracts;
using ShortUrl.Services.Contracts;

namespace ShortUrl.Services
{
	public class UserService : BaseService, IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
		{
			_userRepository = userRepository;
		}
	}
}