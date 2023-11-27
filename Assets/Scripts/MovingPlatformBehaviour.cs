using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    public float moveforce = 1.0f;
    public float targetspeed = 10.0f;

    public float timer;
    public float lifespan = 20.0f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timer += 1.0F * Time.deltaTime;

        float dif = targetspeed - rb.velocity.x;

        if (rb.velocity.x < targetspeed && rb.velocity.x > -targetspeed && rb.velocity.z < targetspeed && rb.velocity.z > -targetspeed)
        {
            rb.AddForce((transform.forward) * moveforce * dif, ForceMode.Impulse);
        }


        if (timer >= lifespan)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
