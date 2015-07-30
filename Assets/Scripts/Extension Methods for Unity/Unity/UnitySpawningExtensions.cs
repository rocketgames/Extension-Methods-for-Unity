using System;
using UnityEngine;

/* *****************************************************************************
 * File:    UnitySpawningExtensions.cs
 * Author:  Philip Pierce - Wednesday, October 29, 2014
 * Description:
 *  Extensions for spawning GameObjects using the Spawner
 *  
 * History:
 *  Wednesday, October 29, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for spawning GameObjects using the Spawner
/// </summary>
public static class UnitySpawningExtensions
{
    #region Spawn

    /// <summary>
    /// Spawns the game object using the Spawner Pool system
    /// </summary>
    /// <param name="go"></param>
    /// <param name="position">position to spawn to</param>
    /// <param name="rotation">rotation to spawn to</param>
    /// <returns></returns>
    public static GameObject Spawn(this GameObject go, Vector3 position, Quaternion rotation)
    {
        return Spawner.CreateSpawn(go, position, rotation);
    }

    /// <summary>
    /// Spawns the game object using the Spawner Pool system
    /// </summary>
    /// <param name="go"></param>
    /// <param name="position">position to spawn to</param>
    /// <param name="rotation">rotation to spawn to</param>
    /// <param name="spawnedAction">action to call when the object is spawned. The new spawned object is passed as the parameter</param>
    /// <returns></returns>
    public static GameObject Spawn(this GameObject go, Vector3 position, Quaternion rotation, Action<GameObject> spawnedAction)
    {
        return Spawner.CreateSpawn(go, position, rotation, spawnedAction);
    }

    // Spawn
    #endregion

    #region Despawn

    /// <summary>
    /// Despawns the game object. If the object is not in the pool, it is destroyed instead
    /// </summary>
    /// <param name="go"></param>
    public static void Despawn(this GameObject go)
    {
        Spawner.Despawn(go); 
    }

    // Despawn
    #endregion

    #region PreSpawn

    /// <summary>
    /// Preloads this game object <paramref name="count"/> times
    /// </summary>
    /// <param name="go"></param>
    /// <param name="count"></param>
    public static void PreSpawn(this GameObject go, int count)
    {
        Spawner.Prespawn(go, count);
    }

    // PreSpawn
    #endregion
}