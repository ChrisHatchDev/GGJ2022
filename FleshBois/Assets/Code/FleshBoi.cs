using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FleshBoi : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;

    void Start()
    {
        
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
