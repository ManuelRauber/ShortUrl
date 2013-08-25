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
using ShortUrl.Services.Contracts;

namespace ShortUrl.Controllers
{
	public class UsersController : ApiController
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IEnumerable<User> Get()
		{
			return _userService.AllUsers();
		}
	}
}
