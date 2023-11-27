using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonSpawn : MonoBehaviour
{
    public float shootdelay = 2.0f;
    public float timer = 0.0f;
    public float force = 5.0f;
    //private float offset = 10.0f;
    public GameObject cannonball;
    public GameObject firepoint;

    // AUDIO 
    public AudioClip cannonshoot;
    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = 1f;
    }


    void Update()
    {
        Shoot();
    }

    void Shoot() 
    {

        timer -= Time.deltaTime;

        // Direction from player to mouse
        Vector3 dir = transform.forward;

        // if firerate is below zero then ready to shoot
        if (timer <= 0)
        {
             // PLay sound effect of shot
             audioSource.PlayOneShot(cannonshoot, 0.1F);

             // Spawn smal explosion
             //Instantiate(smallexplosion, firepoint.position, Quaternion.identity);

             // Spawn the bullet from the prefab.
             GameObject cannonballClone = Instantiate(cannonball, firepoint.transform.position, Quaternion.identity);
             cannonballClone.GetComponent<Rigidbody>().velocity = dir * force;

             // Reset firerate.
             timer = shootdelay;

        }


    }
}
