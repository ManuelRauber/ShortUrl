using System;
using ShortUrl.Model;

namespace ShortUrl.Services.Contracts
{
	public interface IUrlService
	{
		Url Get(string id);
		Url Add(string longUrl, DateTime? expirationDate);
		Url Add(string longUrl, string timeString);
	}
}