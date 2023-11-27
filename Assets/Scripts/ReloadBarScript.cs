using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBarScript : MonoBehaviour
{
    public float MaxReload;
    public float CurrentReload;
    public Image Reload_Bar;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        MaxReload = 3.0f;
        Reload_Bar = GetComponent<Image>();
        CurrentReload = player.GetComponent<PlayerShoot>().fireratetimer;
    }

    void Update()
    {

        if (player.GetComponent<PlayerShoot>().weapon == "Pistol") { MaxReload = 1f; }
        if (player.GetComponent<PlayerShoot>().weapon == "ShotGun") { MaxReload = 1.5f; }
        if (player.GetComponent<PlayerShoot>().weapon == "MachineGun") { MaxReload = 0.3f; }
        if (player.GetComponent<PlayerShoot>().weapon == "GrenadeLauncher") { MaxReload = 3f; }

        CurrentReload = player.GetComponent<PlayerShoot>().fireratetimer;
        Reload_Bar.fillAmount = CurrentReload / MaxReload;
    }
}
