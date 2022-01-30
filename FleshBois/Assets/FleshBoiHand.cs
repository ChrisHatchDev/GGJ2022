using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public enum Hand
{
    Left = 0,
    Right = 1,
}

public class FleshBoiHand : MonoBehaviour
{
    public Syringe HeldSyringe;
    public Text DebugTextObject;
    public Text DebugTriggerText;

    public Text DebugInTumorAlienText;


    public Hand hand;

    void Start()
    {
        
    }

    private void Update()
    {
        if (HeldSyringe && DebugInTumorAlienText)
        {
            DebugInTumorAlienText.text = "Tumor: " + HeldSyringe.InTumor + " Alien: " + HeldSyringe.InAlien;
        }
    }

    public void OnSelectEnter(SelectEnterEventArgs ev)
    {
        if (ev.interactableObject.transform.tag == "Syringe")
        {
            HeldSyringe = ev.interactableObject.transform.GetComponent<Syringe>();
            
            if (DebugTextObject) DebugTextObject.text = HeldSyringe.gameObject.name;
        }
    }

    public void OnSelectExit(SelectExitEventArgs ev)
    {
        if (ev.interactableObject.transform.gameObject == HeldSyringe.gameObject)
        {
            HeldSyringe = null;
            if (DebugTextObject) DebugTextObject.text = "";
        }
    }

    public void OnUIPress(InputValue val)
    {
        bool _triggerPressed = val.Get<bool>();

        if (DebugTriggerText) DebugTriggerText.text = _triggerPressed.ToString();

        if (_triggerPressed)
        {

        }
    }

    public void OnLeftTrigger(InputValue context)
    {
        if (hand != Hand.Left) return;

        float _triggerPressed = context.Get<float>();

        if (DebugTriggerText) DebugTriggerText.text = _triggerPressed.ToString();

        if (_triggerPressed > 0.5f && HeldSyringe)
        {
            HeldSyringe.Plunge();
        }
    }

    public void OnRightTrigger(InputValue context)
    {
        if (hand != Hand.Right) return;

        float _triggerPressed = context.Get<float>();

        if (DebugTriggerText) DebugTriggerText.text = _triggerPressed.ToString();

        if (_triggerPressed > 0.5f && HeldSyringe)
        {
            HeldSyringe.Plunge();
        }
    }
}
