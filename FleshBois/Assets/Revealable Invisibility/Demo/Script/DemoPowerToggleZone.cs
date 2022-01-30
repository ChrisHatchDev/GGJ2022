using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Detect the character's and turn it's revealing capacity on/off
/// </summary>
[RequireComponent(typeof(Collider))]
public class DemoPowerToggleZone : MonoBehaviour
{
    public GameObject Player;
    public bool TurnOn = true;
    private Rigidbody PlayerRigidbody;
    private Seer PlayerRevealer;

    /// <summary>
    /// Instantiation
    /// </summary>
    private void Awake()
    {
        this.PlayerRigidbody = this.Player.GetComponent<Rigidbody>();
        this.PlayerRevealer = this.Player.GetComponentInChildren<Seer>();
    }

    /// <summary>
    /// Something entered
    /// </summary>
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.attachedRigidbody != this.PlayerRigidbody) return;
        this.PlayerRevealer.gameObject.SetActive(this.TurnOn);
    }


}
