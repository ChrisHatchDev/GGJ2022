using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject AlienPrefab;
    public Transform SpawnPointTrans;

    void Start()
    {
        LaunchNewAlien();
    }

    public void LaunchNewAlien()
    {
        Instantiate(AlienPrefab, SpawnPointTrans.position, SpawnPointTrans.rotation);
    }
}
