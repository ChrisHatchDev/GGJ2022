using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject AlienPrefab;
    public Transform SpawnPointTrans;

    public Animator anim;

    void Start()
    {
    }

    public void StartLaunchSequence()
    {
        anim.SetTrigger("spawn");
    }

    public void LaunchNewAlien()
    {
        Instantiate(AlienPrefab, SpawnPointTrans.position, SpawnPointTrans.rotation);
    }

    public void DisposeOfAlien()
    {
        anim.SetTrigger("dumpsterOpen");
    }
}
