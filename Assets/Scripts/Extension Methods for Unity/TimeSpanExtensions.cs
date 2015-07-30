using System;
using System.Linq;
using System.Collections.Generic;

/* *****************************************************************************
 * File:    TimeSpanExtensions.cs
 * Author:  Philip Pierce - Thursday, October 02, 2014
 * Description:
 *  Extensions for TimeSpan
 *  
 * History:
 *  Thursday, October 02, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for TimeSpan
/// </summary>
public static class TimeSpanExtensions
{
    #region GetWeeks

    /// <summary>
    /// Gets the number of weeks in the given time span.
    /// </summary>
    /// <param name="span">The given time span.</param>
    /// <returns>The number of weeks.</returns>
    public static int GetWeeks(this TimeSpan span)
    {
        return span.Days / DateTimeExtensions.DAYS_PER_WEEK;
    }

    // GetWeeks
    #endregion

    #region GetFortnights

    /// <summary>
    /// Gets the number of fortnights in the given time span.
    /// </summary>
    /// <param name="span">The given time span.</param>
    /// <returns>The number of fortnights.</returns>          
    public static int GetFortnights(this TimeSpan span)
    {
        return span.GetWeeks() / DateTimeExtensions.WEEKS_PER_FORTNIGHT;
    }

    // GetFortnights
    #endregion

    #region SecondsToTimeSpan

    /// <summary>
    /// Creates a timespan with <paramref name="seconds"/> seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public static TimeSpan SecondsToTimeSpan(this int seconds)
    {
        return TimeSpan.FromSeconds(seconds);
    }

    // SecondsToTimeSpan
    #endregion

    #region MinutesToTimeSpan

    /// <summary>
    /// Creates a timespan with <paramref name="minutes"/> minutes
    /// </summary>
    /// <param name="minutes"></param>
    /// <returns></returns>
    public static TimeSpan MinutesToTimeSpan(this int minutes)
    {
        return TimeSpan.FromMinutes(minutes);
        
    }

    // MinutesToTimeSpan
    #endregion
}
