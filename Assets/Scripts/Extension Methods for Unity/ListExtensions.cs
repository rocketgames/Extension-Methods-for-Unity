using System;
using System.Collections.Generic;
using System.Linq;

/* *****************************************************************************
 * File:    ListExtensions.cs
 * Author:  Philip Pierce - Tuesday, September 09, 2014
 * Description:
 *  Extensions for Lists, Arrays, Dictionaries, etc
 *  
 * History:
 *  Tuesday, September 09, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for Lists, Arrays, Dictionaries, etc
/// </summary>
public static class ListExtensions
{
    #region IsNullOrEmpty

    /// <summary>
    /// Returns true if the array is null or empty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this T[] data)
    {
        return ((data == null) || (data.Length == 0));
    }

    /// <summary>
    /// Returns true if the list is null or empty
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T>(this List<T> data)
    {
        return ((data == null) || (data.Count == 0));
    }

    /// <summary>
    /// Returns true if the dictionary is null or empty
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty<T1, T2>(this Dictionary<T1,T2> data)
    {
        return ((data == null) || (data.Count == 0));
    }

    // IsNullOrEmpty
    #endregion

    #region RemoveDuplicates

    /// <summary>
    /// Removes items from a collection based on the condition you provide. This is useful if a query gives 
    /// you some duplicates that you can't seem to get rid of. Some Linq2Sql queries are an example of this. 
    /// Use this method afterward to strip things you know are in the list multiple times
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="Predicate"></param>
    /// <remarks>http://extensionmethod.net/csharp/icollection-t/removeduplicates</remarks>
    /// <returns></returns>
    public static IEnumerable<T> RemoveDuplicates<T>(this ICollection<T> list, Func<T, int> Predicate)
    {
        var dict = new Dictionary<int, T>();

        foreach (var item in list)
        {
            if (!dict.ContainsKey(Predicate(item)))
            {
                dict.Add(Predicate(item), item);
            }
        }

        return dict.Values.AsEnumerable();
    }

    // RemoveDuplicates
    #endregion

    #region DequeueOrNull

    /// <summary>
    /// deques an item, or returns null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="q"></param>
    /// <returns></returns>
    public static T DequeueOrNull<T>(this Queue<T> q)
    {
        try
        {
            return (q.Count > 0) ? q.Dequeue() : default(T);
        }

        catch (Exception)
        {
            return default(T);
        }
    }

    // DequeueOrNull
    #endregion
}