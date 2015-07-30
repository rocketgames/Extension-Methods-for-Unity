using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/* *****************************************************************************
 * File:    UnityGoExtensions.cs
 * Author:  Philip Pierce - Friday, September 26, 2014
 * Description:
 *  Unity extensions on GameObjects
 *  
 * History:
 *  Friday, September 26, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Unity extensions on GameObjects
/// </summary>
public static class UnityGoExtensions
{
    #region GetComponentOnObject

    /// <summary>
    /// Returns a component attached to the game object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <param name="showErrorInConsole">when true, logs an error in the console if nothing found</param>
    /// <returns></returns>
    public static T GetComponentOnObject<T>(this GameObject go, bool showErrorInConsole) where T : Component
    {
        // get the component
        T component = go.GetComponent<T>();
        if ((showErrorInConsole) && (component == null))
            Debug.LogError(string.Format("Unable to find component '{0}' on object '{1}'", typeof(T).Name, go.name));

        return component;
    }

    /// <summary>
    /// Returns a component attached to the game object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="trans"></param>
    /// <param name="showErrorInConsole">when true, logs an error in the console if nothing found</param>
    /// <returns></returns>
    public static T GetComponentOnObject<T>(this Transform trans, bool showErrorInConsole) where T : Component
    {
        // get the component
        T component = trans.GetComponent<T>();
        if ((showErrorInConsole) && (component == null))
            Debug.LogError(string.Format("Unable to find component '{0}' on object '{1}'", typeof(T).Name, trans.name));

        return component;
    }

    // GetComponentOnObject
    #endregion

    #region GetComponentOnObjectOrParent

    /// <summary>
    /// Returns a component attached to the game object, or its parent
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <param name="showErrorInConsole">when true, logs an error in the console if nothing found</param>
    /// <returns></returns>
    public static T GetComponentOnObjectOrParent<T>(this GameObject go, bool showErrorInConsole) where T : Component
    {
        // get the component
        T component = go.GetComponentInParent<T>();
        if ((showErrorInConsole) && (component == null))
            Debug.LogError(string.Format("Unable to find component '{0}' on object (or parent) '{1}'", typeof(T).Name, go.name));

        return component;
    }

    // GetComponentOnObjectOrParent
    #endregion

    #region IsNullOrInactive

    /// <summary>
    /// Returns true if the GO is null or inactive
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bool IsNullOrInactive(this GameObject go)
    {
        return ((go == null) || (!go.activeSelf));
    }

    // IsNullOrInactive
    #endregion

    #region IsActive

    /// <summary>
    /// Returns true if the GO is not null and is active
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bool IsActive(this GameObject go)
    {
        return ((go != null) && (go.activeSelf));
    }

    // IsActive
    #endregion

    #region ActivateAndParent

    /// <summary>
    /// Activates this gameobject, starting with its parent
    /// </summary>
    /// <param name="go"></param>
    public static void ActivateAndParent(this GameObject go)
    {
        // exit if go is null
        if (go == null)
            return;

        // if this object has a parent, activate each parent first
        if (go.transform.parent != null)
            go.transform.parent.gameObject.ActivateAndParent();

        // activate this object
        go.SetActive(true);
    }

    // ActivateAndParent
    #endregion

    #region HasRigidbody

    /// <summary>
    /// Returns true if the object has a rigid body
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bool HasRigidbody(this GameObject go)
    {
        return (go.rigidbody != null);
    }

    // HasRigidbody
    #endregion

    #region HasCharacterController

    /// <summary>
    /// Returns true if the object has a character controller
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bool HasCharacterController(this GameObject go)
    {
        return (go.GetComponent<CharacterController>() != null);
    }

    // HasCharacterController
    #endregion

    #region HasAnimation

    /// <summary>
    /// Returns true if the object has an animation
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bool HasAnimation(this GameObject go)
    {
        return (go.animation != null);
    }

    // HasAnimation
    #endregion

    #region HasComponent

    /// <summary>
    /// Returns true if the game object has this component
    /// </summary>
    /// <param name="go"></param>
    public static bool HasComponent<T>(this GameObject go) where T : Component
    {
        return (go.GetComponent<T>() != null);
    }

    // HasComponent
    #endregion

    #region SetLayerRecursively

    /// <summary>
    /// Sets the layer for the game object and all its children
    /// </summary>
    /// <param name="go"></param>
    /// <param name="layer"></param>
    public static void SetLayerRecursively(this GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform t in go.transform)
            t.gameObject.SetLayerRecursively(layer);
    }

    // SetLayerRecursively
    #endregion

    #region SetCollisionRecursively

    /// <summary>
    /// Enables or disables colliders on the game object and all its children
    /// </summary>
    /// <param name="go"></param>
    /// <param name="enabled"></param>
    public static void SetCollisionRecursively(this GameObject go, bool enabled)
    {
        Collider GCollide = go.GetComponent<Collider>();
        if (GCollide != null)
            GCollide.enabled = enabled;

        foreach (Transform t in go.transform)
            t.gameObject.SetCollisionRecursively(enabled);
    }

    // SetCollisionRecursively
    #endregion

    #region GetComponentsInChildrenWithTag

    /// <summary>
    /// Returns all components in the game object and children with the specified tag
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static List<T> GetComponentsInChildrenWithTag<T>(this GameObject go, string tag) where T : Component
    {
        List<T> results = new List<T>();

        // check if the object has this tag
        if (go.CompareTag(tag))
            results.Add(go.GetComponent<T>());

        // loop through all children with this tag
        foreach (Transform t in go.transform)
            results.AddRange(t.gameObject.GetComponentsInChildrenWithTag<T>(tag));

        return results;
    }

    // GetComponentsInChildrenWithTag
    #endregion

    #region GetCollisionMask

    /// <summary>
    /// Returns the collision mask of the game object (all layers which this object can collide with)
    /// </summary>
    /// <param name="go"></param>
    /// <param name="layer">OPTIONAL. If omitted, it uses the layer of the calling GameObject, which is the most common/intuitive case (for me, at least). But you can specify a layer and it’ll hand you the collision mask for that layer instead.</param>
    /// <returns></returns>
    public static int GetCollisionMask(this GameObject go, int layer = -1)
    {
        // get the layer if one was not sent
        if (layer == -1)
            layer = go.layer;

        // get the mask on this layer
        int mask = 0;
        for (int i = 0; i < 32; i++)
            mask |= (Physics.GetIgnoreLayerCollision(layer, i) ? 0 : 1) << i;

        return mask;
    }

    // GetCollisionMask
    #endregion

    #region GetChildrenWithName

    /// <summary>
    /// Returns all children of the game object with the specified name
    /// </summary>
    /// <param name="go"></param>
    /// <param name="name"></param>
    /// <remarks>
    /// Suggested by: Vipsu
    /// Link: http://forum.unity3d.com/members/vipsu.138664/
    /// </remarks>
    public static Transform[] GetChildrenWithName(this GameObject go, string name)
    {
        // loop through and add matching children
        return go.transform.Cast<Transform>()
            .Where(w => w.name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
            .Return(r=> r.ToArray(), (Transform[]) null);
    }

    // GetChildrenWithName
    #endregion

    #region GetChildrenComponent

    /// <summary>
    /// Returns a list of components found on all children matching this type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <remarks>
    /// Suggested by: Vipsu
    /// Link: http://forum.unity3d.com/members/vipsu.138664/
    /// </remarks>
    public static T[] GetChildrenComponent<T>(this GameObject go) where T : Component
    {
        // loop through and add matching children
        return go.transform.Cast<Transform>()
            .Where(w => w.gameObject.HasComponent<T>())
            .Return(r => r.ToList().UnityConvertAll(x=> x.gameObject.GetComponent<T>()).ToArray(), new List<T>().ToArray());
    }

    // GetChildrenComponent
    #endregion

    #region GetInterface

    /// <summary>
    /// Returns the interface on this game object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <remarks>
    /// Suggested by: A.Killingbeck
    /// Link: http://forum.unity3d.com/members/a-killingbeck.560711/
    /// </remarks>
   public static T GetInterface<T>(this GameObject go) where T : class
    {

        if (!typeof(T).IsInterface)
        {
            Debug.LogError(typeof(T).ToString() + " is not an interface");
            return null;
        }

        return go.GetComponents<Component>().OfType<T>().FirstOrDefault();
    }

    // GetInterface
    #endregion

   #region GetInterfaceInChildren

   /// <summary>
   /// Returns the first matching interface on this game object's children
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="go"></param>
   /// <remarks>
   /// Suggested by: A.Killingbeck
   /// Link: http://forum.unity3d.com/members/a-killingbeck.560711/
   /// </remarks>
   public static T GetInterfaceInChildren<T>(this GameObject go) where T : class
   {

       if (!typeof(T).IsInterface)
       {
           Debug.LogError(typeof(T).ToString() + " is not an interface");
           return null;
       }

       return go.GetComponentsInChildren<Component>().OfType<T>().FirstOrDefault();
   }

   // GetInterfaceInChildren
   #endregion

   #region GetInterfaces

   /// <summary>
   /// Returns all interfaces on this game object matching this type
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="go"></param>
   /// <remarks>
   /// Suggested by: A.Killingbeck
   /// Link: http://forum.unity3d.com/members/a-killingbeck.560711/
   /// </remarks>
   public static IEnumerable<T> GetInterfaces<T>(this GameObject go) where T : class
   {

       if (!typeof(T).IsInterface)
       {
           Debug.LogError(typeof(T).ToString() + " is not an interface");
           return Enumerable.Empty<T>();
       }

       return go.GetComponents<Component>().OfType<T>();
   }

   // GetInterfaces
   #endregion

   #region GetInterfacesInChildren

   /// <summary>
   /// Returns all matching interfaces on this game object's children
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="go"></param>
   /// <remarks>
   /// Suggested by: A.Killingbeck
   /// Link: http://forum.unity3d.com/members/a-killingbeck.560711/
   /// </remarks>
   public static IEnumerable<T> GetInterfacesInChildren<T>(this GameObject go) where T : class
   {
       if (!typeof(T).IsInterface)
       {
           Debug.LogError(typeof(T).ToString() + " is not an interface");
           return Enumerable.Empty<T>();
       }

       return go.GetComponentsInChildren<Component>(true).OfType<T>();
   }

    // GetInterfacesInChildren
   #endregion
}
