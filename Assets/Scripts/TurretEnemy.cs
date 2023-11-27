using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    // The target marker.
    public GameObject target;
    public GameObject bullet;
    public Transform firepoint;

    // Angular speed in radians per sec.
    public float rotationspeed = 1.0f;

    // Shooting
    float targetdistance, timer;
    public float targetrange = 20.0f, bulletlag = 0.5f, bulletspeed = 20.0f;

    // AUDIO 
    public AudioClip shoot;
    AudioSource audioSource;

    //Follow
    Rigidbody rb;
    public float followrange;
    public float followspeed;
    public float stoprange;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        timer = bulletlag;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        targetdistance = Vector3.Distance(target.transform.position, transform.position);

        
        if (targetdistance < targetrange) 
        {

            Shoot(bulletspeed, bulletlag, bullet);
        }
        if (targetdistance < followrange) 
        {
            RotateToTarget();

            if(targetdistance> stoprange) { Dash(); }

        }
    }

    void RotateToTarget() 
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = rotationspeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void Shoot(float speed, float bulletlag, GameObject projectile)
    {
        // Shoot forawrd direction
        Vector3 dir = transform.forward;

        // Timer countdown
        timer -= Time.deltaTime;

        // if firerate is below zero then ready to shoot
        if (timer <= 0)
        {
                // PLay sound effect of shot
                audioSource.PlayOneShot(shoot, 0.1F);

                // Spawn the bullet from the prefab.
                GameObject bulletClone = Instantiate(projectile, firepoint.position, Quaternion.identity);
                bulletClone.GetComponent<Rigidbody>().velocity = dir * speed;

                // Reset firerate.
                timer = bulletlag;
        }
    }

    private void Dash()
    {
        rb.AddForce((target.transform.position +new Vector3(0,2,0) - transform.position).normalized * followspeed);
    }
}
