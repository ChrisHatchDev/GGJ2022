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

    #if UNITY_EDITOR
        private void OnValidate()
        {
            TargetColorMesh.materials = new Material[] { Materials[(int)JuiceType] };    
        }
    #endif

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Activate()
    {

    }

    public void EnteredTumor()
    {

    }

    public void ExitedTumor()
    {
        
    }
}
