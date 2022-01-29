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
        if (ev.interactorObject.transform.tag == "Syringe")
        {

        }
    }

    public void OnSelectExit(SelectExitEventArgs ev)
    {
        if (ev.interactorObject.transform.gameObject == HeldSyringe)
        {

        }
    }
}
