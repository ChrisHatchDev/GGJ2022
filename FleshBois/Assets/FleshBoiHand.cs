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

    public Hand hand;

    public bool PlungerIsActive;

    void Start()
    {
        
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

        if (_triggerPressed > 0.5f)
        {
            PlungerIsActive = true;
        } else {
            PlungerIsActive = false;
        }
    }

    public void OnRightTrigger(InputValue context)
    {
        if (hand != Hand.Right) return;

        float _triggerPressed = context.Get<float>();

        if (DebugTriggerText) DebugTriggerText.text = _triggerPressed.ToString();

        if (_triggerPressed > 0.5f)
        {
            PlungerIsActive = true;
        } else {
            PlungerIsActive = false;
        }
    }
}
