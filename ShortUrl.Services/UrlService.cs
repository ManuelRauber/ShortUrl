﻿using System;
using System.Linq;
using System.Web;
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

		public Url Get(string id)
		{
			var url = _urlRepository.Get(id);
			
			url.HitCount++;

			_urlRepository.Update(url);
			UnitOfWork.Commit();

			return url;
		}

		public Url Add(string longUrl, DateTime? expirationDate)
		{
			if (!IsUrlValid(longUrl))
			{
				throw new ArgumentException("Url is not valid", "longUrl");
			}

			if (!IsExpirationDateValid(expirationDate))
			{
				throw new ArgumentException("Expiration date is invalid", "expirationDate");
			}

			var url = new Url()
			{
				LongUrl = longUrl,
				ExpirationDate = expirationDate,
				HitCount = 0,
			};

			// TODO: Refactor this, this is ugly!
			Url duplicate;

			if (IsDuplicate(url, out duplicate))
			{
				return duplicate;
			}

			url = _urlRepository.Add(url);
			UnitOfWork.Commit();

			return url;
		}

		private bool IsDuplicate(Url url, out Url duplicate)
		{
			duplicate = null;

			if (url == null)
			{
				return false;
			}

			var dbUrl = _urlRepository.Get()
				.Where(x => x.LongUrl.Equals(url.LongUrl))
				.SingleOrDefault(x => x.ExpirationDate.Equals(url.ExpirationDate));

			duplicate = dbUrl;
			return dbUrl != null;
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

		private bool IsUrlValid(string longUrl)
		{
			try
			{
				var url = new Uri(longUrl);
			}
			catch
			{
				return false;
			}

			return true;
		}

		private bool IsExpirationDateValid(DateTime? expirationDate)
		{
			return (expirationDate == null)
			       || (expirationDate.Value > DateTime.Now);
		}
	}
}