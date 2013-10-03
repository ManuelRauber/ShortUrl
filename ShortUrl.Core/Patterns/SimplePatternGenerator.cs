using System;
using System.Text;

namespace ShortUrl.Core.Patterns
{
	public sealed class SimplePatternGenerator : IPatternGenerator
	{
		private static readonly string _allowedCharacters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		private static readonly Random _random = new Random();

		public string Generate()
		{
			var builder = new StringBuilder(10);
			int randomMax = _allowedCharacters.Length - 1;

			for (int i = 0; i < 10; i++)
			{
				builder.Append(_allowedCharacters[_random.Next(0, randomMax)]);
			}

			return builder.ToString();
		}
	}
}