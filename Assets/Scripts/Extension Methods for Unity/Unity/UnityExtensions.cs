using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Extension methods for common functions
/// </summary>
public static class UnityExtensions
{
    #region ToV3String

    /// <summary>
    /// Converts a Vector3 to a string in X, Y, Z format
    /// </summary>
    /// <param name="v3"></param>
    /// <returns></returns>
    public static string ToV3String(this Vector3 v3)
    {
        return string.Format("{0}, {1}, {2}", v3.x, v3.y, v3.z);
    }

    // ToV3String
    #endregion

    #region ZeroY

    /// <summary>
    /// Returns a Vector3 with a 0 Y
    /// </summary>
    /// <param name="v3"></param>
    /// <returns></returns>
    public static Vector3 ZeroY(this Vector3 v3)
    {
        return new Vector3(v3.x, 0.0f, v3.z);
    }

    // ZeroY
    #endregion

    #region RotateAroundY

    /// <summary>
    /// Rotates goV3 around the vector v3, keeping y in the original position
    /// </summary>
    /// <param name="v3"></param>
    /// <param name="goV3">the game object's transform, which will be rotating</param>
    /// <returns></returns>
    public static Vector3 RotateAroundY(this Vector3 v3, Vector3 goV3)
    {
        return new Vector3(v3.x, goV3.y, v3.z);
    }

    // RotateAroundY
    #endregion

    #region ToStringParentHierarchy

    /// <summary>
    /// Returns the name of the parent objects
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static string ToStringParentHierarchy(this GameObject go)
    {
        // exit if null
        if (go == null)
            return string.Empty;

        string ReturnName = string.Empty;

        // get the parent name first
        if (go.transform.parent != null)
            ReturnName = go.transform.parent.gameObject.ToStringParentHierarchy();

        // add this game oject to the return string
        return string.Format("{0}{1}",
            (!string.IsNullOrEmpty(ReturnName)) ? string.Format("{0} > ", ReturnName) : string.Empty,
            go.name);
    }

    // ToStringParentHierarchy
    #endregion

    #region LoadMaterialFromResources

    /// <summary>
    /// Returns the loaded resource
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resourcePath">the full Resources path</param>
    /// <param name="errorOnNull">When true, throws an error if nothing was loaded</param>
    /// <returns></returns>
    public static T LoadFromResources<T>(this string resourcePath, bool errorOnNull) where T : Object
    {
        T retObj = Resources.Load<T>(resourcePath);
        if (retObj == null)
            Debug.LogError(string.Format("Unable to load resource: {0}", resourcePath));

        return retObj;
    }

    // LoadMaterialFromResources
    #endregion

    #region UnityStringToBytes

    /// <summary>
    /// Converts a string to bytes, in a Unity friendly way
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static byte[] UnityStringToBytes(this string source)
    {
        // exit if null
        if (string.IsNullOrEmpty(source))
            return null;

        // convert to bytes
        using (MemoryStream compMemStream = new MemoryStream())
        {
            using (StreamWriter writer = new StreamWriter(compMemStream, Encoding.UTF8))
            {
                writer.Write(source);
                writer.Close();

                return compMemStream.ToArray();
            }
        }
    }

    // UnityStringToBytes
    #endregion

    #region UnityBytesToString

    /// <summary>
    /// Converts a byte array to a Unicode string, in a Unity friendly way
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string UnityBytesToString(this byte[] source)
    {
        // exit if null
        if (source.IsNullOrEmpty())
            return string.Empty;

        // read from bytes
        using (MemoryStream compMemStream = new MemoryStream(source))
        {
            using (StreamReader reader = new StreamReader(compMemStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }

    // UnityBytesToString
    #endregion

    #region WithAlpha

    /// <summary>
    /// Returns a new color with the specified alpha value
    /// </summary>
    /// <param name="color"></param>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public static Color WithAlpha(this Color color, float alpha)
    {
        return new Color(color.r, color.g, color.b, alpha);
    }

    // WithAlpha
    #endregion


    #region UnityConvertAll

    /// <summary>
    /// ConvertAll LINQ extension, which runs on WP8 (WP8 doesn't support .ConvertAll())
    /// </summary>
    /// <typeparam name="InputType"></typeparam>
    /// <typeparam name="OutputType"></typeparam>
    /// <param name="inputList"></param>
    /// <param name="converter"></param>
    /// <returns></returns>
    public static List<OutputType> UnityConvertAll<InputType, OutputType>(this List<InputType> inputList, Func<InputType, OutputType> converter)
    {
        int j = inputList.Count;
        List<OutputType> output = new List<OutputType>(j);
        for (int i = 0; i < j; i++)
            output.Add(converter(inputList[i]));

        return output;
    }

    // UnityConvertAll
    #endregion
}
