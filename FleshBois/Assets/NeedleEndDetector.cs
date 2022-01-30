using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleEndDetector : MonoBehaviour
{
    public Syringe syringe;

    public GameObject tumor;
    public GameObject alien;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tumor" && other != tumor)
        {
            tumor = other.gameObject;
            syringe.EnteredTumor();
        }

        if (other.tag == "Alien" && other != alien)
        {
            alien = other.gameObject;
            syringe.EnteredAlien();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != tumor)
        {
            syringe.ExitedTumor();
            tumor = null;
        }

        if (other.tag == "Alien" && other != alien)
        {
            syringe.ExitedAlien();
            alien = null;
        }
    }
}
