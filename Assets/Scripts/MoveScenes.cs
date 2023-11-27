using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class MoveScenes : MonoBehaviour
{
    [SerializeField] private string newLevel;
    public float playtime;
    float timescore;


    private void Start()
    {
        playtime = 0.0f;
        timescore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().name + "Time: "+ PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name));
    }

    private void Update()
    {
        playtime += 1.0F * Time.deltaTime;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AdjustTimeScore();
            SceneManager.LoadScene(newLevel);
        }
    }

    void AdjustTimeScore()
    {
        if (timescore == 0.0f)
        {
            timescore = playtime;
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, timescore);

            //timescore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
            Debug.Log(SceneManager.GetActiveScene().name + "Time: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name));
        }
        if (playtime < timescore) 
        {
            timescore = playtime;
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, timescore);

            //timescore = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
            Debug.Log(SceneManager.GetActiveScene().name + "Time: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name));
        }
    }
}
