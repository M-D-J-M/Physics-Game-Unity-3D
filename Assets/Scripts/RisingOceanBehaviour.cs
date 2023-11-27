using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingOceanBehaviour : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 1.0f;
    public float maxspeed = 4.0f;
    public float speedincrese = 0.0001f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(0,speed,0);
        //Debug.Log(rb.velocity);
        speed = speed + speedincrese;
        if (speed>maxspeed) speed = maxspeed;
    }

    void OnTriggerEnter(Collider other)
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
