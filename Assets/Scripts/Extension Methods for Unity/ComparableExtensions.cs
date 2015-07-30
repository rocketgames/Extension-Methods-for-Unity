using System;
using System.Linq;
using System.Collections.Generic;

/* *****************************************************************************
 * File:    ComparableExtensions.cs
 * Author:  Philip Pierce - Wednesday, October 01, 2014
 * Description:
 *  Extensions for comparisons
 *  
 * History:
 *  Wednesday, October 01, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for comparisons
/// </summary>
public static class ComparableExtensions
{
    #region IsBetweenInclusive

    /// <summary>
    /// Returns true if the actual value is between lower and upper, Inclusive (ie, lower an upper are both allowed in the test)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="actual">actual value to test</param>
    /// <param name="lower">inclusive lower limit</param>
    /// <param name="upper">inclusive upper limit</param>
    /// <returns></returns>
    public static bool IsBetweenInclusive<T>(this T actual, T lower, T upper) where T : IComparable<T>
    {
        return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) <= 0;
    }

    // IsBetweenInclusive
    #endregion

    #region IsBetweenExclusive

    /// <summary>
    /// Returns true if the actual value is between lower and upper, Exclusive (ie, lower allowed in the test, upper is not allowed in the test)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="actual">actual value to test</param>
    /// <param name="lower">inclusive lower limit</param>
    /// <param name="upper">exclusive upper limit</param>
    /// <returns></returns>
    public static bool IsBetweenExclusive<T>(this T actual, T lower, T upper) where T : IComparable<T>
    {
        return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
    }

    // IsBetweenExclusive
    #endregion
}
