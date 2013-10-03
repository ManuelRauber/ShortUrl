using System;
using ShortUrl.Core.Converters;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Model;
using ShortUrl.Repositories.Contracts;
using ShortUrl.Services.Contracts;

namespace ShortUrl.Services
{
	public class UrlService : BaseService, IUrlService
	{
		private readonly IUrlRepository _urlRepository;

		public UrlService(IUnitOfWork unitOfWork, IUrlRepository urlRepository)
			: base(unitOfWork)
		{
			_urlRepository = urlRepository;
		}

		public Url Get(Guid id)
		{
			var url = _urlRepository.Get(id);
			
			url.HitCount++;

			_urlRepository.Update(url);

			return url;
		}

		public Url Add(string longUrl, DateTime? expirationDate)
		{
			var url = new Url()
			{
				LongUrl = longUrl,
				ExpirationDate = expirationDate,
				HitCount = 0,
			};

			return _urlRepository.Add(url);
		}

		/// <summary>
		/// Creates a short url without an expirationDate
		/// </summary>
		/// <param name="longUrl"></param>
		/// <returns></returns>
		public Url Add(string longUrl)
		{
			return Add(longUrl, expirationDate: null);
		}

		public Url Add(string longUrl, string timeString)
		{
			var dateTime = ConvertTimeStringToDateTime(timeString);
			return Add(longUrl, dateTime);
		}

		private DateTime? ConvertTimeStringToDateTime(string timeString)
		{
			return TimeStringToDateTimeConverter.Convert(timeString);
		}
	}
}