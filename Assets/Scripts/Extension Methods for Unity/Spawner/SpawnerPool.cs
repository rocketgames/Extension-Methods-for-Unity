using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Pool of spawned items
/// </summary>
public class SpawnerPool
{
    #region Variables

    /// <summary>
    /// Name of the pool
    /// </summary>
    public string PoolName = string.Empty;

    /// <summary>
    /// The object we will spawn
    /// </summary>
    public GameObject SpawnObj = null;

    /// <summary>
    /// keeps track of the available game objects that are ready to spawn
    /// </summary>
    private readonly Stack AvailableObjects = new Stack();

    /// <summary>
    /// All the game object spawns
    /// </summary>
    private readonly List<GameObject> SpawnedObjects = new List<GameObject>();

    // Variables
    #endregion

    #region Init

    /// <summary>
    /// Init the pool
    /// </summary>
    /// <param name="poolName"></param>
    /// <param name="objToSpawn"></param>
    public SpawnerPool(string poolName, GameObject objToSpawn)
    {
        this.PoolName = poolName;
        this.SpawnObj = objToSpawn;
    }

    // Init
    #endregion

    #region Spawn

    /// <summary>
    /// Spawn and return the game object
    /// </summary>
    /// <param name="position">position to spawn to</param>
    /// <param name="rotation">rotation after spawning</param>
    /// <returns></returns>
    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        return Spawn(position, rotation, null);
    }

    /// <summary>
    /// Spawn and return the game object
    /// </summary>
    /// <param name="position">position to spawn to</param>
    /// <param name="rotation">rotation after spawning</param>
    /// <param name="spawnedAction">action to call when an object has been spawned</param>
    /// <returns></returns>
    public GameObject Spawn(Vector3 position, Quaternion rotation, Action<GameObject> spawnedAction)
    {
        GameObject go;

        // if we don't have any available objects to use, then create a new one
        if (AvailableObjects.Count == 0)
        {
            // create it
            go = Object.Instantiate(SpawnObj, position, rotation) as GameObject;

            // set the name
            go.name = string.Format("{0} ({1})", PoolName, SpawnedObjects.Count);

            // add to the list
            SpawnedObjects.Add(go);
        }

        // we have a free object, use that instead
        else
        {
            // get from the stack
            go = AvailableObjects.Pop() as GameObject;

            // set position and rotation
            go.transform.position = position;
            go.transform.rotation = rotation;
        }

        // make it active
        go.SetActive(true);

        // invoke the action, if not null
        if (spawnedAction != null)
            spawnedAction(go);

        // return the object
        return go;
    }
    // Spawn
    #endregion

    #region Prespawn

    /// <summary>
    /// Spawn objects, unspawn them, then exit
    /// Useful for preloading objects, so they are ready to use
    /// </summary>
    /// <param name="count">numbe of spawns to create</param>
    public void Prespawn(int count)
    {
        // hold the temp spawned objects
        GameObject[] PreSpawned = new GameObject[count];

        // Spawn first
        for (int i = 0; i < count; i++)
            PreSpawned[i] = Spawn(Vector3.zero, Quaternion.identity);

        // despawn them all
        for (int i = 0; i < count; i++)
            PreSpawned[i].Despawn();
    }

    // Prespawn
    #endregion

    #region Despawn

    /// <summary>
    /// Despawn the object
    /// </summary>
    /// <param name="go"></param>
    public void Despawn(GameObject go)
    {
        // exit if null, or already despawned
        if ((go == null) || (AvailableObjects.Contains(go)))
            return;

        // save to available objects
        AvailableObjects.Push(go);
        go.SetActive(false);
    }

    // Despawn
    #endregion

    #region DespawnList

    /// <summary>
    /// Despawn a list of objects
    /// </summary>
    /// <param name="goObjList"></param>
    public void DespawnList(List<GameObject> goObjList)
    {
        // exit if the list is empty
        if (goObjList.IsNullOrEmpty())
            return;

        // loop through and despawn
        foreach (GameObject go in goObjList)
            Despawn(go);
    }

    // DespawnList
    #endregion

    #region DespawnAll

    /// <summary>
    /// Despawns all objects managed by this pool
    /// </summary>
    public void DespawnAll()
    {
        int j = SpawnedObjects.Count;

        // exit if nothing to despawn
        if (j == 0)
            return;

        // loop through and despawn each
        for (int i = 0; i < j; i++)
            Despawn(SpawnedObjects[i]);
    }

    // DespawnAll
    #endregion

    #region ClearPool

    /// <summary>
    /// Despawns all game objects, and clears the pool
    /// </summary>
    public void ClearPool()
    {
        DespawnAll();
        AvailableObjects.Clear();
        SpawnedObjects.Clear();
    }

    // ClearPool
    #endregion

    #region GetActiveSpawns

    /// <summary>
    /// Returns all active spawns
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetActiveSpawns()
    {
        // get the list of active gameobjects
        return SpawnedObjects
            .Where(x => x.IsActive())
            .ToList();
    }

    // GetActiveSpawns
    #endregion
}