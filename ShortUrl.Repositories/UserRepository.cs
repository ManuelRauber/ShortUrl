using System;
using ShortUrl.DataAccessLayer;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Model;
using ShortUrl.Repositories.Contracts;

namespace ShortUrl.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(IDatabaseFactory factory) : base(factory)
		{ }

		public bool ApiKeyIsValid(Guid userId, string apiKey)
		{
			var user = Get(userId);

			if (user == null)
			{
				return false;
			}

			return user.ApiKey.Equals(apiKey, StringComparison.Ordinal);
		}
	}
}