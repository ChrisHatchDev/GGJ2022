using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Detect the character and replace it at the start
/// </summary>
[RequireComponent(typeof(Collider))]
public class DemoDeathZone : MonoBehaviour
{
    public GameObject Player;
    public GameObject StartingPoint;
    public CanvasGroup DeathMessage;
    public float MessageSpeed = 0.5f;
    private Rigidbody PlayerRigidbody;
    private Seer PlayerRevealer;

    /// <summary>
    /// Instantiation
    /// </summary>
    private void Awake()
    {
        this.DeathMessage.alpha = 0;
        this.PlayerRigidbody = this.Player.GetComponent<Rigidbody>();
        this.PlayerRevealer = this.Player.GetComponentInChildren<Seer>();
    }

    /// <summary>
    /// Every frame
    /// </summary>
    private void Update()
    {
        this.DeathMessage.alpha -= Time.deltaTime * this.MessageSpeed;
    }

    /// <summary>
    /// Something entered
    /// </summary>
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.attachedRigidbody != this.PlayerRigidbody) return;
        this.Player.transform.position = this.StartingPoint.transform.position;
        this.DeathMessage.alpha = 1;

        //Make sure to turn the power back on just in case
        this.PlayerRevealer.gameObject.SetActive(true);
    }


}
