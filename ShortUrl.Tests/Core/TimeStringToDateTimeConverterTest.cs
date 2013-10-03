using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using ShortUrl.Core.Converters;

namespace ShortUrl.Tests.Core
{
	[TestClass]
	public class TimeStringToDateTimeConverterTest
	{
		[TestMethod]
		public void TimeStringIsEmpty()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("");
			dateTime.HasValue.Should().BeFalse();
		}

		[TestMethod]
		public void TimeStringIsInvalidContainingOnlyANumber()
		{
			Action act = () => TimeStringToDateTimeConverter.Convert("1");

			act.ShouldThrow<Exception>();
		}

		[TestMethod]
		public void TimeStringIsInvalidContainingOnlyAUnit()
		{
			Action act = () => TimeStringToDateTimeConverter.Convert("m");

			act.ShouldThrow<Exception>();
		}

		[TestMethod]
		public void TimeStringIsInvalidContainingANumberWithoutAUnit()
		{
			Action act = () => TimeStringToDateTimeConverter.Convert("10m5");

			act.ShouldThrow<Exception>();
		}

		[TestMethod]
		public void TimeStringIsInvalidContainingAUnitWithoutANumber()
		{
			Action act = () => TimeStringToDateTimeConverter.Convert("10mm");

			act.ShouldThrow<Exception>();
		}

		[TestMethod]
		public void AddOneMinute()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("1m");

			dateTime.Should().BeCloseTo(DateTime.Now.AddMinutes(1));
		}

		[TestMethod]
		public void AddTwoMinutes()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("2m");

			dateTime.Should().BeCloseTo(DateTime.Now.AddMinutes(2));
		}

		[TestMethod]
		public void AddOneDay()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("1d");

			dateTime.Should().BeCloseTo(DateTime.Now.AddDays(1));
		}

		[TestMethod]
		public void AddTwoDays()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("2d");

			dateTime.Should().BeCloseTo(DateTime.Now.AddDays(2));
		}

		[TestMethod]
		public void AddOneWeek()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("1w");

			dateTime.Should().BeCloseTo(DateTime.Now.AddDays(7));
		}

		[TestMethod]
		public void AddTwoWeeks()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("2w");

			dateTime.Should().BeCloseTo(DateTime.Now.AddDays(14));
		}

		[TestMethod]
		public void AddOneYear()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("1y");

			dateTime.Should().BeCloseTo(DateTime.Now.AddYears(1));
		}

		[TestMethod]
		public void AddTwoYears()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("2y");

			dateTime.Should().BeCloseTo(DateTime.Now.AddYears(2));
		}

		[TestMethod]
		public void AddTwoMinutesAndTwoDaysWithMinutesFirst()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("2m2d");

			dateTime.Should().BeCloseTo(DateTime.Now.AddMinutes(2).AddDays(2));
		}

		[TestMethod]
		public void AddTwoMinutesAndTwoDaysWithDaysFirst()
		{
			var dateTime = TimeStringToDateTimeConverter.Convert("2d2m");

			dateTime.Should().BeCloseTo(DateTime.Now.AddMinutes(2).AddDays(2));
		}
	}
}
