using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShortUrl.DataAccessLayer.Contacts;

namespace ShortUrl.DataAccessLayer
{
	public class Repository<T> : IRepository<T>
		where T : class
	{
		private readonly IDbSet<T> _dbSet; 

		public Repository(IDatabaseFactory factory)
		{
			var context = factory.GetShortUrlContext();
			_dbSet = context.Set<T>();
		}

		public virtual T Add(T entity)
		{
			return _dbSet.Add(entity);
		}

		public virtual void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public virtual T Get(object id)
		{
			return _dbSet.Find(id);
		}

		public IQueryable<T> Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			return query;
		}
	}
}
