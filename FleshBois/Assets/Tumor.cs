using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumor : MonoBehaviour
{
    public float Size;
    public bool Healed;

    #if UNITY_EDITOR
    private void OnValidate()
    {
        Size = GetComponent<SphereCollider>().radius;
    }
    #endif
}
