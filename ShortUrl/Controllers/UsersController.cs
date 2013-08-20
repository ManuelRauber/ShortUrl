using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShortUrl.Model;
using ShortUrl.Repositories;
using ShortUrl.Repositories.Contracts;

namespace ShortUrl.Controllers
{
	public class UsersController : ApiController
	{
		private IUserRepository _userRepository;

		public UsersController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public IEnumerable<User> Get()
		{
			return _userRepository.Get(filter: null).ToList();
		}
	}
}
