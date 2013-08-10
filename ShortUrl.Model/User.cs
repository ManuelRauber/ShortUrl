using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Model
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Url> Urls { get; set; }
 		public string ApiKey { get; set; }
	}
}
