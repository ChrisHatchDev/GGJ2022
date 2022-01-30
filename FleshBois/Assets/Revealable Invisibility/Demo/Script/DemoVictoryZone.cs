using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Detect the character and start the firework
/// </summary>
[RequireComponent(typeof(Collider))]
public class DemoVictoryZone : MonoBehaviour
{
    public GameObject Player;
    public CanvasGroup Message;
    public float MessageSpeed = 0.5f;
    private Rigidbody PlayerRigidbody;
    public ParticleSystem[] Fireworks;
    private bool AlreadyDone = false;

    /// <summary>
    /// Instantiation
    /// </summary>
    private void Awake()
    {
        this.Message.alpha = 0;
        this.PlayerRigidbody = this.Player.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Every frame
    /// </summary>
    private void Update()
    {
        this.Message.alpha -= Time.deltaTime * this.MessageSpeed;
    }

    /// <summary>
    /// Something entered
    /// </summary>
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.attachedRigidbody != this.PlayerRigidbody) return;
        if (this.AlreadyDone == true) return;
        this.AlreadyDone = true;

        this.Message.alpha = 1;
        foreach(ParticleSystem Firework in this.Fireworks)
        {
            Firework.Play();
        }
    }


}
