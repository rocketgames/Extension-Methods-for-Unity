using System;
using System.Linq;
using System.Collections.Generic;

/* *****************************************************************************
 * File:    GenericExtensions.cs
 * Author:  Philip Pierce - Thursday, September 18, 2014
 * Description:
 *  Generic (T) Extensions
 *  
 * History:
 *  Thursday, September 18, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Generic (T) Extensions
/// </summary>
public static class GenericExtensions
{
    #region IsIn

    /// <summary>
    /// Returns true if <paramref name="source"/> equals any of the items in <paramref name="list"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsIn<T>(this T source, params T[] list) where T : class
    {
        // return false if the source or list are null
        // otherwise, scan the list
        return (source != null) && (! list.IsNullOrEmpty()) && (list.Contains(source));
    }

    /// <summary>
    /// Returns true if <paramref name="source"/> equals any of the items in <paramref name="list"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsIn<T>(this T source, params T?[] list) where T : struct
    {
        // return false if the list is null
        // otherwise, scan the list
        return (!list.IsNullOrEmpty()) && (list.Contains(source));
    }

    /// <summary>
    /// Returns true if <paramref name="source"/> equals any of the items in <paramref name="list"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsIn(this int source, params int[] list)
    {
        // return false if the list is null
        // otherwise, scan the list
        return (!list.IsNullOrEmpty()) && (list.Contains(source));
    }

    // IsIn
    #endregion

    #region IsNotIn

    /// <summary>
    /// Returns true if <paramref name="source"/> does not equal all of the items in <paramref name="list"/> 
    /// NOTE: returns false if source is null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsNotIn<T>(this T source, params T[] list) where T : class
    {
        // false if null
        if (source == null)
            return false;

        // return true if the list is empty
        if (list.IsNullOrEmpty())
            return true;

        // otherwise, scan the list
        return (!list.Contains(source));
    }

    /// <summary>
    /// Returns true if <paramref name="source"/> does not equal all of the items in <paramref name="list"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsNotIn<T>(this T source, params T?[] list) where T : struct
    {
        // return true if the list is empty
        if (list.IsNullOrEmpty())
            return true;

        // otherwise, scan the list
        return (!list.Contains(source));
    }

    /// <summary>
    /// Returns true if <paramref name="source"/> does not equal all of the items in <paramref name="list"/> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool IsNotIn(this int source, params int[] list)
    {
        // return true if the list is empty
        if (list.IsNullOrEmpty())
            return true;

        // otherwise, scan the list
        return (!list.Contains(source));
    }

    // IsNotIn
    #endregion

    #region AsList

    /// <summary>
    /// Wraps the given object into a List{T} and returns the list.
    /// </summary>
    /// <param name="tobject">The object to be wrapped.</param>
    /// <typeparam name="T">Refers the object to be returned as List{T}.</typeparam>
    /// <returns>Returns List{T}.</returns>
    public static List<T> AsList<T>(this T tobject)
    {
        return new List<T> { tobject };
    }

    // AsList
    #endregion

    #region IsTNull

    /// <summary>
    /// Returns true if the generic T is null or default. 
    /// This will match: null for classes; null (empty) for Nullable&lt;T&gt;; zero/false/etc for other structs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tObj"></param>
    /// <returns></returns>
    public static bool IsTNull<T>(this T tObj)
    {
        return (EqualityComparer<T>.Default.Equals(tObj, default(T)));
    }

    // IsTNull
    #endregion
}