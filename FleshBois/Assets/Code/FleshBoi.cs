using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FleshBoi : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;

    public PlayerInput playerInput;
    

    void Awake()
    {
        playerInput.actions.FindActionMap("XRI HMD").Enable();
        playerInput.actions.FindActionMap("XRI LeftHand").Enable();
        playerInput.actions.FindActionMap("XRI RightHand").Enable();
    }

    public void OnPlunge(Tumor tumor, Alien alien)
    {

        if (tumor != null)
        {
            tumor.Heal();
            GameManager.Instance.score.addTumor(tumor.Size);
        }

        if (alien != null)
        {
            GameManager.Instance.score.addDamage(30.0f);
            alien.DecrementHealth();
        }
    }

    public void OnRightTrigger(InputValue val)
    {
        // GameManager.Instance.score.addTumor(0.5f);
    }
}
