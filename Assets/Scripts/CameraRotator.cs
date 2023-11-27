using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class CameraRotator : MonoBehaviour
{
    public float camrotspeed = 100.0f;
    public float offsety = 4.0f;
    public float scale = 1.0f;
    public float nearzoom = -5.0f;
    public float farzoom = -30.0f;

    GameObject player;
    public Camera cam;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0.0f, offsety, 0); //follow player

        if (Input.GetKeyDown(KeyCode.Q) && cam.transform.localPosition.z <= nearzoom) cam.transform.Translate(0, 0, 1); //zoomin (nz-4)
        if (Input.GetKeyDown(KeyCode.E) && cam.transform.localPosition.z >= farzoom) cam.transform.Translate(0, 0, -1); //zoomout (fz-30)

        // zoom

        float camrothorizontal = Input.GetAxis("Mouse X") * camrotspeed * Time.deltaTime;
        float camrotvertical = Input.GetAxis("Mouse Y") * camrotspeed * Time.deltaTime;

        float rotationAroundYAxis = camrothorizontal; // camera moves horizontally
        float rotationAroundXAxis = -camrotvertical; // camera moves vertically

        transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
        transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
    }
}
