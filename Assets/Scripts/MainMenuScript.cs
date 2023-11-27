using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI timescoreIS;

    public TextMeshProUGUI timescore1;
    public TextMeshProUGUI timescore2;
    public TextMeshProUGUI timescore3;
    public TextMeshProUGUI timescore4;
    public TextMeshProUGUI timescore5;
    public TextMeshProUGUI timescore6;
    public TextMeshProUGUI timescore7;
    public TextMeshProUGUI timescore8;
    public TextMeshProUGUI timescore9;
    public TextMeshProUGUI timescore10;
    public TextMeshProUGUI timescore11;
    public TextMeshProUGUI timescore12;
    public TextMeshProUGUI timescore13;


    void Start()
    {

        Cursor.lockState = CursorLockMode.Confined;

        timescoreIS.text = "Island Survival" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("TimeScore") * 100f) / 100f; 

        timescore1.text = "1" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level1") * 100f) / 100f; 
        timescore2.text = "2" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level2") * 100f) / 100f; 
        timescore3.text = "3" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level3") * 100f) / 100f; 
        timescore4.text = "4" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level4") * 100f) / 100f; 
        timescore5.text = "5" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level5") * 100f) / 100f; 
        timescore6.text = "6" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level6") * 100f) / 100f; 
        timescore7.text = "7" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level7") * 100f) / 100f; 
        timescore8.text = "8" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level8") * 100f) / 100f; 
        timescore9.text = "9" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level9") * 100f) / 100f; 
        timescore10.text = "10" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level10") * 100f) / 100f;
        timescore11.text = "11" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level11") * 100f) / 100f;
        timescore12.text = "12" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level12") * 100f) / 100f;
        timescore13.text = "13" + "\n" + "Time: " + Mathf.Round(PlayerPrefs.GetFloat("Level13") * 100f) / 100f;
    }

    void PrintTimeScores() 
    { 
        
    }
}
