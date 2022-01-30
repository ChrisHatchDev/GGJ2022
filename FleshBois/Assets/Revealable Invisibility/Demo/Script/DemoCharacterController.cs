using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Move the player's character around
/// </summary>
public class DemoCharacterController : MonoBehaviour
{
    private Rigidbody RigidBody;
    public float Speed = 1.0f;

    /// <summary>
    /// Object instantiation
    /// </summary>
    private void Awake()
    {
        this.RigidBody = this.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Every frame
    /// </summary>
    private void Update()
    {
        //Level-ish inputs
        if (Input.GetKey(KeyCode.Escape) == true) Application.Quit();

        //User inputs
        Vector3 Direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W) == true) Direction += this.transform.forward;
        if (Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.S) == true) Direction -= this.transform.forward;
        if (Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A) == true) Direction -= this.transform.right;
        if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D) == true) Direction += this.transform.right;

        //Normalize to avoid fast diagonal
        Direction.Normalize();
        Direction *= this.Speed;

        //Preserve falls
        float VerticalSpeed = this.RigidBody.velocity.y;
        Direction.y = VerticalSpeed;
        this.RigidBody.velocity = Direction;
    }


}
