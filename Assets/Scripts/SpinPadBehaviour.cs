using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPadBehaviour : MonoBehaviour
{
    public float spinforce = 10.0f;
    public float targetspin = 2.0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dif = targetspin - rb.angularVelocity.y;
        //Debug.Log(rb.angularVelocity.y + ":" + gameObject.name);
        if (rb.angularVelocity.y < targetspin)
        {
            rb.AddTorque(0, spinforce * dif, 0, ForceMode.Impulse);
        }
    }
}
