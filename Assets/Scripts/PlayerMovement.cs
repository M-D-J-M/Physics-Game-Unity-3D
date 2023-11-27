using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // SPEED
    public float spinspeed = 15.0f;
    public float normalspeed = 15.0f;
    public float superspeed = 30.0f;

    // SPIN
    public float angDrag = 0.5f;
    public float maxAngVel = 50;

    // JUMP
    public ParticleSystem jumpdust;
    public Transform dust;
    public float jumpforce = 5.0f;
    public float normaljumpforce = 5.0f;
    public float superjumpforce = 25.0f;

    // JUMPTIMER
    private float jumpStartTime = 0.25f;
    public float jumpTime;
    public bool isJumping;

    // DRAG
    public float normaldrag = 0.02f;
    public float airdrag = 0.00f;
    public float muddrag = 2.0f;

    // GROUNDCHECK
    private Rigidbody rb;
    public bool grounded = false;
    public float groundCheckDistance;
    private float bufferCheckDistance = 0.5f; // slightly above 0
    public string surface;

    // AUDIO 
    public AudioClip jump;
    AudioSource audioSource;

    void Start()
    {
        dust = GameObject.Find("Dustpoint").transform;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.drag = normaldrag; // set initial drag
}

    void FixedUpdate()// for physics
    {

    }

    void Update()// for input
    {
        GroundCheck();
        Move();
        Jump();
        Respawn();
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") && grounded)
        {
            isJumping = true;
            jumpTime = jumpStartTime;

            rb.AddForce(0, jumpforce, 0, ForceMode.Impulse);

            // Audio and Dust
            audioSource.PlayOneShot(jump, 0.7F);
            Instantiate(jumpdust, dust.position, Quaternion.identity);
        }

        if (Input.GetKey("space") && isJumping)
        {
            if(jumpTime > 0) 
            {
                rb.AddForce(0, jumpforce, 0, ForceMode.Impulse);
                jumpTime -= Time.deltaTime;
            }
            else 
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp("space"))
        {
            //rb.mass = 5;
            isJumping = false;
        }
    }
    void Respawn()
    {
        if (Input.GetKeyUp("backspace"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (transform.position.y <= -55)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void Move()
    {
        rb.angularDrag = angDrag;
        rb.maxAngularVelocity = maxAngVel;

        Vector3 flatForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 moveForward = flatForward * Input.GetAxisRaw("Horizontal") * spinspeed;
        Vector3 moveRight = Camera.main.transform.right * Input.GetAxisRaw("Vertical") * spinspeed;
        rb.AddTorque(-moveForward + moveRight);

        if (surface == "Air") 
        {
            Vector3 flatForwardair = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
            Vector3 moveForwardair = flatForwardair * Input.GetAxisRaw("Vertical") * spinspeed;
            Vector3 moveRightair = Camera.main.transform.right * Input.GetAxisRaw("Horizontal") * spinspeed;
            rb.AddForce((moveRightair + moveForwardair)*0.35f);
        }
    }

    void GroundCheck()
    {
        groundCheckDistance = (GetComponent<SphereCollider>().radius) + bufferCheckDistance;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, groundCheckDistance))
        {
            surface = hit.collider.gameObject.tag;
            grounded = true;
            if (hit.collider.gameObject.tag == "FastPad") { rb.AddForce(hit.collider.gameObject.transform.forward * 2, ForceMode.Impulse); }
            SurfaceCheck(surface);
        }
        else // in air
        {
            surface = "Air";
            grounded = false;
            AirValues();
        }
    }

    void SurfaceCheck(string surface)
    {
        switch (surface)
        {
            case "FastPad":
                spinspeed = normalspeed;
                jumpforce = normaljumpforce;
                rb.drag = normaldrag;
                break;
            case "SlowPad":
                rb.drag = muddrag;
                jumpforce = normaljumpforce;
                break;
            case "JumpPad":
                spinspeed = normalspeed;
                rb.drag = normaldrag;
                jumpforce = superjumpforce;
                break;
            case "Ground":
                spinspeed = normalspeed;
                jumpforce = normaljumpforce;
                rb.drag = normaldrag;
                break;
            case "Ocean":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }

    void AirValues()
    {
        spinspeed = normalspeed;
        rb.drag = airdrag;
        jumpforce = normaljumpforce;
    }
}
