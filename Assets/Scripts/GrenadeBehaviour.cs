using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    public float timer;
    public float lifespan = 1;
    public ParticleSystem explosion;

    // SFX
    public GameObject sfxmanager;
    public SFXScript sfx;

    public float radius = 15.0F;
    public float power = 1000.0F;



    void Start()
    {
        sfxmanager = GameObject.Find("SFXManager");
        sfx = (SFXScript)sfxmanager.GetComponent(typeof(SFXScript));

    }

    void Update()
    {
        timer += 1.0F * Time.deltaTime;
        if (timer >= lifespan)
        {
            Boom();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Player") || other.gameObject.name == ("Firepoint"))
        {
            //do nothing
        }
        else
        {
            Boom();
        }
    }

    void Boom() 
    {
        DestroyBoom();
        PushBoom();
        ExplodeBoom();
    }

    private void DestroyBoom()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius / 2);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag == "Enemy") { hit.GetComponent<EnemyHealth>().AdjustHealth(-2); }
            if (hit.gameObject.tag == "Player") { hit.GetComponent<PlayerHealth>().AdjustHealth(-2); }
            if (hit.gameObject.tag == "Barrel") { hit.GetComponent<Barrel>().Boom(); }
        }
    }

    private void PushBoom()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            //Debug.Log(hit.gameObject.tag);

            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }


    private void ExplodeBoom()
    {
        sfx.Explosion();
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);
    }
}
