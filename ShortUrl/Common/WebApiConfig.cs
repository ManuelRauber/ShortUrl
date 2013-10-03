using System.Web.Http;
using ShortUrl.Core.Formatters;

namespace ShortUrl.Common
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			RegisterRoutes(config);
			RegisterMediaTypeFormatter(config);
		}

		private static void RegisterMediaTypeFormatter(HttpConfiguration config)
		{
			config.Formatters.Insert(0, new TextMediaTypeFormatter());
		}

		private static void RegisterRoutes(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute("Add", "Add", new
			{
				controller = "Url",
				action = "Add",
			});

			config.Routes.MapHttpRoute("AddSliding", "AddSliding", new
			{
				controller = "Url",
				action = "Add",
			});

			config.Routes.MapHttpRoute("Get", "{id}/{verbose}", new
			{
				controller = "Url",
				action = "Get",
				verbose = RouteParameter.Optional,
			});
		}
	}
}
