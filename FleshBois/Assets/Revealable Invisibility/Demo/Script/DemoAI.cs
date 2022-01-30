using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Use Unity pathfinding to randomly explore the level
/// </summary>
public class DemoAI : MonoBehaviour
{
    static private System.Random Dice = new System.Random();

    private NavMeshAgent Agent;
    public BoxCollider Zone;

    /// <summary>
    /// "Constructor"
    /// </summary>
    private void Awake()
    {
        this.Agent = this.GetComponent<NavMeshAgent>();
        this.Agent.autoRepath = true;
    }

    /// <summary>
    /// Every physic frame
    /// </summary>
    private void FixedUpdate()
    {
        //Already on a path to something ?
        if (this.Agent.hasPath == false && this.Agent.pathPending == false)
        {
            Bounds Bounds = this.Zone.bounds;
            float XRoll = (float) DemoAI.Dice.NextDouble();
            float YRoll = (float) DemoAI.Dice.NextDouble();
            float ZRoll = (float) DemoAI.Dice.NextDouble();
            float X = (Bounds.min.x * (1.0f - XRoll)) + (Bounds.max.x * XRoll);
            float Y = (Bounds.min.y * (1.0f - YRoll)) + (Bounds.max.y * YRoll);
            float Z = (Bounds.min.z * (1.0f - ZRoll)) + (Bounds.max.z * ZRoll);
            this.Agent.SetDestination(new Vector3(X, Y, Z));
        }
    }
}
