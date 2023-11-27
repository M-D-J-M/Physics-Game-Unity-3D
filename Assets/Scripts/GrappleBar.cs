using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrappleBar : MonoBehaviour
{
    public float MaxGrapple ;
    public float CurrentGrapple;
    private Image Grapple_Bar;
    public GameObject gun;

    void Start()
    {
        gun = GameObject.Find("Gun");
        MaxGrapple = gun.GetComponent<GrappleGun>().MaxGrapple;
        CurrentGrapple = MaxGrapple;
        Grapple_Bar = GetComponent<Image>();
    }

    void Update()
    {
        CurrentGrapple = gun.GetComponent<GrappleGun>().CurrentGrapple;
        Grapple_Bar.fillAmount = CurrentGrapple / MaxGrapple;
    }
}
