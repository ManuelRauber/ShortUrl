using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Model
{
	public class User
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public virtual ICollection<Url> Urls { get; set; }
 		public string ApiKey { get; set; }
	}
}
