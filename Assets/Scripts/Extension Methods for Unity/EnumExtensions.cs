using System;
using System.Linq;
using System.Collections.Generic;

/* *****************************************************************************
 * File:    EnumExtensions.cs
 * Author:  Philip Pierce - Wednesday, September 24, 2014
 * Description:
 *  Extensions for Enums
 *  
 * History:
 *  Wednesday, September 24, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for Enums
/// </summary>
public static class EnumExtensions
{
    #region ToEnum

    /// <summary>
    /// Converts a string to an enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="s"></param>
    /// <param name="ignoreCase">true to ignore casing in the string</param>
    public static T ToEnum<T>(this string s, bool ignoreCase) where T : struct
    {
        // exit if null
        if (s.IsNullOrEmpty())
            return default(T);

        Type genericType = typeof(T);
        if (!genericType.IsEnum)
            return default(T);

        try
        {
            return (T) Enum.Parse(genericType, s, ignoreCase);
        }

        catch (Exception)
        {
            // couldn't parse, so try a different way of getting the enums
            Array ary = Enum.GetValues(genericType);
            foreach (T en in ary.Cast<T>()
                .Where(en => 
                    (string.Compare(en.ToString(), s, ignoreCase) == 0) ||
                    (string.Compare((en as Enum).ToString(), s, ignoreCase) == 0)))
                    {
                        return en;
                    }

            return default(T);
        }
    }

    /// <summary>
    /// Converts a string to an enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="s"></param>
    public static T ToEnum<T>(this string s) where T : struct
    {
        return s.ToEnum<T>(false);
    }

    // ToEnum
    #endregion
}