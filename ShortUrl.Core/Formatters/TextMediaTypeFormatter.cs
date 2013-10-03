using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.Core.Formatters
{
	public class TextMediaTypeFormatter : MediaTypeFormatter
	{
		public TextMediaTypeFormatter()
		{
			SupportedEncodings.Add(Encoding.UTF8);
			SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
		}

		public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
			TransportContext transportContext)
		{
			return Task.Factory.StartNew(() =>
			{

				var str = (string)value;

				using (var textWriter = new StreamWriter(writeStream))
				{
					textWriter.Write(str);
				}
			});
		}

		public override bool CanReadType(Type type)
		{
			return false;
		}

		public override bool CanWriteType(Type type)
		{
			return typeof(string) == type;
		}
	}
}