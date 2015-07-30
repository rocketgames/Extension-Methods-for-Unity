using System;

/* *****************************************************************************
 * File:    DateTimeExtensions.cs
 * Author:  Philip Pierce - Wednesday, September 10, 2014
 * Description:
 *  Extensions for DateTime
 *  
 * History:
 *  Wednesday, September 10, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for DateTime
/// </summary>
public static class DateTimeExtensions
{
    #region Constants

    /// <summary>
    /// Constant that represents number of days in a week
    /// </summary>
    internal const int DAYS_PER_WEEK = 7;

    /// <summary>
    /// Constant that represents number of days in a fortnight
    /// </summary>
    internal const int DAYS_PER_FORTNIGHT = DAYS_PER_WEEK * 2;

    /// <summary>
    /// Constant that represents number of weeks in a fortnight
    /// </summary>
    internal const int WEEKS_PER_FORTNIGHT = 2;

    /// <summary>
    /// Constant that represents number of years in a decade
    /// </summary>
    internal const int YEARS_PER_DECADE = 10;

    /// <summary>
    /// Constant that represents number of years in a century
    /// </summary>
    internal const int YEARS_PER_CENTURY = 100;

    /// <summary>
    /// Constant that represents January month
    /// </summary>
    private const int JANUARY = 1;

    /// <summary>
    /// Constant that represents February month
    /// </summary>
    private const int FEBRUARY = 2;

    /// <summary>
    /// Constant that represents March month
    /// </summary>
    private const int MARCH = 3;

    /// <summary>
    /// Constant that represents April month
    /// </summary>
    private const int APRIL = 4;

    /// <summary>
    /// Constant that represents May month
    /// </summary>
    private const int MAY = 5;

    /// <summary>
    /// Constant that represents June month
    /// </summary>
    private const int JUNE = 6;

    /// <summary>
    /// Constant that represents July month
    /// </summary>
    private const int JULY = 7;

    /// <summary>
    /// Constant that represents August month
    /// </summary>
    private const int AUGUST = 8;

    /// <summary>
    /// Constant that represents September month
    /// </summary>
    private const int SEPTEMBER = 9;

    /// <summary>
    /// Constant that represents October month
    /// </summary>
    private const int OCTOBER = 10;

    /// <summary>
    /// Constant that represents November month
    /// </summary>
    private const int NOVEMBER = 11;

    /// <summary>
    /// Constant that represents December month
    /// </summary>
    private const int DECEMBER = 12;
    
    // Constants
    #endregion


    #region IsBetween

    /// <summary>
    /// Returns true if a date is between two days
    /// </summary>
    /// <param name="value"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static bool IsBetween(this DateTime value, DateTime from, DateTime to)
    {
        return ((from <= value) && (to >= value));
    }

    // IsBetween
    #endregion

    #region Midnight

    /// <summary>
    /// Returns the date as midnight
    /// </summary>
    /// <param name="value"></param>
    public static DateTime Midnight(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, value.Day);
    }

    // Midnight
    #endregion

    #region DateFromDay

    /// <summary>
    /// Returns a date for this year, with day and month
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    public static DateTime DateFromDay(this int day, int month)
    {
        return new DateTime(DateTime.Now.Year, month, day);
    }

    /// <summary>
    /// Returns a date with day, month, and year
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public static DateTime DateFromDay(this int day, int month, int year)
    {
        return new DateTime(year, month, day);
    }

    // DateFromDay
    #endregion
    
    #region DateFromMonth

    /// <summary>
    /// Returns a date for this year, with day and month
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    public static DateTime DateFromMonth(this int month, int day)
    {
        return new DateTime(DateTime.Now.Year, month, day);
    }

    /// <summary>
    /// Returns a date with day, month, and year
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public static DateTime DateFromMonth(this int month, int day, int year)
    {
        return new DateTime(year, month, day);
    }

    // DateFromDay
    #endregion

    #region FirstOfMonth

    /// <summary>
    /// Returns the first day of the month
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime FirstOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1);
    }

    /// <summary>
    /// Returns the first day of the month
    /// </summary>
    /// <param name="month"></param>
    /// <returns></returns>
    public static DateTime FirstOfMonth(this int month)
    {
        return new DateTime(DateTime.Now.Year, month, 1);
    }

    /// <summary>
    /// Returns the first day of the month
    /// </summary>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public static DateTime FirstOfMonth(this int month, int year)
    {
        return new DateTime(year, month, 1);
    }

    // FirstOfMonth
    #endregion

    #region EndOfMonth

    /// <summary>
    /// Returns the last day of the month
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime EndOfMonth(this DateTime value)
    {
        return new DateTime(value.Year, value.Month, 1).AddMonths(1).AddDays(-1);
    }

    /// <summary>
    /// Returns the last day of the month
    /// </summary>
    /// <param name="month"></param>
    /// <returns></returns>
    public static DateTime EndOfMonth(this int month)
    {
        return new DateTime(DateTime.Now.Year, month, 1).EndOfMonth();
    }

    /// <summary>
    /// Returns the last day of the month
    /// </summary>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public static DateTime EndOfMonth(this int month, int year)
    {
        return new DateTime(year, month, 1).EndOfMonth();
    }

    // EndOfMonth
    #endregion

    #region Yesterday

    /// <summary>
    /// Returns yesterday's date (keeps the time)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime Yesterday(this DateTime value)
    {
        return value.AddDays(-1);
    }

    /// <summary>
    /// Returns yesterday's date at midnight
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime YesterdayMidnight(this DateTime value)
    {
        return value.Yesterday().Midnight();
    }

    // Yesterday
    #endregion

    #region Tomorrow

    /// <summary>
    /// Returns Tomorrow's date (keeps the time)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime Tomorrow(this DateTime value)
    {
        return value.AddDays(1);
    }

    /// <summary>
    /// Returns Tomorrow's date at midnight
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime TomorrowMidnight(this DateTime value)
    {
        return value.Tomorrow().Midnight();
    }

    // Tomorrow
    #endregion

    #region IsSameDay

    /// <summary>
    /// Returns true if both dates are the same (ignores time)
    /// </summary>
    /// <param name="value"></param>
    /// <param name="compareDate"></param>
    /// <returns></returns>
    public static bool IsSameDay(this DateTime value, DateTime compareDate)
    {
        return value.Midnight().Equals(compareDate.Midnight());
    }

    // IsSameDay
    #endregion

    #region IsLaterDate

    /// <summary>
    /// Returns true if <paramref name="value"/> is greater than <paramref name="compareDate"/>
    /// </summary>
    /// <param name="value">date to check</param>
    /// <param name="compareDate">date to compare. Returns true if this value is LESS than value</param>
    /// <returns></returns>
    public static bool IsLaterDate(this DateTime value, DateTime compareDate)
    {
        return value > compareDate;
    }

    // IsLaterDate
    #endregion

    #region IsOlderDate

    /// <summary>
    /// Returns true if <paramref name="value"/> is less than <paramref name="compareDate"/>
    /// </summary>
    /// <param name="value">date to check</param>
    /// <param name="compareDate">date to compare. Returns true if this value is GREATER than value</param>
    /// <returns></returns>
    public static bool IsOlderDate(this DateTime value, DateTime compareDate)
    {
        return value < compareDate;
    }

    // IsOlderDate
    #endregion

    #region IsToday

    /// <summary>
    /// Checks whether the given day is Today.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the given day is Today, false otherwise.</returns>
    public static bool IsToday(this DateTime date)
    {
        return date.Date == DateTime.Now.Date;
    }

    // IsToday
    #endregion

    #region IsTomorrow

    /// <summary>
    /// Checks whether the given day is Tomorrow.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the given day is Tomorrow, false otherwise.</returns>
    public static bool IsTomorrow(this DateTime date)
    {
        return date.Date == DateTime.Now.Date.AddDays(1);
    }

    // IsTomorrow
    #endregion

    #region IsYesterday

    /// <summary>
    /// Checks whether the given day is Yesterday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the given day is yesterday, false otherwise.</returns>
    public static bool IsYesterday(this DateTime date)
    {
        return date.Date == DateTime.Now.Date.AddDays(-1);
    }

    // IsYesterday
    #endregion

    #region "Older than" methods

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a second.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a second, false otherwise.</returns>
    public static bool IsOlderThanASecond(this DateTime date)
    {
        return date.Subtract(DateTime.Now).Seconds < 0;
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a minute.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a minute, false otherwise.</returns>          
    public static bool IsOlderThanAMinute(this DateTime date)
    {
        return date.Subtract(DateTime.Now).Minutes < 0;
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than 1 hour.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than 1 hour, false otherwise.</returns>          
    public static bool IsOlderThanAnHour(this DateTime date)
    {
        return date.Subtract(DateTime.Now).Hours < 0;
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a day.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a day, false otherwise.</returns>          
    public static bool IsOlderThanADay(this DateTime date)
    {
        return date.Subtract(DateTime.Now).Days < 0;
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a week.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a week, false otherwise.</returns>          
    public static bool IsOlderThanAWeek(this DateTime date)
    {
        return date.Subtract(DateTime.Now).Days < DAYS_PER_WEEK;
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a fortnight.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a fortnight, false otherwise.</returns>          
    public static bool IsOlderThanAFortnight(this DateTime date)
    {
        return date.Subtract(DateTime.Now).Days < DAYS_PER_FORTNIGHT;
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a month.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a month, false otherwise.</returns>          
    public static bool IsOlderThanAMonth(this DateTime date)
    {
        var oneMonthOlderDate = DateTime.Now.AddMonths(-1);
        return date.IsOlderThan(oneMonthOlderDate);
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than 6 months.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than 6 months, false otherwise.</returns>          
    public static bool IsOlderThanHalfYear(this DateTime date)
    {
        var halfAYearOlderDate = DateTime.Now.AddMonths(-6);
        return date.IsOlderThan(halfAYearOlderDate);
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a year.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a year, false otherwise.</returns>          
    public static bool IsOlderThanAYear(this DateTime date)
    {
        var oneYearOlderDate = DateTime.Now.AddYears(-1);
        return date.IsOlderThan(oneYearOlderDate);
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a decade (10 years).
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a decade, false otherwise.</returns>          
    public static bool IsOlderThanADecade(this DateTime date)
    {
        var oneDecadeOlderDate = DateTime.Now.AddYears(YEARS_PER_DECADE.Negate());
        return date.IsOlderThan(oneDecadeOlderDate);
    }

    /// <summary>
    /// Checks if the difference between the given DateTime and DateTime.Now is more than a century.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a century, false otherwise.</returns>          
    public static bool IsOlderThanACentury(this DateTime date)
    {
        var oneCenturyOlderDate = DateTime.Now.AddYears(YEARS_PER_CENTURY.Negate());
        return date.IsOlderThan(oneCenturyOlderDate);
    }

    /// <summary>
    /// Checks whether the first date is older than the second date.
    /// </summary>
    /// <param name="firstDate">The first DateTime to be checked.</param>
    /// <param name="secondDate">The second DateTime to be checked.</param>
    /// <returns>True if first date is older, false otherwise.</returns>
    /// <example>Returns True for (new DateTime(2012,1,1)).IsOlderThan(new DateTime(2012,6,30)).</example>
    public static bool IsOlderThan(this DateTime firstDate, DateTime secondDate)
    {
        return firstDate.Subtract(secondDate).Ticks < 0;
    }

    #endregion

    #region "Younger than" methods

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a second.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a second, false otherwise.</returns>          
    public static bool IsYoungerThanASecond(this DateTime date)
    {
        return date.Subtract(DateTime.Now).TotalSeconds > 0;
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a minute.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a minute, false otherwise.</returns>          
    public static bool IsYoungerThanAMinute(this DateTime date)
    {
        return date.Subtract(DateTime.Now).TotalMinutes > 0;
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than an hour.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than an hour, false otherwise.</returns>          
    public static bool IsYoungerThanAnHour(this DateTime date)
    {
        return date.Subtract(DateTime.Now).TotalHours > 0;
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a day.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a day, false otherwise.</returns>          
    public static bool IsYoungerThanADay(this DateTime date)
    {
        return date.Subtract(DateTime.Now).Days > 0;
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a week.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a week, false otherwise.</returns>          
    public static bool IsYoungerThanAWeek(this DateTime date)
    {
        var now = DateTime.Now;
        return date.Subtract(now).Days >= DAYS_PER_WEEK && date.IsYoungerThan(now);
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a fortnight.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a fortnight, false otherwise.</returns>          
    public static bool IsYoungerThanAFortnight(this DateTime date)
    {
        var now = DateTime.Now;
        return date.Subtract(now).Days >= DAYS_PER_FORTNIGHT && date.IsYoungerThan(now);
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a month.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a month, false otherwise.</returns>          
    public static bool IsYoungerThanAMonth(this DateTime date)
    {
        var oneMonthYoungerDate = DateTime.Now.AddMonths(1);
        return date.IsYoungerThan(oneMonthYoungerDate);
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than 6 months.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than 6 months, false otherwise.</returns>          
    public static bool IsYoungerThanHalfYear(this DateTime date)
    {
        var halfAYearYoungerDate = DateTime.Now.AddMonths(6);
        return date.IsYoungerThan(halfAYearYoungerDate);
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a year.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a year, false otherwise.</returns>          
    public static bool IsYoungerThanAYear(this DateTime date)
    {
        var oneYearYoungerDate = DateTime.Now.AddYears(1);
        return date.IsYoungerThan(oneYearYoungerDate);
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a decade.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a decade, false otherwise.</returns>          
    public static bool IsYoungerThanADecade(this DateTime date)
    {
        var oneDecadeYoungerDate = DateTime.Now.AddYears(YEARS_PER_DECADE);
        return date.IsYoungerThan(oneDecadeYoungerDate);
    }

    /// <summary>
    /// Checks if the difference between DateTime.Now and the given DateTime is more than a century.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the difference is more than a century, false otherwise.</returns>          
    public static bool IsYoungerThanACentury(this DateTime date)
    {
        var oneCenturyYoungerDate = DateTime.Now.AddYears(YEARS_PER_CENTURY);
        return date.IsYoungerThan(oneCenturyYoungerDate);
    }

    /// <summary>
    /// Checks whether the first date falls after the second date.
    /// </summary>
    /// <param name="firstDate">The first DateTime to be checked.</param>
    /// <param name="secondDate">THe second DateTime to be checked.</param>
    /// <returns>True if the first date is younger, false otherwise.</returns>
    public static bool IsYoungerThan(this DateTime firstDate, DateTime secondDate)
    {
        return firstDate.Subtract(secondDate).Ticks > 0;
    }

    #endregion

    #region "Add methods"

    /// <summary>
    /// Adds one second to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one second is added.</returns>
    public static DateTime AddASecond(this DateTime date)
    {
        return date.AddSeconds(1);
    }

    /// <summary>
    /// Adds one minute to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one minute is added.</returns>
    public static DateTime AddAMinute(this DateTime date)
    {
        return date.AddMinutes(1);
    }

    /// <summary>
    /// Adds 30 minutes to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after 30 minutes are added.</returns>
    public static DateTime AddHalfAnHour(this DateTime date)
    {
        return date.AddMinutes(30);
    }

    /// <summary>
    /// Adds one hour to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one hour is added.</returns>
    public static DateTime AddAnHour(this DateTime date)
    {
        return date.AddHours(1);
    }

    /// <summary>
    /// Adds one day to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one day is added.</returns>
    public static DateTime AddADay(this DateTime date)
    {
        return date.AddDays(1);
    }

    /// <summary>
    /// Adds one week to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one week is added.</returns>
    public static DateTime AddAWeek(this DateTime date)
    {
        return date.AddWeeks(1);
    }

    /// <summary>
    /// Adds one fortnight to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one fortnight is added.</returns>
    public static DateTime AddAFortnight(this DateTime date)
    {
        return date.AddFortnights(1);
    }

    /// <summary>
    /// Adds one month to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one month is added.</returns>
    public static DateTime AddAMonth(this DateTime date)
    {
        return date.AddMonths(1);
    }

    /// <summary>
    /// Adds one year to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one year is added.</returns>
    public static DateTime AddAYear(this DateTime date)
    {
        return date.AddYears(1);
    }

    /// <summary>
    /// Adds one decade to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one decade is added.</returns>
    public static DateTime AddADecade(this DateTime date)
    {
        return date.AddDecades(1);
    }

    /// <summary>
    /// Adds the given weeks to the given DateTime.
    /// </summary>
    /// <param name="date">The DateTime to which the weeks have to be added.</param>
    /// <param name="weeks">The number of weeks to be added.</param>
    /// <returns>The DateTime after the weeks are added.</returns>
    public static DateTime AddWeeks(this DateTime date, int weeks)
    {
        return date.AddDays(weeks * DAYS_PER_WEEK);
    }

    /// <summary>
    /// Adds the given fortnights to the given DateTime.
    /// </summary>
    /// <param name="date">The DateTime to which the fortnights have to be added.</param>
    /// <param name="fortnights">The number of fortnights to be added.</param>
    /// <returns>The DateTime after the fortnights are added.</returns>
    public static DateTime AddFortnights(this DateTime date, int fortnights)
    {
        return date.AddDays(fortnights * 14);
    }

    /// <summary>
    /// Adds one century to the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one century is added.</returns>
    public static DateTime AddACentury(this DateTime date)
    {
        return date.AddCenturies(1);
    }

    /// <summary>
    /// Adds the given decades to the given DateTime.
    /// </summary>
    /// <param name="date">The DateTime to which the decades have to be added.</param>
    /// <param name="decades">The number of decades to be added.</param>
    /// <returns>The DateTime after the decades are added.</returns>
    public static DateTime AddDecades(this DateTime date, int decades)
    {
        return date.AddYears(decades * YEARS_PER_DECADE);
    }

    /// <summary>
    /// Adds the given centuries to the given DateTime.
    /// </summary>
    /// <param name="date">The DateTime to which the centuries have to be added.</param>
    /// <param name="centuries">The number of centuries to be added.</param>
    /// <returns>The DateTime after the centuries are added.</returns>
    public static DateTime AddCenturies(this DateTime date, int centuries)
    {
        return date.AddYears(centuries * YEARS_PER_CENTURY);
    }
    #endregion

    #region Subtract methods

    /// <summary>
    /// Subtracts one second from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one second is subtracted.</returns>
    public static DateTime SubtractASecond(this DateTime date)
    {
        return date.SubtractSeconds(1);
    }

    /// <summary>
    /// Subtracts one minute from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one minute is subtracted.</returns>
    public static DateTime SubtractAMinute(this DateTime date)
    {
        return date.SubtractMinutes(1);
    }

    /// <summary>
    /// Subtracts 30 minutes from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after 30 minutes are subtracted.</returns>
    public static DateTime SubtractHalfAnHour(this DateTime date)
    {
        return date.SubtractMinutes(30);
    }

    /// <summary>
    /// Subtracts one hour from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one hour is subtracted.</returns>
    public static DateTime SubtractAnHour(this DateTime date)
    {
        return date.SubtractHours(1);
    }

    /// <summary>
    /// Subtracts one day from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one day is subtracted.</returns>
    public static DateTime SubtractADay(this DateTime date)
    {
        return date.SubtractDays(1);
    }

    /// <summary>
    /// Subtracts one week from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one week is subtracted.</returns>
    public static DateTime SubtractAWeek(this DateTime date)
    {
        return date.SubtractWeeks(1);
    }

    /// <summary>
    /// Subtracts one fortnight from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one fortnight is subtracted.</returns>
    public static DateTime SubtractAFortnight(this DateTime date)
    {
        return date.SubtractFortnights(1);
    }

    /// <summary>
    /// Subtracts one month from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one month is subtracted.</returns>
    public static DateTime SubtractAMonth(this DateTime date)
    {
        return date.SubtractMonths(1);
    }

    /// <summary>
    /// Subtracts one year from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one year is subtracted.</returns>
    public static DateTime SubtractAYear(this DateTime date)
    {
        return date.SubtractYears(1);
    }

    /// <summary>
    /// Subtracts one decade from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one decade is subtracted.</returns>
    public static DateTime SubtractADecade(this DateTime date)
    {
        return date.SubtractDecades(1);
    }

    /// <summary>
    /// Subtracts one century from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The DateTime after one century is subtracted.</returns>
    public static DateTime SubtractACentury(this DateTime date)
    {
        return date.SubtractCenturies(1);
    }

    /// <summary>
    /// Subtracts given ticks from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="ticks">Number of ticks to be subtracted.</param>
    /// <returns>The DateTime after the given ticks are subtracted.</returns>
    public static DateTime SubtractTicks(this DateTime date, int ticks)
    {
        return date.AddTicks(ticks.Negate());
    }

    /// <summary>
    /// Subtracts given milliseconds from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="milliSeconds">Number of milliseconds to be subtracted.</param>
    /// <returns>The DateTime after the given milliseconds are subtracted.</returns>
    public static DateTime SubtractMilliSeconds(this DateTime date, int milliSeconds)
    {
        return date.AddMilliseconds(milliSeconds.Negate());
    }

    /// <summary>
    /// Subtracts given seconds from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="seconds">Number of seconds to be subtracted.</param>
    /// <returns>The DateTime after the given seconds are subtracted.</returns>
    public static DateTime SubtractSeconds(this DateTime date, int seconds)
    {
        return date.AddSeconds(seconds.Negate());
    }

    /// <summary>
    /// Subtracts given minutes from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="minutes">Number of minutes to be subtracted.</param>
    /// <returns>The DateTime after the given minutes are subtracted.</returns>
    public static DateTime SubtractMinutes(this DateTime date, int minutes)
    {
        return date.AddMinutes(minutes.Negate());
    }

    /// <summary>
    /// Subtracts given hours from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="hours">Number of hours to be subtracted.</param>
    /// <returns>The DateTime after the given hours are subtracted.</returns>
    public static DateTime SubtractHours(this DateTime date, int hours)
    {
        return date.AddHours(hours.Negate());
    }

    /// <summary>
    /// Subtracts given days from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="days">Number of days to be subtracted.</param>
    /// <returns>The DateTime after the given days are subtracted.</returns>
    public static DateTime SubtractDays(this DateTime date, int days)
    {
        return date.AddDays(days.Negate());
    }

    /// <summary>
    /// Subtracts given weeks from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="weeks">Number of weeks to be subtracted.</param>
    /// <returns>The DateTime after the given weeks are subtracted.</returns>
    public static DateTime SubtractWeeks(this DateTime date, int weeks)
    {
        return date.AddWeeks(weeks.Negate());
    }

    /// <summary>
    /// Subtracts given fortnights from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="fortnights">Number of fortnights to be subtracted.</param>
    /// <returns>The DateTime after the given fortnights are subtracted.</returns>
    public static DateTime SubtractFortnights(this DateTime date, int fortnights)
    {
        return date.AddFortnights(fortnights.Negate());
    }

    /// <summary>
    /// Subtracts given months from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="months">Number of months to be subtracted.</param>
    /// <returns>The DateTime after the given months are subtracted.</returns>          
    public static DateTime SubtractMonths(this DateTime date, int months)
    {
        return date.AddMonths(months.Negate());
    }

    /// <summary>
    /// Subtracts given years from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="years">Number of years to be subtracted.</param>
    /// <returns>The DateTime after the given years are subtracted.</returns>
    public static DateTime SubtractYears(this DateTime date, int years)
    {
        return date.AddYears(years.Negate());
    }

    /// <summary>
    /// Subtracts given decades from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="decades">Number of decades to be subtracted.</param>
    /// <returns>The DateTime after the given decades are subtracted.</returns>
    public static DateTime SubtractDecades(this DateTime date, int decades)
    {
        return date.AddDecades(decades.Negate());
    }

    /// <summary>
    /// Subtracts given centuries from the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="centuries">Number of centuries to be subtracted.</param>
    /// <returns>The DateTime after the given centuries are subtracted.</returns>
    public static DateTime SubtractCenturies(this DateTime date, int centuries)
    {
        return date.AddCenturies(centuries.Negate());
    }

    #endregion

    #region "Get Duration since" methods

    /// <summary>
    /// Gets the ticks between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of ticks.</returns>              
    public static long GetTicksSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).Ticks;
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the milliseconds between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of milliseconds.</returns>
    public static long GetMilliSecondsSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).Milliseconds;
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the seconds between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of seconds.</returns>
    public static long GetSecondsSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).Seconds;
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the minutes between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of minutes.</returns>
    public static long GetMinutesSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).Minutes;
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the hours between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of hours.</returns>
    public static long GetHoursSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).Hours;
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the days between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of days.</returns>
    public static long GetDaysSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).Days;
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the weeks between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of weeks.</returns>
    public static long GetWeeksSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).GetWeeks();
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the fortnights between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of fortnights.</returns>
    public static long GetFortnightsSince(this DateTime time)
    {
        DateTime now = DateTime.Now;

        var ticks = now.Subtract(time).GetFortnights();
        return ticks.AbsoluteValue();
    }

    /// <summary>
    /// Gets the months between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of months.</returns>
    public static long GetMonthsSince(this DateTime time)
    {
        DateTime now = DateTime.Now;
        long months = -1;

        if (time.IsYoungerThan(now))
        {
            // Date lies in future so try adding months and see
            do
            {
                months++;
                now = now.AddMonths(1);
            }
            while (now.IsOlderThan(time));
        }
        else
        {
            // Date is in past, so try subtracting months and see
            do
            {
                months++;
                now = now.SubtractMonths(1);
            }
            while (now.IsYoungerThan(time));
        }

        return months;
    }

    /// <summary>
    /// Gets the years between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of years.</returns>
    public static long GetYearsSince(this DateTime time)
    {
        DateTime now = DateTime.Now;
        long years = -1;

        if (time.IsYoungerThan(now))
        {
            // Date lies in future so try adding years and see
            do
            {
                years++;
                now = now.AddYears(1);
            }
            while (now.IsOlderThan(time));
        }
        else
        {
            // Date is in past, so try subtracting years and see
            do
            {
                years++;
                now = now.SubtractYears(1);
            }
            while (now.IsYoungerThan(time));
        }

        return years;
    }

    /// <summary>
    /// Gets the decades between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of decades.</returns>
    public static long GetDecadesSince(this DateTime time)
    {
        var years = time.GetYearsSince();
        return (years / YEARS_PER_DECADE).AbsoluteValue();
    }

    /// <summary>
    /// Gets the centuries between the given time and DateTime.Now.
    /// </summary>
    /// <param name="time">The given DateTime.</param>
    /// <returns>Number of centuries.</returns>
    public static long GetCenturiesSince(this DateTime time)
    {
        var years = time.GetYearsSince();
        return (years / YEARS_PER_CENTURY).AbsoluteValue();
    }

    #endregion

    #region IsADayOfWeek

    /// <summary>
    /// Checks whether the day of given DateTime is a Monday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the day is Monday, false otherwise.</returns>
    public static bool IsAMonday(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Monday;
    }

    /// <summary>
    /// Checks whether the day of given DateTime is a Tuesday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the day is Tuesday, false otherwise.</returns>
    public static bool IsATuesday(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Tuesday;
    }

    /// <summary>
    /// Checks whether the day of given DateTime is a Wednesday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the day is Wednesday, false otherwise.</returns>
    public static bool IsAWednesday(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Wednesday;
    }

    /// <summary>
    /// Checks whether the day of given DateTime is a Thursday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the day is Thursday, false otherwise.</returns>
    public static bool IsAThursday(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Thursday;
    }

    /// <summary>
    /// Checks whether the day of given DateTime is a Friday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the day is Friday, false otherwise.</returns>
    public static bool IsAFriday(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday;
    }

    /// <summary>
    /// Checks whether the day of given DateTime is a Saturday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the day is Saturday, false otherwise.</returns>
    public static bool IsASaturday(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday;
    }

    /// <summary>
    /// Checks whether the day of given DateTime is a Sunday.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the day is Sunday, false otherwise.</returns>
    public static bool IsASunday(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Sunday;
    }

    // IsADayOfWeek
    #endregion

    #region IsInMonth

    /// <summary>
    /// Checks whether the month of the given day is January.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is January, False otherwise.</returns>
    public static bool IsInJanuary(this DateTime date)
    {
        return date.Month.Equals(JANUARY);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is February.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is February, False otherwise.</returns>
    public static bool IsInFebruary(this DateTime date)
    {
        return date.Month.Equals(FEBRUARY);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is March.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is March, False otherwise.</returns>
    public static bool IsInMarch(this DateTime date)
    {
        return date.Month.Equals(MARCH);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is April.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is April, False otherwise.</returns>
    public static bool IsInApril(this DateTime date)
    {
        return date.Month.Equals(APRIL);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is May.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is May, False otherwise.</returns>
    public static bool IsInMay(this DateTime date)
    {
        return date.Month.Equals(MAY);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is June.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is June, False otherwise.</returns>
    public static bool IsInJune(this DateTime date)
    {
        return date.Month.Equals(JUNE);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is July.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is July, False otherwise.</returns>
    public static bool IsInJuly(this DateTime date)
    {
        return date.Month.Equals(JULY);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is August.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is August, False otherwise.</returns>
    public static bool IsInAugust(this DateTime date)
    {
        return date.Month.Equals(AUGUST);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is September.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is January, False otherwise.</returns>
    public static bool IsInSeptember(this DateTime date)
    {
        return date.Month.Equals(SEPTEMBER);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is October.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is October, False otherwise.</returns>
    public static bool IsInOctober(this DateTime date)
    {
        return date.Month.Equals(OCTOBER);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is November.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is November, False otherwise.</returns>
    public static bool IsInNovember(this DateTime date)
    {
        return date.Month.Equals(NOVEMBER);
    }

    /// <summary>
    /// Checks whether the month of the given DateTime is December.
    /// </summary>
    /// <param name="date">DateTime to be checked.</param>
    /// <returns>True if the month of given day is December, False otherwise.</returns>
    public static bool IsInDecember(this DateTime date)
    {
        return date.Month.Equals(DECEMBER);
    }

    // IsInMonth
    #endregion

    #region GetFirstOfMonth

    /// <summary>
    /// Gets the first occurrence of the given day of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="day">The day to be found.</param>
    /// <returns>DateTime instance of the first occurrence of the given day.</returns>
    public static DateTime GetFirstDayOccurrenceOfTheMonth(this DateTime date, DayOfWeek day)
    {
        var firstDayOfMonth = date.GetFirstDayOfTheMonth();
        return firstDayOfMonth.DayOfWeek == day ? firstDayOfMonth : firstDayOfMonth.GetNextDay(day);
    }

    /// <summary>
    /// Gets the first Monday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Monday of the given month.</returns>
    public static DateTime GetFirstMondayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Monday);
    }

    /// <summary>
    /// Gets the first Tuesday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Tuesday of the given month.</returns>
    public static DateTime GetFirstTuesdayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Tuesday);
    }

    /// <summary>
    /// Gets the first Wednesday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Wednesday of the given month.</returns>
    public static DateTime GetFirstWednesdayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Wednesday);
    }

    /// <summary>
    /// Gets the first Thursday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Thursday of the given month.</returns>
    public static DateTime GetFirstThursdayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Thursday);
    }

    /// <summary>
    /// Gets the first Friday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Friday of the given month.</returns>
    public static DateTime GetFirstFridayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Friday);
    }

    /// <summary>
    /// Gets the first Saturday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Saturday of the given month.</returns>
    public static DateTime GetFirstSaturdayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Saturday);
    }

    /// <summary>
    /// Gets the first Sunday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Sunday of the given month.</returns>
    public static DateTime GetFirstSundayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheMonth(DayOfWeek.Sunday);
    }

    /// <summary>
    /// Gets the first day of the month of the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first day of the month.</returns>
    public static DateTime GetFirstDayOfTheMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    /// <summary>
    /// Gets the last day of the month of the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last day of the month.</returns>
    public static DateTime GetLastDayOfTheMonth(this DateTime date)
    {
        return date.GetFirstDayOfTheMonth().AddAMonth().SubtractADay();
    }

    /// <summary>
    /// Gets the last occurrence of the given day of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="day">The day to be found.</param>
    /// <returns>DateTime instance of the last occurrence of the given day.</returns>
    public static DateTime GetLastDayOccurrenceOfTheMonth(this DateTime date, DayOfWeek day)
    {
        var lastDayOfMonth = date.GetLastDayOfTheMonth();
        return lastDayOfMonth.DayOfWeek == day ? lastDayOfMonth : lastDayOfMonth.GetPreviousDay(day);
    }

    /// <summary>
    /// Gets the last Monday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Monday of the given month.</returns>
    public static DateTime GetLastMondayOfTheMonth(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Monday);
    }

    /// <summary>
    /// Gets the last Tuesday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Tuesday of the given month.</returns>
    public static DateTime GetLastTuesdayOfTheMonth(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Tuesday);
    }

    /// <summary>
    /// Gets the last Wednesday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Wednesday of the given month.</returns>
    public static DateTime GetLastWednesdayOfTheMonth(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Wednesday);
    }

    /// <summary>
    /// Gets the last Thursday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Thursday of the given month.</returns>
    public static DateTime GetLastThursdayOfTheMonth(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Thursday);
    }

    /// <summary>
    /// Gets the last Friday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Friday of the given month.</returns>
    public static DateTime GetLastFridayOfTheMonth(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Friday);
    }

    /// <summary>
    /// Gets the last Saturday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Saturday of the given month.</returns>
    public static DateTime GetLastSaturdayOfTheMonth(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Saturday);
    }

    /// <summary>
    /// Gets the last Sunday of the month in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Sunday of the given month.</returns>
    public static DateTime GetLastSundayOfTheMonth(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheMonth(DayOfWeek.Sunday);
    }

    // GetFirstOfMonth
    #endregion

    #region GetFirstOfYear

    /// <summary>
    /// Gets the first occurrence of the given day of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="day">The day to be found.</param>
    /// <returns>DateTime instance of the first occurrence of the given day.</returns>
    public static DateTime GetFirstDayOccurrenceOfTheYear(this DateTime date, DayOfWeek day)
    {
        var firstDayOfYear = date.GetFirstDayOfTheYear();
        return firstDayOfYear.DayOfWeek == day ? firstDayOfYear : firstDayOfYear.GetNextDay(day);
    }

    /// <summary>
    /// Gets the first Monday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Monday of the given year.</returns>
    public static DateTime GetFirstMondayOfTheYear(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Monday);
    }

    /// <summary>
    /// Gets the first Tuesday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Tuesday of the given year.</returns>
    public static DateTime GetFirstTuesdayOfTheYear(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Tuesday);
    }

    /// <summary>
    /// Gets the first Wednesday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Wednesday of the given year.</returns>
    public static DateTime GetFirstWednesdayOfTheYear(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Wednesday);
    }

    /// <summary>
    /// Gets the first Thursday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Thursday of the given year.</returns>
    public static DateTime GetFirstThursdayOfTheYear(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Thursday);
    }

    /// <summary>
    /// Gets the first Friday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Friday of the given year.</returns>
    public static DateTime GetFirstFridayOfTheYear(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Friday);
    }

    /// <summary>
    /// Gets the first Saturday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Saturday of the given year.</returns>
    public static DateTime GetFirstSaturdayOfTheYear(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Saturday);
    }

    /// <summary>
    /// Gets the first Sunday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first Sunday of the given year.</returns>
    public static DateTime GetFirstSundayOfTheYear(this DateTime date)
    {
        return date.GetFirstDayOccurrenceOfTheYear(DayOfWeek.Sunday);
    }

    /// <summary>
    /// Gets the first day of the year of the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the first day of the year.</returns>
    public static DateTime GetFirstDayOfTheYear(this DateTime date)
    {
        return new DateTime(date.Year, 1, 1);
    }

    /// <summary>
    /// Gets the last day of the year of the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last day of the year.</returns>
    public static DateTime GetLastDayOfTheYear(this DateTime date)
    {
        return new DateTime(date.Year, 12, 31);
    }

    /// <summary>
    /// Gets the last occurrence of the given day of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="day">The day to be found.</param>
    /// <returns>DateTime instance of the last occurrence of the given day.</returns>
    public static DateTime GetLastDayOccurrenceOfTheYear(this DateTime date, DayOfWeek day)
    {
        var lastDayOfYear = date.GetLastDayOfTheYear();
        return lastDayOfYear.DayOfWeek == day ? lastDayOfYear : lastDayOfYear.GetPreviousDay(day);
    }

    /// <summary>
    /// Gets the last Monday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Monday of the given year.</returns>
    public static DateTime GetLastMondayOfTheYear(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Monday);
    }

    /// <summary>
    /// Gets the last Tuesday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Tuesday of the given year.</returns>
    public static DateTime GetLastTuesdayOfTheYear(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Tuesday);
    }

    /// <summary>
    /// Gets the last Wednesday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Wednesday of the given year.</returns>
    public static DateTime GetLastWednesdayOfTheYear(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Wednesday);
    }

    /// <summary>
    /// Gets the last Thursday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Thursday of the given year.</returns>
    public static DateTime GetLastThursdayOfTheYear(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Thursday);
    }

    /// <summary>
    /// Gets the last Friday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Friday of the given year.</returns>
    public static DateTime GetLastFridayOfTheYear(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Friday);
    }

    /// <summary>
    /// Gets the last Saturday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Saturday of the given year.</returns>
    public static DateTime GetLastSaturdayOfTheYear(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Saturday);
    }

    /// <summary>
    /// Gets the last Sunday of the year in the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>DateTime instance of the last Sunday of the given year.</returns>
    public static DateTime GetLastSundayOfTheYear(this DateTime date)
    {
        return date.GetLastDayOccurrenceOfTheYear(DayOfWeek.Sunday);
    }

    // GetFirstOfYear
    #endregion

    #region GetNext

    /// <summary>
    /// Gets the next Monday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of next Monday.</returns>
    public static DateTime GetNextMonday(this DateTime date)
    {
        return date.GetNextDay(DayOfWeek.Monday);
    }

    /// <summary>
    /// Gets the next Tuesday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of next Tuesday.</returns>
    public static DateTime GetNextTuesday(this DateTime date)
    {
        return date.GetNextDay(DayOfWeek.Tuesday);
    }

    /// <summary>
    /// Gets the next Wednesday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of next Wednesday.</returns>
    public static DateTime GetNextWednesday(this DateTime date)
    {
        return date.GetNextDay(DayOfWeek.Wednesday);
    }

    /// <summary>
    /// Gets the next Thursday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of next Thursday.</returns>
    public static DateTime GetNextThursday(this DateTime date)
    {
        return date.GetNextDay(DayOfWeek.Thursday);
    }

    /// <summary>
    /// Gets the next Friday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of next Friday.</returns>
    public static DateTime GetNextFriday(this DateTime date)
    {
        return date.GetNextDay(DayOfWeek.Friday);
    }

    /// <summary>
    /// Gets the next Saturday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of next Saturday.</returns>
    public static DateTime GetNextSaturday(this DateTime date)
    {
        return date.GetNextDay(DayOfWeek.Saturday);
    }

    /// <summary>
    /// Gets the next Sunday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of next Sunday.</returns>
    public static DateTime GetNextSunday(this DateTime date)
    {
        return date.GetNextDay(DayOfWeek.Sunday);
    }

    /// <summary>
    /// Gets the next given day from the given DateTime (ex search for next occurrence of Monday).
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <param name="day">The day to be found out.</param>
    /// <returns>DateTime instance of the next given day.</returns>
    public static DateTime GetNextDay(this DateTime date, DayOfWeek day)
    {
        var givenDate = date.AddADay();

        while (givenDate.DayOfWeek != day)
        {
            givenDate = givenDate.AddADay();
        }

        return givenDate;
    }

    // GetNext
    #endregion

    #region GetPrevious

    /// <summary>
    /// Gets the previous Monday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of previous Monday.</returns>
    public static DateTime GetPreviousMonday(this DateTime date)
    {
        return date.GetPreviousDay(DayOfWeek.Monday);
    }

    /// <summary>
    /// Gets the previous Tuesday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of previous Tuesday.</returns>
    public static DateTime GetPreviousTuesday(this DateTime date)
    {
        return date.GetPreviousDay(DayOfWeek.Tuesday);
    }

    /// <summary>
    /// Gets the previous Wednesday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of previous Wednesday.</returns>
    public static DateTime GetPreviousWednesday(this DateTime date)
    {
        return date.GetPreviousDay(DayOfWeek.Wednesday);
    }

    /// <summary>
    /// Gets the previous Thursday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of previous Thursday.</returns>
    public static DateTime GetPreviousThursday(this DateTime date)
    {
        return date.GetPreviousDay(DayOfWeek.Thursday);
    }

    /// <summary>
    /// Gets the previous Friday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of previous Friday.</returns>
    public static DateTime GetPreviousFriday(this DateTime date)
    {
        return date.GetPreviousDay(DayOfWeek.Friday);
    }

    /// <summary>
    /// Gets the previous Saturday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of previous Saturday.</returns>
    public static DateTime GetPreviousSaturday(this DateTime date)
    {
        return date.GetPreviousDay(DayOfWeek.Saturday);
    }

    /// <summary>
    /// Gets the previous Sunday from the given DateTime.
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <returns>DateTime instance of previous Sunday.</returns>
    public static DateTime GetPreviousSunday(this DateTime date)
    {
        return date.GetPreviousDay(DayOfWeek.Sunday);
    }

    /// <summary>
    /// Gets the previous given day from the given DateTime (ex Find previous occurence of Monday).
    /// </summary>
    /// <param name="date">The starting DateTime.</param>
    /// <param name="day">The day to be found out.</param>
    /// <returns>DateTime instance of the previous given day.</returns>
    public static DateTime GetPreviousDay(this DateTime date, DayOfWeek day)
    {
        var givenDate = date.SubtractADay();
        while (givenDate.DayOfWeek != day)
        {
            givenDate = givenDate.SubtractADay();
        }

        return givenDate;
    }

    // GetPrevious
    #endregion

    #region GetString

    /// <summary>
    /// Gets the day string of the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation of day.</returns>
    /// <example>Returns "Sunday" for the date 1.1.2012.</example>
    public static string GetDayString(this DateTime date)
    {
        return date.DayOfWeek.ToString();
    }

    /// <summary>
    /// Gets the month string of the given DateTime.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation of month.</returns>
    /// <example>Returns "January" for the date 1.1.2012.</example>
    public static string GetMonthString(this DateTime date)
    {
        return date.ToString("MMMM");
    }

    // GetString
    #endregion

    #region DD/MM/YY methods

    /// <summary>
    /// Formats the given DateTime to "dd/MM/yy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01/01/12" for the date 1.1.2012.</example>
    public static string ToDdMmYySlash(this DateTime date)
    {
        return date.ToString("dd/MM/yy");
    }

    /// <summary>
    /// Formats the given DateTime to "dd.MM.yy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01.01.12" for the date 1.1.2012.</example>
    public static string ToDdMmYyDot(this DateTime date)
    {
        return date.ToString("dd.MM.yy");
    }

    /// <summary>
    /// Formats the given DateTime to "dd-MM-yy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01-01-12" for the date 1.1.2012.</example>
    public static string ToDdMmYyHyphen(this DateTime date)
    {
        return date.ToString("dd-MM-yy");
    }

    /// <summary>
    /// Formats the given DateTime to "ddMMyy" by applying the given separator.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="separator">The given separator.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01,01,12" for the date 1.1.2012 and separator ,.</example>
    public static string ToDdMmYyWithSep(this DateTime date, string separator)
    {
        return date.ToString(string.Format("dd{0}MM{0}yy", separator));
    }

    #endregion

    #region DD/MM/YYYY methods

    /// <summary>
    /// Formats the given DateTime to "dd/MM/yyyy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01/01/2012" for the date 1.1.2012.</example>
    public static string ToDdMmYyyySlash(this DateTime date)
    {
        return date.ToString("dd/MM/yyyy");
    }

    /// <summary>
    /// Formats the given DateTime to "dd.MM.yyyy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01.01.2012" for the date 1.1.2012.</example>
    public static string ToDdMmYyyyDot(this DateTime date)
    {
        return date.ToString("dd.MM.yyyy");
    }

    /// <summary>
    /// Formats the given DateTime to "dd-MM-yyyy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01-01-2012" for the date 1.1.2012.</example>
    public static string ToDdMmYyyyHyphen(this DateTime date)
    {
        return date.ToString("dd-MM-yyyy");
    }

    /// <summary>
    /// Formats the given DateTime to "ddMMyyyy" by applying the given separator.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="separator">The given separator.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "01,01,2012" for the given DateTime 1.1.2012 and separator ,.</example>
    public static string ToDdMmYyyyWithSep(this DateTime date, string separator)
    {
        return date.ToString(string.Format("dd{0}MM{0}yyyy", separator));
    }

    #endregion

    #region MM/DD/YY methods

    /// <summary>
    /// Formats the given DateTime to "MM/dd/yy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12/01/12" for the date 1.12.2012.</example>
    public static string ToMmDdYySlash(this DateTime date)
    {
        return date.ToString("MM/dd/yy");
    }

    /// <summary>
    /// Formats the given DateTime to "MM.dd.yy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12.01.12" for the date 1.12.2012.</example>
    public static string ToMmDdYyDot(this DateTime date)
    {
        return date.ToString("MM.dd.yy");
    }

    /// <summary>
    /// Formats the given DateTime to "MM-dd-yy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12-01-12" for the date 1.12.2012.</example>
    public static string ToMmDdYyHyphen(this DateTime date)
    {
        return date.ToString("MM-dd-yy");
    }

    /// <summary>
    /// Formats the given DateTime to "MMddyy" by applying the given separator.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="separator">The given separator.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12,01,12" for the given DateTime1.12.2012 and separator ,.</example>
    public static string ToMmDdYyWithSep(this DateTime date, string separator)
    {
        return date.ToString(string.Format("MM{0}dd{0}yy", separator));
    }

    #endregion

    #region MM/DD/YYYY methods

    /// <summary>
    /// Formats the given DateTime to "MM/dd/yyyy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12/01/2012" for the date 1.12.2012.</example>
    public static string ToMmDdYyyySlash(this DateTime date)
    {
        return date.ToString("MM/dd/yyyy");
    }

    /// <summary>
    /// Formats the given DateTime to "MM.dd.yyyy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12.01.2012" for the date 1.12.2012.</example>
    public static string ToMmDdYyyyDot(this DateTime date)
    {
        return date.ToString("MM.dd.yyyy");
    }

    /// <summary>
    /// Formats the given DateTime to "MM-dd-yyyy".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12-01-2012" for the date 1.12.2012.</example>
    public static string ToMmDdYyyyHyphen(this DateTime date)
    {
        return date.ToString("MM-dd-yyyy");
    }

    /// <summary>
    /// Formats the given DateTime to "MMddyyyy" by applying the given separator.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="separator">The given separator.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12,01,2012" for the given DateTime1.12.2012 and separator ,.</example>
    public static string ToMmDdYyyyWithSep(this DateTime date, string separator)
    {
        return date.ToString(string.Format("MM{0}dd{0}yyyy", separator));
    }

    #endregion

    #region YY/MM/DD methods

    /// <summary>
    /// Formats the given DateTime to "yy/MM/dd".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12/11/30" for the date 30.11.2012.</example>
    public static string ToYyMmDdSlash(this DateTime date)
    {
        return date.ToString("yy/MM/dd");
    }

    /// <summary>
    /// Formats the given DateTime to "yy.MM.dd".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12.11.30" for the date 30.11.2012.</example>
    public static string ToYyMmDdDot(this DateTime date)
    {
        return date.ToString("yy.MM.dd");
    }

    /// <summary>
    /// Formats the given DateTime to "yy-MM-dd".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12-11-30" for the date 30.11.2012.</example>
    public static string ToYyMmDdHyphen(this DateTime date)
    {
        return date.ToString("yy-MM-dd");
    }

    /// <summary>
    /// Formats the given DateTime to "yyMMdd" by applying the given separator.
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="separator">The given separator.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "12,11,30" for the given DateTime30.11.2012 and separator ,.</example>
    public static string ToYyMmDdWithSep(this DateTime date, string separator)
    {
        return date.ToString(string.Format("yy{0}MM{0}dd", separator));
    }

    #endregion

    #region YYYY/MM/DD methods

    /// <summary>
    /// Formats the given DateTime to "yyyy/MM/dd".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "2012/11/30" for the date 30.11.2012.</example>          
    public static string ToYyyyMmDdSlash(this DateTime date)
    {
        return date.ToString("yyyy/MM/dd");
    }

    /// <summary>
    /// Formats the given DateTime to "yyyy.MM.dd".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "2012.11.30" for the date 30.11.2012.</example>           
    public static string ToYyyyMmDdDot(this DateTime date)
    {
        return date.ToString("yyyy.MM.dd");
    }

    /// <summary>
    /// Formats the given DateTime to "yyyy-MM-dd".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "2012-11-30" for the date 30.11.2012.</example>           
    public static string ToYyyyMmDdHyphen(this DateTime date)
    {
        return date.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// Formats the given DateTime to "yyyyMMdd".
    /// </summary>
    /// <param name="date">The given DateTime.</param>
    /// <param name="separator">The given separator.</param>
    /// <returns>The string representation according to the format.</returns>
    /// <example>Returns "2012,11,30" for the given DateTime30.11.2012 and separator ,.</example>           
    public static string ToYyyyMmDdWithSep(this DateTime date, string separator)
    {
        return date.ToString(string.Format("yyyy{0}MM{0}dd", separator));
    }

    #endregion
}
