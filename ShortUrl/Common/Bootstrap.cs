using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ShortUrl.Common
{
	public static class Bootstrap
	{
		public static void Run(HttpConfiguration config)
		{
			ConfigureDependencyInjection(config);
		}

		private static void ConfigureDependencyInjection(HttpConfiguration config)
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			var container = builder.Build();

			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}