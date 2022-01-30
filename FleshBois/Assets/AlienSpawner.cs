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

    public void LaunchNewAlien()
    {
        anim.SetTrigger("spawn");
        Instantiate(AlienPrefab, SpawnPointTrans.position, SpawnPointTrans.rotation);
    }

    public void DisposeOfAlien()
    {
        anim.SetTrigger("dumpsterOpen");
        Instantiate(AlienPrefab, SpawnPointTrans.position, SpawnPointTrans.rotation);
    }
}
