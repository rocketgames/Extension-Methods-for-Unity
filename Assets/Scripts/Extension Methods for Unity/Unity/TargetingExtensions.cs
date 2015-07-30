using System.Linq;
using UnityEngine;

/// <summary>
/// Finds nearby units
/// </summary>
public static class TargetingExtensions
{
    #region Constants

    /// <summary>
    /// Maximum search range
    /// </summary>
    private const float FLOAT_MaxSearchRange = 1000000000000f;

    // Constants
    #endregion

    #region FindNearestUnit

    /// <summary>
    /// Returns the nearest GameObject, regardless of range or direction
    /// </summary>
    /// <param name="go">the GameObject to search from</param>
    /// <param name="maskToSearch">the layers to search for units</param>
    public static GameObject FindNearestUnit(this GameObject go, LayerMask maskToSearch)
    {
        // get list of units within specified distance from the GO
        Collider[] NearbyUnits = Physics.OverlapSphere(go.transform.position, FLOAT_MaxSearchRange, maskToSearch);

        // if nothing found, then exit
        if ((NearbyUnits == null) || (NearbyUnits.Length == 0))
            return null;

        // convert NearbyUnits to a Go array, then find nearest
        return go.FindNearestUnit_List(NearbyUnits.ToList().ConvertAll(x => x.gameObject).ToArray());
    }

    // FindNearestUnit
    #endregion

    #region FindNearestUnit_View

    /// <summary>
    /// Returns the nearest GameObject from the direction <see cref="go"/> is facing, regardless range
    /// </summary>
    /// <param name="go">the GameObject to search from</param>
    /// <param name="frustumAngle">angle at which we can see the unit</param>
    /// <param name="maskToSearch">the layers to search for units</param>
    public static GameObject FindNearestUnit_View(this GameObject go, float frustumAngle, LayerMask maskToSearch)
    {
        // get list of units within specified distance from the GO
        Collider[] NearbyUnits = Physics.OverlapSphere(go.transform.position, FLOAT_MaxSearchRange, maskToSearch);

        // if nothing found, then exit
        if ((NearbyUnits == null) || (NearbyUnits.Length == 0))
            return null;

        // convert NearbyUnits to Go array, then find nearest
        return go.FindNearestUnit_ListView(frustumAngle, NearbyUnits.ToList().ConvertAll(x => x.gameObject).ToArray());
    }

    // FindNearestUnit_View
    #endregion

    #region FindNearestUnit_Range

    /// <summary>
    /// Returns the nearest GameObject within target range (returns from all angles around GO)
    /// </summary>
    /// <param name="go">the GameObject to search from</param>
    /// <param name="targetRange">the range to search</param>
    /// <param name="maskToSearch">the layers to search for units</param>
    public static GameObject FindNearestUnit_Range(this GameObject go, float targetRange, LayerMask maskToSearch)
    {
        // get list of units within specified distance from the GO
        Collider[] NearbyUnits = Physics.OverlapSphere(go.transform.position, targetRange, maskToSearch);

        // if nothing found, then exit
        if ((NearbyUnits == null) || (NearbyUnits.Length == 0))
            return null;

        // convert NearbyUnits to a Go array, then find nearest
        return go.FindNearestUnit_ListRange(targetRange, NearbyUnits.ToList().ConvertAll(x => x.gameObject).ToArray());
    }

    // FindNearestUnit_Range
    #endregion

    #region FindNearestUnit_RangeView

    /// <summary>
    /// Returns the nearest GameObject from the direction <see cref="go"/> is facing, within target range
    /// </summary>
    /// <param name="go">the GameObject to search from</param>
    /// <param name="frustumAngle">angle at which we can see the unit</param>
    /// <param name="targetRange">the range to search</param>
    /// <param name="maskToSearch">the layers to search for units</param>
    public static GameObject FindNearestUnit_RangeView(this GameObject go, float frustumAngle, float targetRange, LayerMask maskToSearch)
    {
        // get list of units within specified distance from the GO
        Collider[] NearbyUnits = Physics.OverlapSphere(go.transform.position, targetRange, maskToSearch);

        // if nothing found, then exit
        if ((NearbyUnits == null) || (NearbyUnits.Length == 0))
            return null;

        // convert NearbyUnits to Go array, then find nearest
        return go.FindNearestUnit_ListRangeView(targetRange, frustumAngle, NearbyUnits.ToList().ConvertAll(x => x.gameObject).ToArray());
    }

    // FindNearestUnit_RangeView
    #endregion

    #region FindNearestUnit_ListRange

    /// <summary>
    /// Returns the nearest unit from the list, within <see cref="targetRange"/>
    /// </summary>
    /// <param name="go">the game object of the search center</param>
    /// <param name="goList">array of GameObjects to search</param>
    /// <param name="targetRange">search range</param>
    /// <returns></returns>
    public static GameObject FindNearestUnit_ListRange(this GameObject go, float targetRange, GameObject[] goList)
    {
        // get the position, so we're not calling on each loop iteration
        Vector3 GoPos = go.transform.position;

        // holds the closest index and distance
        float NearestDistance = 10000000000; // set really high, for first time through loop
        int NearestIndex = -1;

        // loop through the units to find the one within our attack frustum
        int j = goList.Length;
        for (int i = 0; i < j; i++)
        {
            // get distance
            float TestDistance = Vector3.Distance(GoPos, goList[i].transform.position);

            // skip if outside range
            if (TestDistance > targetRange)
                continue;

            // check if it closer than previous match
            if (TestDistance < NearestDistance)
            {
                NearestDistance = TestDistance;
                NearestIndex = i;
            }
        }

        // return result, or null if nothing found
        return (NearestIndex > -1) ? goList[NearestIndex] : null;
    }

    // FindNearestUnit_ListRange
    #endregion

    #region FindNearestUnit_List

    /// <summary>
    /// Returns the nearest unit from the list, regardless of distance
    /// </summary>
    /// <param name="go">the game object of the search center</param>
    /// <param name="goList">array of GameObjects to search</param>
    /// <returns></returns>
    public static GameObject FindNearestUnit_List(this GameObject go, GameObject[] goList)
    {
        // get the position, so we're not calling on each loop iteration
        Vector3 GoPos = go.transform.position;

        // holds the closest index and distance
        float NearestDistance = 10000000000; // set really high, for first time through loop
        int NearestIndex = -1;

        // loop through the units to find the one within our attack frustum
        int j = goList.Length;
        for (int i = 0; i < j; i++)
        {
            // check if it closer than previous match
            float TestDistance = Vector3.Distance(GoPos, goList[i].transform.position);
            if (TestDistance < NearestDistance)
            {
                NearestDistance = TestDistance;
                NearestIndex = i;
            }
        }

        // return result, or null if nothing found
        return (NearestIndex > -1) ? goList[NearestIndex] : null;
    }

    // FindNearestUnit_List
    #endregion

    #region FindNearestUnit_ListView

    /// <summary>
    /// Returns the nearest unit from the list within view angle, regardless of distance
    /// </summary>
    /// <param name="go">the game object of the search center</param>
    /// <param name="frustumAngle">angle at which we can see the unit</param>
    /// <param name="goList">array of GameObjects to search</param>
    /// <returns></returns>
    public static GameObject FindNearestUnit_ListView(this GameObject go, float frustumAngle, GameObject[] goList)
    {
        // get the forward and position, so we're not calling on each loop iteration
        Vector3 GoPos = go.transform.position;
        Vector3 GoForward = go.transform.forward;

        // holds the closest index and distance
        float NearestDistance = 10000000000; // set really high, for first time through loop
        int NearestIndex = -1;

        // loop through the units to find the one within our attack frustum
        int j = goList.Length;
        for (int i = 0; i < j; i++)
        {
            // get the target direction, if within our angle
            if (Vector3.Angle((goList[i].transform.position - GoPos), GoForward) > frustumAngle)
                continue;

            // check if it closer than previous match
            float TestDistance = Vector3.Distance(GoPos, goList[i].transform.position);
            if (TestDistance < NearestDistance)
            {
                NearestDistance = TestDistance;
                NearestIndex = i;
            }
        }

        // return result, or null if nothing found
        return (NearestIndex > -1) ? goList[NearestIndex] : null;
    }

    // FindNearestUnit_ListView
    #endregion

    #region FindNearestUnit_ListRangeView

    /// <summary>
    /// Returns the nearest unit from the list, within <see cref="targetRange"/>, and within view angle
    /// </summary>
    /// <param name="go">the game object of the search center</param>
    /// <param name="goList">array of GameObjects to search</param>
    /// <param name="targetRange">search range</param>
    /// <param name="frustumAngle">angle at which we can see the unit</param>
    /// <returns></returns>
    public static GameObject FindNearestUnit_ListRangeView(this GameObject go, float targetRange, float frustumAngle, GameObject[] goList)
    {
        // get the forward and position, so we're not calling on each loop iteration
        Vector3 GoPos = go.transform.position;
        Vector3 GoForward = go.transform.forward;

        // holds the closest index and distance
        float NearestDistance = 10000000000; // set really high, for first time through loop
        int NearestIndex = -1;

        // loop through the units to find the one within our attack frustum
        int j = goList.Length;
        for (int i = 0; i < j; i++)
        {
            // get distance, skip if too far away
            float TestDistance = Vector3.Distance(GoPos, goList[i].transform.position);
            if (TestDistance > targetRange)
                continue;

            // get the target direction, if within our angle
            if (Vector3.Angle((goList[i].transform.position - GoPos), GoForward) > frustumAngle)
                continue;

            // check if it closer than previous match
            if (TestDistance < NearestDistance)
            {
                NearestDistance = TestDistance;
                NearestIndex = i;
            }
        }

        // return result, or null if nothing found
        return (NearestIndex > -1) ? goList[NearestIndex] : null;
    }

    // FindNearestUnit_ListRangeView
    #endregion

}
