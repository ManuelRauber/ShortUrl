using System.Collections;
using System.Collections.Generic;
using ShortUrl.Model;

namespace ShortUrl.Services.Contracts
{
	public interface IUserService
	{
		IEnumerable<User> AllUsers();
	}
}