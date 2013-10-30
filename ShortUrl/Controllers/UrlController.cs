using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;
using Microsoft.SqlServer.Server;
using ShortUrl.Model;
using ShortUrl.Services.Contracts;

namespace ShortUrl.Controllers
{
	public class UrlController : ApiController
	{
		private readonly IUrlService _urlService;

		private static readonly string _baseUrlConfigurationName = "BaseUrl";
		private static readonly string _baseUrl;

		static UrlController()
		{
			_baseUrl = ConfigurationManager.AppSettings[_baseUrlConfigurationName];

			if (String.IsNullOrWhiteSpace(_baseUrl))
			{
				throw new ConfigurationErrorsException("BaseUrl is not set!");
			}
		}

		public UrlController(IUrlService urlService)
		{
			_urlService = urlService;
		}

		[HttpGet]
		public string Add(string longUrl, DateTime? expirationDate = null)
		{
			if (String.IsNullOrWhiteSpace(longUrl))
			{
				return null;
			}

			var url = _urlService.Add(longUrl, expirationDate);

			return FormatUrl(url);
		}

		[HttpGet]
		public string Add(string longUrl, string timeString)
		{
			if (String.IsNullOrWhiteSpace(longUrl))
			{
				return null;
			}

			var url = _urlService.Add(longUrl, timeString);

			return FormatUrl(url);
		}

		[HttpGet]
		public object Get(string id)
		{
			return Get(id, false);
		}

		[HttpGet]
		public object Get(string id, bool verbose)
		{
			var url = _urlService.Get(id);

			if (null == url)
			{
				return null;
			}

			if (verbose)
			{
				return url;
			}

			return url.LongUrl;
		}

		private string FormatUrl(Url url)
		{
			if (url == null)
			{
				return String.Empty;
			}

			return String.Format("{0}{1}", _baseUrl, url.Id);
		}
	}
}
