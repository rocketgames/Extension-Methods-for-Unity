using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/* *****************************************************************************
 * File:    UnityMovement.cs
 * Author:  Philip Pierce - Friday, October 24, 2014
 * Description:
 *  Extensions for movement of a gameobject
 *  
 * History:
 *  Friday, October 24, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for movement of a gameobject
/// </summary>
public static class UnityMovement
{
    // Code adapted from http://msdn.microsoft.com/en-us/magazine/dn802605.aspx

    /*
      Each approach has advantages and disadvantages. There can be a performance hit moving just the transform (methods 1-2), 
        though it’s a very easy way to do movement. Unity assumes if an object doesn’t have a rigidbody component on it, it 
        probably isn’t a moving object. It builds a static collision matrix internally to know where objects are, which enhances 
        performance. When you move objects by moving the transform, this matrix has to be recalculated, which causes a performance hit. 
        For simple games, you may never notice the hit and it may be the easiest thing for you to do, although as your games get more 
        complicated, it’s important to move the rigidbody itself, as I did in methods 4-6.
    */

    #region MoveTowards_NoPhysics

    /// <summary>
    /// Moves towards the specified game object.
    /// MUST be called from the Update() function
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="go"></param>
    /// <param name="destGO"></param>
    /// <param name="speed">moves towards destGo by speed per frame. Will not overshoot, so speed is the max amount moved</param>
    public static void MoveTowards_NoPhysics(this GameObject go, GameObject destGO, float speed)
    {
        go.transform.MoveTowards_NoPhysics(destGO.transform.position, speed);
    }

    /// <summary>
    /// Moves towards the specified transform.
    /// MUST be called from the Update() function
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="goTrans"></param>
    /// <param name="destTrans"></param>
    /// <param name="speed">moves towards destTrans by speed per frame. Will not overshoot, so speed is the max amount moved</param>
    public static void MoveTowards_NoPhysics(this Transform goTrans, Transform destTrans, float speed)
    {
        goTrans.MoveTowards_NoPhysics(destTrans.position, speed);
    }

    /// <summary>
    /// Moves towards the specified destination.
    /// MUST be called from the Update() function
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="go"></param>
    /// <param name="destV"></param>
    /// <param name="speed">moves towards destV by speed per frame. Will not overshoot, so speed is the max amount moved</param>
    public static void MoveTowards_NoPhysics(this GameObject go, Vector3 destV, float speed)
    {
        go.transform.MoveTowards_NoPhysics(destV, speed);
    }

    /// <summary>
    /// Moves towards the specified destination.
    /// MUST be called from the Update() function
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="goTrans"></param>
    /// <param name="destV"></param>
    /// <param name="speed">moves towards destV by speed per frame. Will not overshoot, so speed is the max amount moved</param>
    public static void MoveTowards_NoPhysics(this Transform goTrans, Vector3 destV, float speed)
    {
        Vector3.MoveTowards(goTrans.position, destV, speed);
    }

    // MoveTowards_NoPhysics
    #endregion

    #region MoveTowardsInterpolate_NoPhysics

    /// <summary>
    /// Interpolate from source to dest by a percentage each frame (lerpPct)
    /// MUST be called from Update().
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="go"></param>
    /// <param name="destGo"></param>
    /// <param name="lerpPct"></param>
    public static void MoveTowardsInterpolate_NoPhysics(this GameObject go, GameObject destGo, float lerpPct)
    {
        MoveTowardsInterpolate_NoPhysics(go.transform, destGo.transform.position, lerpPct);
    }

    /// <summary>
    /// Interpolate from source to dest by a percentage each frame (lerpPct)
    /// MUST be called from Update().
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="go"></param>
    /// <param name="destV"></param>
    /// <param name="lerpPct"></param>
    public static void MoveTowardsInterpolate_NoPhysics(this GameObject go, Vector3 destV, float lerpPct)
    {
        MoveTowardsInterpolate_NoPhysics(go.transform, destV, lerpPct);
    }

    /// <summary>
    /// Interpolate from source to dest by a percentage each frame (lerpPct)
    /// MUST be called from Update().
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="go"></param>
    /// <param name="destTrans"></param>
    /// <param name="lerpPct"></param>
    public static void MoveTowardsInterpolate_NoPhysics(this Transform go, Transform destTrans, float lerpPct)
    {
        MoveTowardsInterpolate_NoPhysics(go, destTrans.position, lerpPct);
    }

    /// <summary>
    /// Interpolate from source to dest by a percentage each frame (lerpPct)
    /// MUST be called from Update().
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="goTrans"></param>
    /// <param name="destV"></param>
    /// <param name="lerpPct"></param>
    public static void MoveTowardsInterpolate_NoPhysics(this Transform goTrans, Vector3 destV, float lerpPct)
    {
        goTrans.position = Vector3.Lerp(goTrans.transform.position, destV, lerpPct);
    }

    // MoveTowardsInterpolate
    #endregion

    #region TeleportForward_NoPhysics

    /// <summary>
    /// Teleport the object forward in the direction it is rotated.
    /// If you rotate the object 90 degrees, it will now move forward in the direction
    /// it is now facing. This essentially translates local coordinates to 
    /// world coordinates to move object in direction and distance specified by vector.
    /// MUST be called from the Update() function
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="go"></param>
    /// <param name="speed"></param>
    public static void TeleportForward_NoPhysics(this GameObject go, float speed)
    {
        TeleportForward_NoPhysics(go.transform, speed);
    }

    /// <summary>
    /// Teleport the object forward in the direction it is rotated.
    /// If you rotate the object 90 degrees, it will now move forward in the direction
    /// it is now facing. This essentially translates local coordinates to 
    /// world coordinates to move object in direction and distance specified by vector.
    /// MUST be called from the Update() function
    /// NOTE: Does NOT handle collisions
    /// </summary>
    /// <param name="go"></param>
    /// <param name="speed"></param>
    public static void TeleportForward_NoPhysics(this Transform go, float speed)
    {
        go.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // TeleportForward_NoPhysics
    #endregion

    #region MoveByForcePushing_WithPhysics

    // TODO: add function with Destination vector, then calculate moveDirection from that

    /// <summary>
    /// Moves the object by pushing it from <paramref name="moveDirection"/>.
    /// Example. To move forward, use Vector3.Backward
    /// NOTE: Uses Physics
    /// NOTE: Must be called from FixedUpdate()
    /// </summary>
    /// <param name="go"></param>
    /// <param name="moveDirection"></param>
    /// <param name="force"></param>
    public static void MoveByForcePushing_WithPhysics(this Rigidbody go, Vector3 moveDirection, float force)
    {
        go.AddForce(moveDirection * force);
    }

    // MoveByForcePushing
    #endregion

    #region MoveByVelocity_WithPhysics

    // TODO: add function with Destination vector, then calculate moveDirection from that

    /// <summary>
    /// Chnages the rigidbody's velocity (Cause the object to act like it's being pushed).
    /// If not called on every update, the object will slow down due to friction.
    /// NOTE: Uses Physics
    /// NOTE: Must be called from FixedUpdate()
    /// </summary>
    /// <param name="go"></param>
    /// <param name="movementDirection"></param>
    /// <param name="speed"></param>
    public static void MoveByVelocity_WithPhysics(this Rigidbody go, Vector3 movementDirection, float speed)
    {
        go.velocity = movementDirection * speed;
    }

    // MoveByVelocity_WithPhysics
    #endregion

    #region MoveTowards_WithPhysics

    // TODO: add function with Destination vector, then calculate moveDirection from that

    /// <summary>
    /// Move the rigidbody's position (note this is not via the transform). 
    /// This method will push other objects out of the way
    /// NOTE: Uses Physics
    /// NOTE: Must be called from FixedUpdate()
    /// </summary>
    /// <param name="go"></param>
    /// <param name="movementDirection"></param>
    /// <param name="speed"></param>
    public static void MoveTowards_WithPhysics(this Rigidbody go, Vector3 movementDirection, float speed)
    {
        go.MovePosition(go.position + (movementDirection * speed * Time.deltaTime));
    }

    // MoveTowards_WithPhysics
    #endregion

    // TODO: rotations (msdn.microsoft.com/en-us/magazine/dn802605.aspx)
}
