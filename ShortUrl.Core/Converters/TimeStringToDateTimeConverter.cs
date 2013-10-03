using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShortUrl.Core.Converters
{
	public static class TimeStringToDateTimeConverter
	{
		private static readonly string _parseRegEx = @"(\d+)([mdwy])";

		private static Dictionary<string, int> _unitMultipliers = new Dictionary<string, int>
		{
		  { "m", 60 },
			{ "d", 60 * 60 * 24 },
			{ "w", 60 * 60 * 24 * 7 },
			{ "y", 60 * 60 * 24 * 365 }
		};

		/// <summary>
		/// Converts a time string to a <see cref="DateTime"/> object.
		/// It will add the seconds of the time string to <see cref="DateTime.Now"/> 
		/// 
		/// It supports the following units:
		/// - m: Minutes
		/// - d: Days
		/// - w: Weeks
		/// - y: Years
		/// 
		/// If <paramref name="timeString"/> is empty or whitespace, it will return null
		/// </summary>
		/// <param name="timeString"></param>
		/// <returns></returns>
		public static DateTime? Convert(string timeString)
		{
			if (String.IsNullOrWhiteSpace(timeString))
			{
				return null;
			}

			var dateTime = ParseTimeString(timeString);
			return dateTime;
		}

		private static DateTime ParseTimeString(string timeString)
		{
			var dateTime = DateTime.Now;

			var match = Regex.Match(timeString, _parseRegEx, RegexOptions.Compiled | RegexOptions.IgnoreCase);

			while (match.Success)
			{
				var value = match.Groups[0].Value;
				var unit = match.Groups[1].Value;
				unit = unit.ToLower();
				
				int multiplier;

				if (Int32.TryParse(value, out multiplier))
				{
					if (!_unitMultipliers.ContainsKey(unit))
					{
						throw new Exception(String.Format("Unit '{0}' not recognized.", unit));
					}

					dateTime = dateTime.AddSeconds(multiplier * _unitMultipliers[unit]);
				}
				else
				{
					throw new Exception(String.Format("Error parsing the time string '{0}'", timeString));
				}
				
				match = match.NextMatch();
			}

			return dateTime;
		}
	}
}