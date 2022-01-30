using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumor : MonoBehaviour
{
    public float Size;
    public bool Healed;

    public Animator anim;

    #if UNITY_EDITOR
    private void OnValidate()
    {
        if(GetComponent<SphereCollider>() != null)
        {
            Size = GetComponent<SphereCollider>().radius;
        }
    }
    #endif

    public void Heal()
    {
        Healed = true;

        if (anim)
        {
            anim.SetTrigger("healed");
        }
    }

    public void DestroyTumor()
    {
        this.gameObject.SetActive(false);
    }
}
