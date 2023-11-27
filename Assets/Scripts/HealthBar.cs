using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    private Image Health_Bar;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        MaxHealth = player.GetComponent<PlayerHealth>().MaxHealth;
        Health_Bar = GetComponent<Image>();
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        CurrentHealth = player.GetComponent<PlayerHealth>().CurrentHealth;
        Health_Bar.fillAmount = CurrentHealth / MaxHealth;
    }
}
