using System;
using ShortUrl.Model;

namespace ShortUrl.Services.Contracts
{
	public interface IUrlService
	{
		Url Get(Guid id);
		Url Add(string longUrl, DateTime? expirationDate);
	}
}