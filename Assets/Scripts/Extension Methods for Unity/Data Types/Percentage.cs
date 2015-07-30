/// <summary>
/// Percentage type
/// </summary>
public struct Percentage
{
    #region Properties

    /// <summary>
    /// The percentage as a value
    /// </summary>
    public decimal Value { get; private set; }

    /// <summary>
    /// Returns the value as a percentage (Value / 100)
    /// </summary>
    public decimal ValueAsPercentage
    {
        get { return Value / 100; }
    }

    // Properties
    #endregion

    #region Init

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="value"></param>
    public Percentage(int value) : this()
    {
        Value = value;
    }

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="value"></param>
    public Percentage(decimal value) : this()
    {
        Value = value;
    }

    // Init
    #endregion

    #region Math_Overloads

    #region Minus

    /// <summary>
    /// Minus (ex. 5 - 10% = 4.5)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator -(decimal value, Percentage percentage)
    {
        return value - (value * percentage);
    }

    /// <summary>
    /// Minus (ex. 5 - 10% = 4.5)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator -(int value, Percentage percentage)
    {
        return value - (value * percentage);
    }

    /// <summary>
    /// Minus (ex. 10% - 5 = -4.5)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator -(Percentage percentage, decimal value)
    {
        return (value * percentage) - value;
    }

    /// <summary>
    /// Minus (ex. 10% - 5 = -4.5)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator -(Percentage percentage, int value)
    {
        return (value * percentage) - value;
    }

    /// <summary>
    /// Subtract two percentages (ex. 10% - 8% = 2%)
    /// </summary>
    /// <param name="percentage">value 1</param>
    /// <param name="value">value 2</param>
    public static Percentage operator -(Percentage value, Percentage percentage)
    {
        return new Percentage(value.Value - percentage.Value);
    }

    // Minus
    #endregion

    #region Addition

    /// <summary>
    /// Add (ex. 5 + 10% = 5.5)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator +(decimal value, Percentage percentage)
    {
        return value + (value * percentage);
    }

    /// <summary>
    /// Add (ex. 5 + 10% = 5.5)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator +(int value, Percentage percentage)
    {
        return value + (value * percentage);
    }

    /// <summary>
    /// Add (ex. 10% + 5 = 5.5)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator +(Percentage percentage, decimal value)
    {
        return value + (value * percentage);
    }

    /// <summary>
    /// Add (ex. 10% + 5 = 5.5)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator +(Percentage percentage, int value)
    {
        return value + (value * percentage);
    }

    /// <summary>
    /// Add two percentages (ex. 10% + 8% = 18%)
    /// </summary>
    /// <param name="percentage">value 1</param>
    /// <param name="value">value 2</param>
    public static Percentage operator +(Percentage value, Percentage percentage)
    {
        return new Percentage(value.Value + percentage.Value);
    }

    // Addition
    #endregion

    #region Multiplication

    /// <summary>
    /// Multiply (ex. 5 * 10% = 0.5)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator *(decimal value, Percentage percentage)
    {
        return value * percentage.ValueAsPercentage;
    }

    /// <summary>
    /// Multiply (ex. 5 * 10% = 0.5)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator *(int value, Percentage percentage)
    {
        return value * percentage.ValueAsPercentage;
    }

    /// <summary>
    /// Multiply (ex. 10% * 5 = 0.5)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator *(Percentage percentage, decimal value)
    {
        return value * percentage.ValueAsPercentage;
    }

    /// <summary>
    /// Multiply (ex. 10% * 5 = 0.5)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator *(Percentage percentage, int value)
    {
        return value * percentage.ValueAsPercentage;
    }

    /// <summary>
    /// Multiply two percentages (ex. 10% * 8% = 0.8%)  (0.1 * 0.08 = 0.008)
    /// </summary>
    /// <param name="percentage">value 1</param>
    /// <param name="value">value 2</param>
    public static Percentage operator *(Percentage value, Percentage percentage)
    {
        return new Percentage(value.ValueAsPercentage * percentage.ValueAsPercentage);
    }

    // Multiplication
    #endregion

    #region Division

    /// <summary>
    /// Divide (ex. 5 / 10% = 50)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator /(decimal value, Percentage percentage)
    {
        return value / percentage.ValueAsPercentage;
    }

    /// <summary>
    /// Divide (ex. 5 / 10% = 50)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator /(int value, Percentage percentage)
    {
        return value / percentage.ValueAsPercentage;
    }

    /// <summary>
    /// Divide (ex. 10% / 5 = 0.02)
    /// </summary>
    /// <param name="value">the decimal value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator /(Percentage percentage, decimal value)
    {
        return percentage.ValueAsPercentage / value;
    }

    /// <summary>
    /// Divide (ex. 10% / 5 = 0.002)
    /// </summary>
    /// <param name="value">the int value</param>
    /// <param name="percentage">the percentage value</param>
    public static decimal operator /(Percentage percentage, int value)
    {
        return percentage.ValueAsPercentage / value;
    }

    /// <summary>
    /// Divide two percentages (ex. 10% / 8% = 125%)  (0.1 / 0.08 = 1.25)
    /// </summary>
    /// <param name="percentage">value 1</param>
    /// <param name="value">value 2</param>
    public static Percentage operator /(Percentage value, Percentage percentage)
    {
        return new Percentage(value.ValueAsPercentage / percentage.ValueAsPercentage);
    }


    // Division
    #endregion

    // Math_Overloads
    #endregion
}
