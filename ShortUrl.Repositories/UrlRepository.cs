using System.Linq;
using ShortUrl.Core.Patterns;
using ShortUrl.DataAccessLayer;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Model;
using ShortUrl.Repositories.Contracts;

namespace ShortUrl.Repositories
{
	public class UrlRepository : Repository<Url>, IUrlRepository
	{
		private readonly IPatternGenerator _patternGenerator;

		public UrlRepository(IDatabaseFactory factory, IPatternGenerator patternGenerator) : base(factory)
		{
			_patternGenerator = patternGenerator;
		}

		public override Url Add(Url entity)
		{
			string key;

			do
			{
				key = _patternGenerator.Generate();
			}
			while (KeyExists(key));

			entity.Id = key;

			return base.Add(entity);
		}

		private bool KeyExists(string key)
		{
			return Get().Any(x => x.Id.Equals(key));
		}
	}
}