using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth = 3.0f;
    public float CurrentHealth;

    // AUDIO 
    public AudioClip enemydamage;
    AudioSource audioSource;

    // SFX
    public GameObject sfxmanager;
    public SFXScript sfx;

    public ParticleSystem POOF;
    MeshRenderer MR;
    Material BaseMaterial;
    public Material HurtMaterial;
    float HurtTimer = 0.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MR = GetComponent<MeshRenderer>();
        CurrentHealth = MaxHealth;

        //SFX
        sfxmanager = GameObject.Find("SFXManager");
        sfx = (SFXScript)sfxmanager.GetComponent(typeof(SFXScript));

        BaseMaterial = MR.material;
    }

    void Update()
    {
        HurtTimer -= Time.deltaTime;
        if (CurrentHealth <= 0)
        {
            Death();
        }
        if (HurtTimer < 0.0f) { MR.material = BaseMaterial;}

    }

    public void AdjustHealth(float HealthAdjustment)
    {
        CurrentHealth += HealthAdjustment;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("PlayerBullet"))
        {
            AdjustHealth(-1);
            audioSource.PlayOneShot(enemydamage, 0.3F);

            MR.material = HurtMaterial;
            HurtTimer = 0.2f;

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ocean"))
        {
            Death();
        }
    }

    private void Death()
    {
        sfx.EnemyDead();
        Instantiate(POOF, transform.position, Quaternion.identity);
        GameObject.Destroy(gameObject);

    }

    public void ExplosionDamage() 
    {
        AdjustHealth(-1);
    }
}
