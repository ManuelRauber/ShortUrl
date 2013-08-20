using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace ShortUrl.DataAccessLayer
{
	public sealed class DatabaseInitializer
	{
		private static Initializer _initializer;
		private static object _initializerLock = new object();
		private static bool _isInitialized;

		public static bool IsInitialized
		{
			get
			{
				return _isInitialized;
			}
		}

		public static void InitializeDatabase()
		{
			LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
		}

		private sealed class Initializer
		{
			public Initializer()
			{
				InitializeDatabase();
				InitializeWebSecurity();
			}

			private void InitializeDatabase()
			{
				
			}

			private void InitializeWebSecurity()
			{
				WebSecurity.InitializeDatabaseConnection("ShortUrlDatabaseConnection", "Users", "Id", "Name", true);
			}
		}
	}
}
