using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Juice
{
    Red = 0,
    Blue = 1,
    Green = 2,
}

public class Syringe : MonoBehaviour
{
    public Juice JuiceType;
    public Transform NeedleEndPoint;

    public MeshRenderer TargetColorMesh;
    public List<Material> Materials;
    public Animator anim;

    public bool HasPlunged = false;
    public bool InTumor = false;
    public bool InAlien = false;

    public FleshBoi holdingPlayer;

    #if UNITY_EDITOR
        private void OnValidate()
        {
            TargetColorMesh.materials = new Material[] { Materials[(int)JuiceType] };    
        }
    #endif

    public void Activate()
    {

    }

    public void EnteredTumor()
    {
        InTumor = true;
    }

    public void ExitedTumor()
    {
        InTumor = false;   
    }

    public void EnteredAlien()
    {
        InAlien = true;
    }

    public void ExitedAlien()
    {
        InAlien = false;   
    }

    public void Plunge()
    {
        if (HasPlunged == false)
        {
            anim.SetTrigger("plunge");
            HasPlunged = true;

            holdingPlayer.OnPlunge(InTumor, InAlien);
        }
    }
}
