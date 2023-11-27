using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FloatPadSpawn : MonoBehaviour
{

    public GameObject floatpad;
    public float spawnrate = 5.0f;
    public float timer;
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        timer = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnrate) 
        {
            GameObject islandClone = Instantiate(floatpad, transform.position, Quaternion.Euler(0,rotation,0));
            timer = 0.0f;
        }
    }
}
