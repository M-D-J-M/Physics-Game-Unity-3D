using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gun;
    public Camera cam;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI GunHotKeyText;

    float spinspeed, jumpforce, drag, zoomdistance, grapple, mass, jumptime, ammo;
    bool grounded, isGrappling, isJumping;
    float playtime = 0;
    Vector3 velocity;
    string surface, target, weapon;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gun = GameObject.FindGameObjectWithTag("GunObject");
        cam = Camera.main;
        playtime = 0.0f;
    }

    void Update()
    {
        spinspeed = player.GetComponent<PlayerMovement>().spinspeed;
        grounded = player.GetComponent<PlayerMovement>().grounded;
        playtime += 1.0F * Time.deltaTime;
        velocity = player.GetComponent<Rigidbody>().velocity;
        surface = player.GetComponent<PlayerMovement>().surface;
        jumpforce = player.GetComponent<PlayerMovement>().jumpforce;
        jumptime = player.GetComponent<PlayerMovement>().jumpTime;
        isJumping = player.GetComponent<PlayerMovement>().isJumping;
        drag = player.GetComponent<Rigidbody>().drag;
        zoomdistance = -cam.transform.localPosition.z;
        target = player.GetComponent<PlayerShoot>().targetinfo;
        weapon = player.GetComponent<PlayerShoot>().weapon;

        grapple = gun.GetComponent<GrappleGun>().CurrentGrapple;
        isGrappling = gun.GetComponent<GrappleGun>().isGrappling;
        mass = player.GetComponent<Rigidbody>().mass;
        ammo = player.GetComponent<PlayerShoot>().ammo;
        Textinfo();
    }

    void Textinfo()
    {
        Text.text =
            "Spinspeed: " + spinspeed + "\n" +
            "Grounded: " + grounded + "\n" +
            "Playtime: " + playtime + "\n" +
            "Velocity: " + velocity + "\n" +
            "Surface: " + surface + "\n" +
            "JumpForce: " + jumpforce + "\n" +
            "isJumping: " + isJumping + "\n" +
            "Jump Time: " + jumptime + "\n" +
            "Drag: " + drag + "\n" +
            "Zoom Distance: " + zoomdistance + "\n" +
            "Weapon: " + weapon + "\n" +
            "Grapple: " + grapple + "\n" +
            "isGrappling: " + isGrappling + "\n" +
            "Mass: " + mass + "\n" +
            "Target: " + target;

        AmmoText.text = "Ammo: " + ammo;
        if (ammo == 0) { AmmoText.text = " "; }

        float playtimerounded = Mathf.Round(playtime * 100f) / 100f;
        Timer.text = "" + playtimerounded;

        if (weapon == "Pistol") GunHotKeyText.text = "1";
        if (weapon == "MachineGun") GunHotKeyText.text = "2";
        if (weapon == "ShotGun") GunHotKeyText.text = "3";
        if (weapon == "GrenadeLauncher") GunHotKeyText.text = "4";
    }
}
    
