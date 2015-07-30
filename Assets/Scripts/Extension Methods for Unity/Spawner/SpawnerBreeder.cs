using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles spawning of game objects
/// </summary>
public class SpawnerBreeder : MonoSingletonExt<SpawnerBreeder>
{
    /// <summary>
    /// List of spawned objects
    /// </summary>
    private static readonly Dictionary<string, SpawnerPool> SpawnPoolDict = new Dictionary<string, SpawnerPool>();

	/// <summary>
	/// Create a pool to hold a set of spawned objects
	/// </summary>
	/// <param name="poolName"></param>
	/// <param name="obj"></param>
	/// <returns></returns>
	public static SpawnerPool Create(string poolName, GameObject obj)
	{
		SpawnerPool pool = new SpawnerPool(poolName, obj);
        SpawnPoolDict.Add(poolName, pool);
		return pool;
	}

	/// <summary>
	/// Remove the spawn pool
	/// </summary>
	/// <param name="poolName"></param>
	public static void Remove(string poolName)
	{
        // remove, if it exists
        if (SpawnPoolDict.ContainsKey(poolName))
            SpawnPoolDict.Remove(poolName);
	}

	/// <summary>
	/// Remove all spawn pools
	/// </summary>
	public static void RemoveAll()
	{
	    SpawnPoolDict.Clear();
	}

	/// <summary>
	/// Returns the pool of this name, if it exists
	/// </summary>
	/// <param name="poolName"></param>
	/// <returns></returns>
	public static SpawnerPool Get(string poolName)
	{
	    return SpawnPoolDict.ContainsKey(poolName) ? SpawnPoolDict[poolName] : null;
	}
}
