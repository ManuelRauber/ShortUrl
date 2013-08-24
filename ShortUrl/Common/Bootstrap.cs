using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ShortUrl.DataAccessLayer;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Repositories;
using ShortUrl.Repositories.Contracts;
using ShortUrl.Services;
using ShortUrl.Services.Contracts;

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

			builder.RegisterType<UserService>().As<IUserService>();
			builder.RegisterType<UserRepository>().As<IUserRepository>();
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
			builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();

			var container = builder.Build();

			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}