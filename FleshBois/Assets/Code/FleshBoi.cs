using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FleshBoi : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;

    public Syringe ActiveSyrings;
    
    public PlayerInput playerInput;

    void Awake()
    {
        playerInput.actions.FindActionMap("XRI HMD").Enable();
        playerInput.actions.FindActionMap("XRI LeftHand").Enable();
        playerInput.actions.FindActionMap("XRI RightHand").Enable();
    }

    void Update()
    {
        
    }


    public void OnSelectEnter(SelectEnterEventArgs ev)
    {
        if (ev.interactorObject.transform.tag == "Syringe")
        {

        }
    }

    public void OnSelectExit(SelectExitEventArgs ev)
    {

        
    }
}
