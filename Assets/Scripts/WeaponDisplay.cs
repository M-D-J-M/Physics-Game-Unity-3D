using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public RawImage grapplinghook;
    public RawImage pistol;
    public RawImage machinegun;
    public RawImage shotgun;
    public RawImage grenadelauncher;

    public bool grapplinghookpickedup = false;
    public bool pistolpickedup = false;
    public bool machinegunpickedup = false;
    public bool shotgunpickedup = false;
    public bool grenadelauncherpickedup = false;


    void Start()
    {
        grapplinghook.enabled = false;
        pistol.enabled = false;
        machinegun.enabled = false;
        shotgun.enabled = false;
        grenadelauncher.enabled = false;
    }

    public void ShowGrapplingHook() 
    {
        grapplinghook.enabled = true;
    }

    public void ShowPistol()
    {
        pistol.enabled = true;
        
    }

    public void ShowMachineGun()
    {
        machinegun.enabled = true;
    }

    public void ShowShotGun()
    {
        shotgun.enabled = true;
    }

    public void ShowGrenadeLauncher()
    {
        grenadelauncher.enabled = true;
    }



    public void ChoosePistol()
    {
        pistol.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 1f);
        machinegun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        shotgun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        grenadelauncher.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
    }

    public void ChooseMachineGun()
    {
        pistol.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        machinegun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 1f);
        shotgun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        grenadelauncher.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
    }

    public void ChooseShotGun()
    {
        pistol.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        machinegun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        shotgun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 1f);
        grenadelauncher.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
    }

    public void ChooseGrenadeLauncher()
    {
        pistol.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        machinegun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        shotgun.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 0.0f);
        grenadelauncher.color = new Color(pistol.color.r, pistol.color.g, pistol.color.b, 1f);
    }
}
