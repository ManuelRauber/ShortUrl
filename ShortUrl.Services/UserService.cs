using System.Collections.Generic;
using System.Linq;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Model;
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

		public IEnumerable<User> AllUsers()
		{
			return _userRepository.Get(filter: null).ToArray();
		}
	}
}