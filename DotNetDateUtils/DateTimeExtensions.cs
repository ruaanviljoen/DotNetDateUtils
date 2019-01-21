using System;

namespace DotNetDateUtils
{
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Calculates the integer number of days until the next future occurrence of a specific day of the week.
		/// A partial day is counted as one - e.g., If today is Monday 1pm, DaysUntil Tuesday would return 1, not 11/24
		/// </summary>
		/// <param name="date"></param>
		/// <param name="day"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Finds the date (without time) of the next future occurrence of a specific day of the week
		/// </summary>
		/// <param name="date"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		public static DateTime DateOf(this DateTime date, DayOfWeek day)
		{
			return date.AddDays(DaysUntil(date, day)).Date;
		}

		/// <summary>
		/// Calculates the timespan until the next future occurrence of a specific day of the week
		/// </summary>
		/// <param name="date"></param>
		/// <param name="day"></param>
		/// <param name="hour"></param>
		/// <param name="minute"></param>
		/// <param name="second"></param>
		/// <param name="millisecond"></param>
		/// <returns></returns>
		public static TimeSpan TimeUntil(this DateTime date, DayOfWeek day, int hour, int minute = 0, int second = 0, int millisecond = 0)
		{
			DateTime targetDateSameTime = date.AddDays(DaysUntil(date, day));
			DateTime targetDateTime = new DateTime(targetDateSameTime.Year, targetDateSameTime.Month, targetDateSameTime.Day, hour, minute, second, millisecond);
			return targetDateTime - date;
		}
	}
}
