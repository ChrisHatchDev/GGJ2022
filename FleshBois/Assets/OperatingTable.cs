using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatingTable : MonoBehaviour
{
    public Animator anim;

    public void Yeet()
    {
        anim.SetTrigger("yeet");
    }

    public void UnYeet()
    {
        anim.SetTrigger("unyeet");
    }
}
