using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Autofac.Integration.WebApi;

namespace ShortUrl.Common
{
	public class ApiKeyAuthorizationFilterAttribute : IAutofacAuthorizationFilter
	{
		private static readonly string _apiKey;
		private static readonly string _apiKeyConfigurationName = "ApiKey";
		private static readonly string _apiKeyQueryParameterKeyName = "apiKey";

		static ApiKeyAuthorizationFilterAttribute()
		{
			_apiKey = ConfigurationManager.AppSettings[_apiKeyConfigurationName];

			if (String.IsNullOrWhiteSpace(_apiKey))
			{
				throw new ConfigurationErrorsException("ApiKey is not set or empty!");
			}
		}

		public void OnAuthorization(HttpActionContext actionContext)
		{
			if (actionContext == null)
			{
				DenyRequest();
			}

			if (actionContext.Request == null)
			{
				DenyRequest();
			}

			var queryParameterList = actionContext.Request.GetQueryNameValuePairs().ToList();

			if (!queryParameterList.Any(x => x.Key.Equals(_apiKeyQueryParameterKeyName)))
			{
				DenyRequest();
			}

			var apiKey = queryParameterList.Single(x => x.Key.Equals(_apiKeyQueryParameterKeyName));

			if (!String.Equals(apiKey.Value, _apiKey, StringComparison.Ordinal))
			{
				DenyRequest();
			}
		}

		private void DenyRequest()
		{
			throw new HttpResponseException(HttpStatusCode.Unauthorized);
		}
	}
}