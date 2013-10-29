using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading;

namespace ShortUrl.DataAccessLayer
{
	// TODO: Does this make sense?
	public class DatabaseInitializer<TContext, TConfiguration>
		where TContext: DbContext
		where TConfiguration: DbMigrationsConfiguration<TContext>, new()
	{
		private class AutomaticDatabaseMigration<TMigrationContext, TMigrationConfiguration>
			where TMigrationContext : TContext
			where TMigrationConfiguration : DbMigrationsConfiguration<TMigrationContext>, new()
		{
			public AutomaticDatabaseMigration()
			{
				
				Database.SetInitializer(new MigrateDatabaseToLatestVersion<TMigrationContext, TMigrationConfiguration>());
			}
		}

		private object _lock;
		private AutomaticDatabaseMigration<TContext, TConfiguration> _initializer;
		private bool _isInitialized;

		public void Initialize()
		{
			LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _lock);
		}
	}
}