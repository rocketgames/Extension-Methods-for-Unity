using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Dictionary Extensions
/// </summary>
public static class DictionaryExtensions
{
    #region AddIfNotExists

    /// <summary>
    /// Method that adds the given key and value to the given dictionary only if the key is NOT present in the dictionary.
    /// This will be useful to avoid repetitive "if(!containskey()) then add" pattern of coding.
    /// </summary>
    /// <param name="dict">The given dictionary.</param>
    /// <param name="key">The given key.</param>
    /// <param name="value">The given value.</param>
    /// <returns>True if added successfully, false otherwise.</returns>
    /// <typeparam name="TKey">Refers the TKey type.</typeparam>
    /// <typeparam name="TValue">Refers the TValue type.</typeparam>
    public static bool AddIfNotExists <TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    {
        if (dict.ContainsKey(key))
            return false;

        dict.Add(key, value);
        return true;
    }

    // AddIfNotExists

    #endregion

    #region AddOrReplace

    /// <summary>
    /// Method that adds the given key and value to the given dictionary if the key is NOT present in the dictionary.
    /// If present, the value will be replaced with the new value.
    /// </summary>
    /// <param name="dict">The given dictionary.</param>
    /// <param name="key">The given key.</param>
    /// <param name="value">The given value.</param>
    /// <typeparam name="TKey">Refers the Key type.</typeparam>
    /// <typeparam name="TValue">Refers the Value type.</typeparam>
    public static void AddOrReplace <TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
    {
        if (dict.ContainsKey(key))
            dict[key] = value;
        else
            dict.Add(key, value);
    }

    // AddOrReplace

    #endregion

    #region AddRange

    /// <summary>
    /// Method that adds the list of given KeyValuePair objects to the given dictionary. If a key is already present in the dictionary,
    /// then an error will be thrown.
    /// </summary>
    /// <param name="dict">The given dictionary.</param>
    /// <param name="kvpList">The list of KeyValuePair objects.</param>
    /// <typeparam name="TKey">Refers the TKey type.</typeparam>
    /// <typeparam name="TValue">Refers the TValue type.</typeparam>
    public static void AddRange <TKey, TValue>(this Dictionary<TKey, TValue> dict, List<KeyValuePair<TKey, TValue>> kvpList)
    {
        foreach (var kvp in kvpList)
        {
            dict.Add(kvp.Key, kvp.Value);
        }
    }

    // AddRange

    #endregion

    /// <summary>
    /// Converts an enumeration of groupings into a Dictionary of those groupings.
    /// </summary>
    /// <typeparam name="TKey">Key type of the grouping and dictionary.</typeparam>
    /// <typeparam name="TValue">Element type of the grouping and dictionary list.</typeparam>
    /// <param name="groupings">The enumeration of groupings from a GroupBy() clause.</param>
    /// <returns>A dictionary of groupings such that the key of the dictionary is TKey type and the value is List of TValue type.</returns>
    /// <example>results = productList.GroupBy(product => product.Category).ToDictionary();</example>
    /// <remarks>http://extensionmethod.net/csharp/igrouping/todictionary-for-enumerations-of-groupings</remarks>
    public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings)
    {
        return groupings.ToDictionary(group => group.Key, group => group.ToList());
    }
}