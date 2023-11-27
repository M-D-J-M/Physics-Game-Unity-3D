using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{

    // AUDIO 
    public AudioClip explosion;
    public AudioClip enemydead;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explosion() 
    {
        audioSource.PlayOneShot(explosion, 0.7F);
    }

    public void EnemyDead()
    {
        //audioSource.PlayOneShot(enemydead, 0.2F);
    }
}
