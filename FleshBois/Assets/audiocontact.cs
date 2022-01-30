using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiocontact : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip squish;
    public float nextSound = 0.0f;
    float fireRate = 1.0f;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(Time.time > nextSound){
            nextSound = Time.time + fireRate;
            //Debug.Log("COLLIDED");
            audioSource.PlayOneShot(squish, 1.0f);
        }
     }
}
