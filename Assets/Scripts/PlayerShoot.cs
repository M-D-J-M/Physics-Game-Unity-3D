using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class PlayerShoot : MonoBehaviour
{
    // STUFF
    public GameObject targetball;
    public Transform cam;
    public LineRenderer laserLineRenderer;

    // LASER
    public Transform firepoint;
    public float laserMaxLength = 200.0f;
    float laserlenght, tbscale;
    Vector3 laserdir;

    // TARGET
    Vector3 targetposition = Vector3.zero;
    public string targetinfo;

    // PEW PEW 
    public GameObject bullet;
    public GameObject grenade;
    public ParticleSystem smallexplosion;
    public float bulletSpeed = 15.0f;
    public string weapon = "none";
    public float fireratetimer = 0.0f;
    public float reloadbarmax;
    public float weaponhotkey = 1;

    // AMMO 
    public float pistolammo = 0f;
    public float machinegunammo = 0f;
    public float shotgunammo = 0f;
    public float grenadeammo = 0f;
    public float ammo;
    public TextMeshProUGUI ammotext;

    // AUDIO 
    public AudioClip shoot;
    public AudioClip shotgunshoot;
    AudioSource audioSource;

    // SFX
    public GameObject WeaponDisplay;
    public WeaponDisplay weaponscript;

    void Start()
    {
        reloadbarmax = 3.0f;
        audioSource = GetComponent<AudioSource>();
        WeaponDisplay = GameObject.Find("WeaponDisplay");

        targetball = GameObject.Find("TargetBall");
        weaponscript = (WeaponDisplay)WeaponDisplay.GetComponent(typeof(WeaponDisplay));
        cam = GameObject.Find("Main Camera").transform;
        firepoint = GameObject.Find("PlayerFirepoint").transform;
    }

    void Update()
    {
        Shortcuts();
        Shooting();
    }

    private void LateUpdate()
    {
        CameraRaycast();
        LaserAndTargetBall();
    }

    void CameraRaycast()
    {
        Ray ray = new Ray(cam.transform.position, cam.forward);// ray from camera
        RaycastHit raycastHit; // hit target
        Vector3 endPosition = cam.transform.position + (laserMaxLength * cam.forward); // target air
        targetinfo = "Air";



        if (Physics.Raycast(ray, out raycastHit, laserMaxLength)) //target hit
        {
            float cam2playerdistance = Vector3.Distance(firepoint.transform.position, cam.transform.position);// to player
            float cam2targetdistance = Vector3.Distance(raycastHit.point, cam.transform.position); // to target

            if (cam2targetdistance > cam2playerdistance)
            {
                endPosition = raycastHit.point;
                targetinfo = raycastHit.collider.gameObject.tag;
            }
        }

        targetposition = endPosition;
    }

    void LaserAndTargetBall() 
    {
        laserlenght = Vector3.Distance(targetposition, firepoint.transform.position); // laser lenght
        tbscale = 0.1f + (laserlenght / 100);
        targetball.transform.localScale = new Vector3(tbscale, tbscale, tbscale); // targetball scalechange
        targetball.transform.position = targetposition; // targetball position change
        laserdir = (targetposition - firepoint.transform.position).normalized; // dir from player to target

        ShootLaserFromTargetPosition(firepoint.transform.position, laserdir, laserMaxLength);
        laserLineRenderer.enabled = true;
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }


    void Shooting()
    {
        fireratetimer -= Time.deltaTime;
        if ( fireratetimer < 0 ) { fireratetimer = 0; }

        if (weapon == "Pistol")
        {
            if (pistolammo > 0) GunSystem(40f, 1f, 0f, 1f, bullet);
            ammo = pistolammo;
            reloadbarmax = 1f;
        }

        if (weapon == "MachineGun")
        {
            if (machinegunammo > 0) GunSystem(40f, 0.3f, 0.01f, 1f, bullet);
            ammo = machinegunammo;
            reloadbarmax = 0.3f;
        }

        if (weapon == "ShotGun")
        {
            if (shotgunammo > 0) GunSystem(40f, 1.5f, 0.15f, 10f, bullet);
            ammo = shotgunammo;
            reloadbarmax = 2f;
        }

        if (weapon == "GrenadeLauncher")
        {
            if (grenadeammo > 0) GunSystem(30f, 3f, 0.0f, 1f,  grenade);
            ammo = grenadeammo;
            reloadbarmax = 3f;
        }

    }

    void GunSystem(float speed, float bulletlag, float spray, float bulletnumber, GameObject projectile)
    {
        // set bulletlag for bar


        // Direction from player to mouse
        Vector3 dir = (targetball.transform.position - firepoint.transform.position).normalized;

        // if firerate is below zero then ready to shoot
        if (fireratetimer <= 0)
        {
            // If fire button pressed
            if (Input.GetMouseButton(0))
            {
                if (weapon == "Pistol")
                {
                    pistolammo -= 1;
                }

                if (weapon == "MachineGun")
                {
                    machinegunammo -= 1;
                }

                if (weapon == "ShotGun")
                {
                    shotgunammo -= 1;
                }

                if (weapon == "GrenadeLauncher")
                {
                    grenadeammo -= 1;
                }

                // number of bullets(shotgun)
                for (int i = 0; i < bulletnumber; i++)
                {
                    // spray
                    var randomspray = new Vector3(Random.Range(-spray, spray), Random.Range(-spray, spray), Random.Range(-spray, spray));

                    if (weapon == "ShotGun") 
                    {
                        // PLay sound effect of shot
                        audioSource.PlayOneShot(shotgunshoot, 0.05F);

                    }
                    else 
                    {
                        // PLay sound effect of shot
                        audioSource.PlayOneShot(shoot, 0.2F);
                    }



                    // Spawn smal explosion
                    Instantiate(smallexplosion, firepoint.position, Quaternion.identity);

                    // Spawn the bullet from the prefab.
                    GameObject bulletClone = Instantiate(projectile, firepoint.position, Quaternion.identity);
                    bulletClone.GetComponent<Rigidbody>().velocity = (dir + randomspray) * speed;

                    // Reset firerate.
                    fireratetimer = bulletlag;
                }
            }
        }
    }

    void Shortcuts()
    {
        weaponhotkey += Input.mouseScrollDelta.y;
        if (weaponhotkey < 1) { weaponhotkey = 4; }
        if (weaponhotkey > 4) { weaponhotkey = 1; }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { weaponhotkey = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { weaponhotkey = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { weaponhotkey = 3; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { weaponhotkey = 4; }

        if (weaponhotkey == 1)
        {
            if (weaponscript.pistolpickedup) 
            {
                weapon = "Pistol";
                weaponscript.ChoosePistol();
            }
        }

        if (weaponhotkey == 2)
        {
            if (weaponscript.machinegunpickedup)
            {
                weapon = "MachineGun";
                weaponscript.ChooseMachineGun();
            }
        }

        if (weaponhotkey == 3)
        {
            if (weaponscript.shotgunpickedup)
            {
                weapon = "ShotGun";
                weaponscript.ChooseShotGun();
            }
        }

        if (weaponhotkey == 4)
        {
            if (weaponscript.grenadelauncherpickedup)
            {
                weapon = "GrenadeLauncher";
                weaponscript.ChooseGrenadeLauncher();
            }
        }
    }
}
