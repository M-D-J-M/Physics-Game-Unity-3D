using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float timer;
    public float lifespan = 1;

    void Update()
    {
        timer += 1.0F * Time.deltaTime;
        if (timer >= lifespan)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Player") || other.gameObject.name == ("Firepoint"))
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
}
