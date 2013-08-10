using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Model
{
	public class Url
	{
		public string Id { get; set; }
		public string LongUrl { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public int HitCount { get; set; }
		public virtual User User { get; set; }
	}
}
