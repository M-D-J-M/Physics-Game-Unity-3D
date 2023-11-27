using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPivot : MonoBehaviour
{
    Rigidbody rb;
    public float spinforce = 0.5f;
    public float targetspin = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Spin();
    }

    void Spin()
    {
        float dif = targetspin - rb.angularVelocity.y;
        if (rb.angularVelocity.y < targetspin)
        {
            rb.AddTorque(0, spinforce * dif, 0, ForceMode.Impulse);
        }
    }
}
