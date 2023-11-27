using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip;
    public GameObject player;
    public new Transform camera;
    public float maxDistance = 100f;
    private SpringJoint joint;
    public bool isGrappling = false;
    public bool grounded = false;

    // GrappleBar

    public float MaxGrapple = 10f;
    public float CurrentGrapple;

    // WEAPONS

    public GameObject WeaponDisplay;
    public WeaponDisplay weaponscript;

    void Awake()
    {
        CurrentGrapple = MaxGrapple;
        lr = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        player = GameObject.Find("Player");
        WeaponDisplay = GameObject.Find("WeaponDisplay");
        weaponscript = (WeaponDisplay)WeaponDisplay.GetComponent(typeof(WeaponDisplay));
        camera = Camera.main.transform;

        StopGrapple();
    }

    void Update()
    {
        grounded = player.GetComponent<PlayerMovement>().grounded;
        if (weaponscript.grapplinghookpickedup)
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartGrapple();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                StopGrapple();
            }

            AdjustGrappleBar();
        }
    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// Call whenever we want to start a grapple
    void StartGrapple()
    {
        //CurrentGrapple -= Time.deltaTime;
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    /// Call whenever we want to stop a grapple
    void StopGrapple()
    {
        //CurrentGrapple -= Time.deltaTime;
        isGrappling = false;
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        isGrappling = true;
        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        
        return joint != null;
        
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }

    void AdjustGrappleBar() 
    {
        if (isGrappling)
        {
            CurrentGrapple -= Time.deltaTime;
            if (CurrentGrapple <= 0) 
            { 
                CurrentGrapple = 0; 
                StopGrapple(); 
            }

        }
        if (grounded == true) 
        {
            CurrentGrapple += Time.deltaTime;
            if (CurrentGrapple >= MaxGrapple)  CurrentGrapple = MaxGrapple; 
        }
    }
}
