using System.Xml.Linq;

/* *****************************************************************************
 * File:    XMLExtensions.cs
 * Author:  Philip Pierce - Thursday, September 18, 2014
 * Description:
 *  Extensions for LINQ to XML and XElements
 *  
 * History:
 *  Thursday, September 18, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for LINQ to XML and XElements
/// </summary>
public static class XMLExtensions
{
    #region GetValueOrNull

    /// <summary>
    /// Returns the Value of the element, or null if the element is null
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static string GetValueOrNull(this XElement element)
    {
        return (element != null) ? element.Value : null;
    }

    // GetValueOrNull
    #endregion

    #region GetValueString

    /// <summary>
    /// Returns the Value of the element, or string.empty if the element is null
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static string GetValueString(this XElement element)
    {
        return (element != null) ? element.Value : string.Empty;
    }

    // GetValueString
    #endregion

    #region ValueToDecimalNullable

    /// <summary>
    /// Returns a nullable decimal
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static decimal? ValueToDecimalNullable(this XElement element)
    {
        return (element != null) ? element.Value.ToDecimalNull() : null;
    }

    // ValueToDecimalNullable
    #endregion

    #region ValueToIntNullable

    /// <summary>
    /// Returns a nullable int
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static int? ValueToIntNullable(this XElement element)
    {
        return (element != null) ? element.Value.ToIntNull() : null;
    }

    // ValueToIntNullable
    #endregion

    #region ValueToLongNullable

    /// <summary>
    /// Returns a nullable long
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static long? ValueToLongNullable(this XElement element)
    {
        return (element != null) ? element.Value.ToLongNull() : null;
    }

    // ValueToLongNullable
    #endregion

    #region ValueToFloatNullable

    /// <summary>
    /// Returns a nullable float
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static float? ValueToFloatNullable(this XElement element)
    {
        return (element != null) ? element.Value.ToFloatNull() : null;
    }

    // ValueToFloatNullable
    #endregion
}
