using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;
using ShortUrl.Services.Contracts;

namespace ShortUrl.Controllers
{
	public class UrlController : ApiController
	{
		private readonly IUrlService _urlService;

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

			return url.Id;
		}

		[HttpGet]
		public string Add(string longUrl, string timeString)
		{
			if (String.IsNullOrWhiteSpace(longUrl))
			{
				return null;
			}

			var url = _urlService.Add(longUrl, timeString);

			return url.Id;
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
	}
}
