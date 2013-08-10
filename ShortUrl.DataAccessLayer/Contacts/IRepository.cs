namespace ShortUrl.Contracts.Repositories
{
	public interface IRepository<T>
		where T : class
	{
		T Add(T entity);
		void Delete(T entity);
		T Get(object id);
	}
}