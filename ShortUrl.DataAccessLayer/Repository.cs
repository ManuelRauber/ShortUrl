using System;
using System.Collections.Generic;
using System.Data;
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
		private readonly IDatabaseFactory _factory;

		public Repository(IDatabaseFactory factory)
		{
			_factory = factory;

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

		public void Update(T entity)
		{
			_dbSet.Attach(entity);
			_factory.GetShortUrlContext().Entry(entity).State = EntityState.Modified;
		}

		public virtual T Get(object id)
		{
			return _dbSet.Find(id);
		}

		public IQueryable<T> Get()
		{
			IQueryable<T> query = _dbSet;

			return query;
		}
	}
}
