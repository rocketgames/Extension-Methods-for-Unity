using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/* *****************************************************************************
 * File:    UnityMathExtensions.cs
 * Author:  Philip Pierce - Friday, September 26, 2014
 * Description:
 *  Unity extensions for math
 *  
 * History:
 *  Friday, September 26, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Unity extensions for math
/// </summary>
public static class UnityMathExtensions
{
    #region DistanceTo

    /// <summary>
    /// Returns the Vector3 distance between these two GameObjects
    /// </summary>
    /// <param name="go"></param>
    /// <param name="otherGO"></param>
    /// <returns></returns>
    public static float DistanceTo(this GameObject go, GameObject otherGO)
    {
        return Vector3.Distance(go.transform.position, otherGO.transform.position);
    }

    /// <summary>
    /// Returns the Vecto3 distance between these two points
    /// </summary>
    /// <param name="go"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static float DistanceTo(this GameObject go, Vector3 pos)
    {
        return Vector3.Distance(go.transform.position, pos);
    }

    /// <summary>
    /// Returns the Vecto3 distance between these two points
    /// </summary>
    /// <param name="start"></param>
    /// <param name="dest"></param>
    /// <returns></returns>
    public static float DistanceTo(this Vector3 start, Vector3 dest)
    {
        return Vector3.Distance(start, dest);
    }

    /// <summary>
    /// Returns the Vecto3 distance between these two transforms
    /// </summary>
    /// <param name="start"></param>
    /// <param name="dest"></param>
    /// <remarks>
    /// Suggested by: Vipsu
    /// Link: http://forum.unity3d.com/members/vipsu.138664/
    /// </remarks>
    public static float DistanceTo(this Transform start, Transform dest)
    {
        return Vector3.Distance(start.position, dest.position);
    }

    // DistanceTo
    #endregion

    #region Add

    
    /// <summary>
    /// Adds two Vector3s
    /// </summary>
    /// <param name="v3">source vector3</param>
    /// <param name="value">second vector3</param>
    /// <remarks>
    /// Suggested by: aaro4130
    /// Link: http://forum.unity3d.com/members/aaro4130.22011/
    /// </remarks>
    public static Vector3 Add(this Vector3 v3, Vector3 value)
    {
        return v3 + value;
    }

    /// <summary>
    /// Adds the values to a vector3
    /// </summary>
    /// <param name="v3">source vector3</param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <remarks>
    /// Suggested by: aaro4130
    /// Link: http://forum.unity3d.com/members/aaro4130.22011/
    /// </remarks>
    public static Vector3 Add(this Vector3 v3, float x, float y, float z)
    {
        return v3 + new Vector3(x, y, z);
    }

    // Add
    #endregion

    #region Subtract

    /// <summary>
    /// Subtracts two Vector3s
    /// </summary>
    /// <param name="v3">source vector3</param>
    /// <param name="value">second vector3</param>
    /// <returns></returns>
    /// <remarks>
    /// Suggested by: aaro4130
    /// Link: http://forum.unity3d.com/members/aaro4130.22011/
    /// </remarks>
    public static Vector3 Subtract(this Vector3 v3, Vector3 value)
    {
        return v3 - value;
    }

    /// <summary>
    /// Subtracts the values from a vector 3
    /// </summary>
    /// <param name="v3">source vector3</param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    /// <remarks>
    /// Suggested by: aaro4130
    /// Link: http://forum.unity3d.com/members/aaro4130.22011/
    /// </remarks>
    public static Vector3 Subtract(this Vector3 v3, float x, float y, float z)
    {
        return v3 - new Vector3(x, y, z);
    }

    // Subtract
    #endregion
}