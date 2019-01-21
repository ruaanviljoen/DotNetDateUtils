using System;

namespace DotNetDateUtils
{
	public static class DateTimeExtensions
	{
		public static int DaysUntil(this DateTime date, DayOfWeek day)
		{
			int daysUntil = 0;
			if (date.DayOfWeek == day)
			{
				daysUntil = 7;
			}
			else
			{
				while (date.DayOfWeek != day)
				{
					daysUntil++;
					date = date.AddDays(1);
				}
			}
			return daysUntil;
		}

		public static DateTime DateOf(this DateTime date, DayOfWeek day)
		{
			return DateTime.Today.AddDays(DaysUntil(date, day));
		}

		public static TimeSpan TimeUntil(this DateTime date, DayOfWeek day, int hour, int minute = 0, int second = 0, int millisecond = 0)
		{
			DateTime targetDateSameTime = date.AddDays(DaysUntil(date, day));
			DateTime targetDateTime = new DateTime(targetDateSameTime.Year, targetDateSameTime.Month, targetDateSameTime.Day, hour, minute, second, millisecond);
			return targetDateTime - date;
		}
	}
}
