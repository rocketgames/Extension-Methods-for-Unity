using System;

/* *****************************************************************************
 * File:    Money.cs
 * Author:  Philip Pierce - Wednesday, September 10, 2014
 * Description:
 *  Money type
 *  
 * History:
 *  Wednesday, September 10, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Money type (2 decimal places)
/// </summary>
public struct Money
{
    #region Variables

    #region Public

    /// <summary>
    /// Value of the money
    /// </summary>
    public decimal Value { get; private set; }

    // Public
    #endregion

    // Variables
    #endregion

    #region Init

    /// <summary>
    /// Initializes Money
    /// </summary>
    /// <param name="value">value of the money</param>
    public Money(decimal value) : this()
    {
        Value = value.Rounded(decimals: 2);
    }

    /// <summary>
    /// Initializes Money
    /// </summary>
    /// <param name="value">value of the money</param>
    public Money(Money value) : this()
    {
        Value = value.Value;
    }

    // Init
    #endregion

    #region Implicit_Operators

    /// <summary>
    /// Implicit operator
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator Money(decimal value)
    {
        return new Money(value);
    }

    /// <summary>
    /// Implicit operator
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator decimal(Money value)
    {
        return value.Value;
    }

    // Implicit_Operators
    #endregion
}