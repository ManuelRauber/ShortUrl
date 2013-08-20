using System;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Model;

namespace ShortUrl.Repositories.Contracts
{
	public interface IUserRepository : IRepository<User>
	{
		bool ApiKeyIsValid(Guid userId, string apiKey);
	}
}