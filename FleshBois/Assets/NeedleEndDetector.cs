using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleEndDetector : MonoBehaviour
{
    public Syringe syringe;

    public Tumor tumor;
    public Alien alien;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tumor" && tumor == null && other != tumor)
        {
            tumor = other.GetComponent<Tumor>();
            syringe.EnteredTumor(tumor);
        }

        if (other.tag == "Alien" && alien == null && other != alien)
        {
            alien = other.transform.root.GetComponent<Alien>();
            syringe.EnteredAlien(alien);
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
