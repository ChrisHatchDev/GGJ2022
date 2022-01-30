using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alien : MonoBehaviour
{
    public Tumor[] Tumors;

    public UnityEvent OnHealed = new UnityEvent();

    #if UNITY_EDITOR
    private void OnValidate()
    {
        this.Tumors = GetComponentsInChildren<Tumor>();
    }
    #endif

    private void Start()
    {
        StartCoroutine(SlowUpdate());
    }

    IEnumerator SlowUpdate()
    {
        yield return new WaitForSeconds(1.0f);
        
        bool allTumorsAreHealed = true;

        foreach (Tumor item in Tumors)
        {
            if (item.Healed == false)
            {
                allTumorsAreHealed = false;
            }
        }

        if (allTumorsAreHealed)
        {
            if (OnHealed != null)
            {
                OnHealed.Invoke();
            }
            yield break;
        } else {
            StartCoroutine(SlowUpdate());
        }
    }
}
