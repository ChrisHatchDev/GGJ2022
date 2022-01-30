using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Automatically move the camera to follow the character
/// </summary>
public class DemoCameraController : MonoBehaviour
{
    public GameObject ToFollow;
    
    /// <summary>
    /// Every end of frame
    /// </summary>
    private void LateUpdate()
    {
        //Just slide along the X axis
        Vector3 Position = this.transform.position;
        Position.x = this.ToFollow.transform.position.x;
        this.transform.position = Position;
    }
}
