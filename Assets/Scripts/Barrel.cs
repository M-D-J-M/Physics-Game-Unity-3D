using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public ParticleSystem explosion;

    // SFX
    public GameObject sfxmanager;
    public SFXScript sfx;

    // BOOM
    public float radius = 15.0F;
    public float power = 1000.0F;

    void Start()
    {
        sfxmanager = GameObject.Find("SFXManager");
        sfx = (SFXScript)sfxmanager.GetComponent(typeof(SFXScript));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("PlayerBullet") || other.gameObject.tag == ("EnemyBullet"))
        {
            Boom();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ocean")) { GameObject.Destroy(gameObject); }
    }

    public void Boom()
    {
        DestroyBoom();
        PushBoom();
        ExplodeBoom();
    }

    private void DestroyBoom()
    {
        Debug.Log("destroy");
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius / 2);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag == "Enemy") { hit.GetComponent<EnemyHealth>().AdjustHealth(-2); }
            if (hit.gameObject.tag == "Player") { hit.GetComponent<PlayerHealth>().AdjustHealth(-2); }
        }
    }

    private void PushBoom()
    {
        Debug.Log("push");
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Debug.Log(hit.gameObject.tag);

            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);


            
        }
    }

    private void ExplodeBoom()
    {
        Debug.Log("explode");
        sfx.Explosion();
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);
    }
}
