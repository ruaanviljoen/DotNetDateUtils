using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetDateUtils;

namespace UnitTestProject
{
	[TestClass]
	public class TestDateExtensionMethods
	{
		[TestMethod]
		public void TestDateOf()
		{
			DateTime date = new DateTime(2019, 1, 18, 12, 0, 0); //12 NOON 18/01/2019
			Assert.AreEqual(new DateTime(date.AddDays(1).Ticks).Date, date.DateOf(DayOfWeek.Saturday));
			Assert.AreEqual(new DateTime(date.AddDays(3).Ticks).Date, date.DateOf(DayOfWeek.Monday));
			Assert.AreEqual(new DateTime(date.AddDays(7).Ticks).Date, date.DateOf(DayOfWeek.Friday));
		}

		[TestMethod]
		public void TestDaysUntilFromNoon()
		{
			DateTime date = new DateTime(2019, 1, 18, 12, 0, 0); //12 NOON 18/01/2019
			Assert.AreEqual(1, date.DaysUntil(DayOfWeek.Saturday));
			Assert.AreEqual(2, date.DaysUntil(DayOfWeek.Sunday));
			Assert.AreEqual(3, date.DaysUntil(DayOfWeek.Monday));
			Assert.AreEqual(4, date.DaysUntil(DayOfWeek.Tuesday));
			Assert.AreEqual(5, date.DaysUntil(DayOfWeek.Wednesday));
			Assert.AreEqual(6, date.DaysUntil(DayOfWeek.Thursday));
			Assert.AreEqual(7, date.DaysUntil(DayOfWeek.Friday));
		}

		[TestMethod]
		public void TestDaysUntilFromMidnight()
		{
			DateTime date = new DateTime(2019, 1, 18, 00, 0, 0); //12 midnight 18/01/2019
			Assert.AreEqual(1, date.DaysUntil(DayOfWeek.Saturday));
			Assert.AreEqual(2, date.DaysUntil(DayOfWeek.Sunday));
			Assert.AreEqual(3, date.DaysUntil(DayOfWeek.Monday));
			Assert.AreEqual(4, date.DaysUntil(DayOfWeek.Tuesday));
			Assert.AreEqual(5, date.DaysUntil(DayOfWeek.Wednesday));
			Assert.AreEqual(6, date.DaysUntil(DayOfWeek.Thursday));
			Assert.AreEqual(7, date.DaysUntil(DayOfWeek.Friday));
		}

		[TestMethod]
		public void TestTimeUntil()
		{ 
		
			DateTime date = new DateTime(2019, 1, 18, 12, 0, 0); //12 NOON 18/01/2019
			Assert.AreEqual(new TimeSpan(1, 1, 0, 0, 0), date.TimeUntil(DayOfWeek.Saturday, 13)); //saturday 1pm
			Assert.AreEqual(new TimeSpan(1, 0, 30, 0, 0), date.TimeUntil(DayOfWeek.Saturday, 12, 30)); //saturday 12.30pm
			Assert.AreEqual(new TimeSpan(1, 11, 0, 0, 0), date.TimeUntil(DayOfWeek.Saturday, 23)); //saturday 11pm
			Assert.AreEqual(new TimeSpan(6, 20, 0, 0, 0), date.TimeUntil(date.DayOfWeek, 8, 0)); //next occurrence of this day, but 8am
		}
	}
}
