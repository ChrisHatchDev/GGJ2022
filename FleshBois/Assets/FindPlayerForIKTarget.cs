using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class FindPlayerForIKTarget : MonoBehaviour
{
    public AimIK ikScript;

    #if UNITY_EDITOR
        private void OnValidate()
        {
            ikScript = GetComponent<AimIK>();    
        }
    #endif

    private void Start()
    {
        ikScript.solver.target = Camera.main.transform;
    }
}
