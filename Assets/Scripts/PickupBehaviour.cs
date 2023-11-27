using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public float groundCheckDistance;
    Rigidbody rb;

    void Start()
    {        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player")) GameObject.Destroy(gameObject);
    }

    void GroundCheck()
    {
        groundCheckDistance = 2f;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, groundCheckDistance))
        {
             rb.AddForce(hit.collider.gameObject.transform.up, ForceMode.Impulse); 

        }
    }

}
