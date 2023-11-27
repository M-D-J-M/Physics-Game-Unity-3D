using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    // AUDIO 
    public AudioClip pickup;
    AudioSource audioSource;

    // WEAPONS

    public GameObject WeaponDisplay;
    public WeaponDisplay weaponscript;

    public GameObject player;
    public PlayerShoot playershoot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        WeaponDisplay = GameObject.Find("WeaponDisplay");
        weaponscript = (WeaponDisplay)WeaponDisplay.GetComponent(typeof(WeaponDisplay));

        player = GameObject.Find("Player");
        playershoot = (PlayerShoot)player.GetComponent(typeof(PlayerShoot));
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == ("GrapplingHook"))
        {
            weaponscript.ShowGrapplingHook();
            audioSource.PlayOneShot(pickup, 0.7F);
            weaponscript.grapplinghookpickedup = true;
        }

        if (other.gameObject.tag == ("Pistol"))
        {
            weaponscript.ShowPistol();
            weaponscript.ChoosePistol();
            audioSource.PlayOneShot(pickup, 0.7F);
            weaponscript.pistolpickedup = true;
            playershoot.weapon = "Pistol";
            playershoot.pistolammo += 30;
        }

        if (other.gameObject.tag == ("MachineGun"))
        {
            weaponscript.ShowMachineGun();
            weaponscript.ChooseMachineGun();
            audioSource.PlayOneShot(pickup, 0.7F);
            weaponscript.machinegunpickedup = true;
            playershoot.weapon = "MachineGun";
            playershoot.machinegunammo += 50;
        }

        if (other.gameObject.tag == ("ShotGun"))
        {
            weaponscript.ShowShotGun();
            weaponscript.ChooseShotGun();
            audioSource.PlayOneShot(pickup, 0.7F);
            weaponscript.shotgunpickedup = true;
            playershoot.weapon = "ShotGun";
            playershoot.shotgunammo += 10;
        }

        if (other.gameObject.tag == ("GrenadeLauncher"))
        {
            weaponscript.ShowGrenadeLauncher();
            weaponscript.ChooseGrenadeLauncher();
            audioSource.PlayOneShot(pickup, 0.7F);
            weaponscript.grenadelauncherpickedup = true;
            playershoot.weapon = "GrenadeLauncher";
            playershoot.grenadeammo += 5;
        }

        else
        {
            // do nothing
        }
    }




}
