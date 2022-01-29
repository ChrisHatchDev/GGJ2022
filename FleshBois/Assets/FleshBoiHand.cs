using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FleshBoiHand : MonoBehaviour
{
    public Syringe HeldSyringe;

    void Start()
    {
        
    }

    public void OnSelectEnter(SelectEnterEventArgs ev)
    {
        if (ev.interactableObject.transform.tag == "Syringe")
        {
            HeldSyringe = ev.interactableObject.transform.GetComponent<Syringe>();
        }
    }

    public void OnSelectExit(SelectExitEventArgs ev)
    {
        if (ev.interactableObject.transform.gameObject == HeldSyringe)
        {
            HeldSyringe = null;
        }
    }
}
