using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class JumpEnemy : MonoBehaviour
{
    // OBJECTS
    public GameObject player;
    Rigidbody rb;

    // ENEMY FOLLOW 
    //public float moveSpeed = 50.0f;
    public float timer; 
    public float attackRange = 15;
    public float dashforce = 500f;

    // AUDIO 
    public AudioClip enemyjump;
    AudioSource audioSource;

    void Start()
    {
        timer = Random.Range(2,4);
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        /////////  PLAYER DISTANCE ///////// 
        float distance = Vector3.Distance(player.transform.position, transform.position);

        /////////////  TIMER ///////////// 
        if (timer > 0) timer -= Time.deltaTime;
        
        ///////// ATTACK RANGE //////////
        if (timer <= 0)
        {
            if (distance < attackRange) Dash();
            timer = 2f;
        }
    }

    private void Dash()
    {
        audioSource.PlayOneShot(enemyjump, 0.2F);
        rb.AddForce((player.transform.position + new Vector3(0,1,0) - transform.position).normalized * dashforce, ForceMode.Impulse);
    }
}
