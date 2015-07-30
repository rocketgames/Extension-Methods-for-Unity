using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/* *****************************************************************************
 * File:    UnityTransformExtensions.cs
 * Author:  Philip Pierce - Monday, September 29, 2014
 * Description:
 *  Extensions for transforms and vector3
 *  
 * History:
 *  Monday, September 29, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for transforms and vector3
/// </summary>
public static class UnityTransformExtensions
{
    #region SetPositionX

    /// <summary>
    /// Sets the X position value
    /// </summary>
    /// <param name="t"></param>
    /// <param name="newX"></param>
    public static void SetPositionX(this Transform t, float newX)
    {
        t.position = t.position.SetPositionX(newX);
    }

    /// <summary>
    /// Sets the X position value
    /// </summary>
    /// <param name="v3"></param>
    /// <param name="newX"></param>
    public static Vector3 SetPositionX(this Vector3 v3, float newX)
    {
        return new Vector3(newX, v3.y, v3.z);
    }

    // SetPositionX
    #endregion

    #region SetPositionY

    /// <summary>
    /// Sets the Y position value
    /// </summary>
    /// <param name="t"></param>
    /// <param name="newY"></param>
    public static void SetPositionY(this Transform t, float newY)
    {
        t.position = t.position.SetPositionY(newY);
    }

    /// <summary>
    /// Sets the Y position value
    /// </summary>
    /// <param name="v3"></param>
    /// <param name="newY"></param>
    public static Vector3 SetPositionY(this Vector3 v3, float newY)
    {
        return new Vector3(v3.x, newY, v3.z);
    }

    // SetPositionY
    #endregion

    #region SetPositionZ

    /// <summary>
    /// Sets the Z position value
    /// </summary>
    /// <param name="t"></param>
    /// <param name="newZ"></param>
    public static void SetPositionZ(this Transform t, float newZ)
    {
        t.position = t.position.SetPositionZ(newZ);
    }

    /// <summary>
    /// Sets the Z position value
    /// </summary>
    /// <param name="v3"></param>
    /// <param name="newZ"></param>
    public static Vector3 SetPositionZ(this Vector3 v3, float newZ)
    {
        return new Vector3(v3.x, v3.y, newZ);
    }

    // SetPositionZ
    #endregion

    #region GetPositionX

    /// <summary>
    /// Returns X of position
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static float GetPositionX(this Transform t)
    {
        return t.position.x;
    }

    // GetPositionX
    #endregion

    #region GetPositionY

    /// <summary>
    /// Returns Y of position
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static float GetPositionY(this Transform t)
    {
        return t.position.y;
    }

    // GetPositionY
    #endregion

    #region GetPositionZ

    /// <summary>
    /// Returns Z of position
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static float GetPositionZ(this Transform t)
    {
        return t.position.z;
    }

    // GetPositionZ
    #endregion
}