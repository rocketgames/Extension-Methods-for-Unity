using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Boolean extensions
/// </summary>
public static class BoolExtensions
{
    #region IsTrue

    /// <summary>
    /// Checks whether the given boolean item is true.
    /// </summary>
    /// <param name="item">Item to be checked.</param>
    /// <returns>True if the value is true, false otherwise.</returns>
    public static bool IsTrue(this bool item)
    {
        return item;
    }

    // IsTrue

    #endregion

    #region IsFalse

    /// <summary>
    /// Checks whether the given boolean item is false.
    /// </summary>
    /// <param name="item">Item to be checked.</param>
    /// <returns>True if the value is false, false otherwise.</returns>
    public static bool IsFalse(this bool item)
    {
        return !item;
    }

    // IsFalse

    #endregion

    #region IsNotTrue

    /// <summary>
    /// Checks whether the given boolean item is NOT true.
    /// </summary>
    /// <param name="item">Item to be checked.</param>
    /// <returns>True if the item is false, false otherwise.</returns>
    public static bool IsNotTrue(this bool item)
    {
        return !item.IsTrue();
    }

    // IsNotTrue

    #endregion

    #region IsNotFalse

    /// <summary>
    /// Checks whether the given boolean item is NOT false.
    /// </summary>
    /// <param name="item">Item to be checked.</param>
    /// <returns>True if the value is true, false otherwise.</returns>
    public static bool IsNotFalse(this bool item)
    {
        return !item.IsFalse();
    }

    // IsNotFalse

    #endregion

    #region Toggle

    /// <summary>
    /// Toggles the given boolean item and returns the toggled value.
    /// </summary>
    /// <param name="item">Item to be toggled.</param>
    /// <returns>The toggled value.</returns>
    public static bool Toggle(this bool item)
    {
        return !item;
    }

    // Toggle

    #endregion

    #region ToInt

    /// <summary>
    /// Converts the given boolean value to integer.
    /// </summary>
    /// <param name="item">The boolean variable.</param>
    /// <returns>Returns 1 if true , 0 otherwise.</returns>
    public static int ToInt(this bool item)
    {
        return item ? 1 : 0;
    }

    // ToInt

    #endregion

    #region ToLowerString

    /// <summary>
    /// Returns the lower string representation of boolean.
    /// </summary>
    /// <param name="item">The boolean variable.</param>
    /// <returns>Returns "true" or "false".</returns>
    public static string ToLowerString(this bool item)
    {
        return item.ToString().ToLower();
    }

    // ToLowerString

    #endregion

    #region ToYesNo

    /// <summary>
    /// Returns "Yes" or "No" based on the given boolean value.
    /// </summary>
    /// <param name="item">The boolean value.</param>
    /// <returns>Yes if the given value is true otherwise No.</returns>
    public static string ToYesNo(this bool item)
    {
        return item.ToString("Yes", "No");
    }

    // ToYesNo

    #endregion

    #region ToString

    /// <summary>
    /// Returns the trueString or falseString based on the given boolean value.
    /// </summary>
    /// <param name="item">The boolean value.</param>
    /// <param name="trueString">Value to be returned if the condition is true.</param>
    /// <param name="falseString">Value to be returned if the condition is false.</param>
    /// <returns>Returns trueString if the given value is true otherwise falseString.</returns>
    public static string ToString(this bool item, string trueString, string falseString)
    {
        return item.ToType<string>(trueString, falseString);
    }

    // ToString

    #endregion

    #region ToType

    /// <summary>
    /// Returns the trueValue or the falseValue based on the given boolean value.
    /// </summary>
    /// <param name="item">The boolean value.</param>
    /// <param name="trueValue">Value to be returned if the condition is true.</param>
    /// <param name="falseValue">Value to be returned if the condition is false.</param>
    /// <typeparam name="T">Instance of any class.</typeparam>
    /// <returns>Returns trueValue if the given value is true otherwise falseValue.</returns>
    public static T ToType <T>(this bool item, T trueValue, T falseValue)
    {
        return item ? trueValue : falseValue;
    }

    // ToType

    #endregion
}
