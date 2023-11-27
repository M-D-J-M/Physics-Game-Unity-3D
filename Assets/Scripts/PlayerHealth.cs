using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 5.0f;
    public float CurrentHealth;

    // AUDIO 
    public AudioClip damage;
    public AudioClip pickup;
    AudioSource audioSource;

    //Hurt
    MeshRenderer MR;
    Material BaseMaterial;
    public Material HurtMaterial;
    float HurtTimer = 0.0f;

    void Start()
    {
        MR = GetComponent<MeshRenderer>();
        BaseMaterial = MR.material;

        audioSource = GetComponent<AudioSource>();
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        HurtTimer -= Time.deltaTime;
        if (CurrentHealth <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (HurtTimer < 0.0f) { MR.material = BaseMaterial; }
    }

    public void AdjustHealth(float HealthAdjustment) 
    { 
        CurrentHealth += HealthAdjustment;
        if (CurrentHealth >= MaxHealth) CurrentHealth = MaxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("EnemyBullet"))
        {
            AdjustHealth(-1);
            audioSource.PlayOneShot(damage, 0.7F);

            MR.material = HurtMaterial;
            HurtTimer = 0.1f;
        }

        if (other.gameObject.tag == ("FirstAid"))
        {
            AdjustHealth(3);
            audioSource.PlayOneShot(pickup, 0.7F);
        }

        if (other.gameObject.tag == ("Gun"))
        {
            audioSource.PlayOneShot(pickup, 0.7F);
        }

        else
        {
            // do nothing
        }
    }
}
