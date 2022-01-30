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

    public void OnPlunge(bool inTumor, bool inAlien)
    {

        if (inTumor)
        {

        }

        if (inAlien)
        {

        }
    }
}
