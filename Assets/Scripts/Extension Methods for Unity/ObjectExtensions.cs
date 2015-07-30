using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Object extensions
/// </summary>
public static class ObjectExtensions
{
    #region IsA

    /// <summary>
    /// Checks whether the given object is of {T}.
    /// </summary>
    /// <param name="obj">The object to be checked.</param>
    /// <typeparam name="T">Refers the target data type.</typeparam>
    /// <returns>True if the given object is of type T, false otherwise.</returns>
    public static bool IsA <T>(this object obj)
    {
        return obj is T;
    }

    // IsA

    #endregion

    #region IsNotA

    /// <summary>
    /// Checks whether the given object is NOT of type T.
    /// </summary>
    /// <param name="obj">The object to be checked.</param>
    /// <typeparam name="T">Refers the target data type.</typeparam>
    /// <returns>True if the given object is NOT of type T, false otherwise.</returns>
    public static bool IsNotA <T>(this object obj)
    {
        return obj.IsA<T>().Toggle();
    }

    // IsNotA

    #endregion

    #region As

    /// <summary>
    /// Tries to cast the given object to type T
    /// </summary>
    /// <param name="obj">The object to be casted.</param>
    /// <typeparam name="T">Refers target data type.</typeparam>
    /// <returns>Returns the casted objects. Null if casting fails.</returns>
    public static T As <T>(this object obj) where T : class
    {
        return obj as T;
    }

    // As

    #endregion

    #region IsNull

    /// <summary>
    /// Checks whether the given object is Null.
    /// </summary>
    /// <param name="obj">The object to be checked.</param>
    /// <returns>True if the object is Null, false otherwise.</returns>
    //public static bool IsNull(this object obj)
    //{
    //    return obj == null;
    //}

    // IsNull

    #endregion

    #region IsNotNull

    /// <summary>
    /// Checks whether the given object is NOT Null.
    /// </summary>
    /// <param name="obj">The object to be checked.</param>
    /// <returns>True if the object is NOT Null, false otherwise.</returns>
    //public static bool IsNotNull(this object obj)
    //{
    //    return obj.IsNull().Toggle();
    //}

    // IsNotNull

    #endregion

    #region HasValue

    /// <summary>
    /// Checks whether the given object has some value. Similar to IsNotNull().
    /// </summary>
    /// <param name="obj">The object to be checked.</param>
    /// <returns>True if the object is NOT Null, false otherwise.</returns>
    public static bool HasValue(this object obj)
    {
        return !(obj == null);
    }

    // HasValue

    #endregion

    #region Clone

    /// <summary>
    /// Makes a copy from the object.
    /// Doesn't copy the reference memory, only data.
    /// </summary>
    /// <typeparam name="T">Type of the return object.</typeparam>
    /// <param name="item">Object to be copied.</param>
    /// <returns>Returns the copied object.</returns>
    public static T Clone<T>(this object item) where T : class
    {
        return (item != null) ?
            item.XMLSerialize_ToString().XMLDeserialize_ToObject<T>() :
            default(T);
    }

    // Clone
    #endregion
}