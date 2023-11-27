using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScoresScript : MonoBehaviour
{
    public GameObject player;

    public float playermaxheight;
    public float playtime;

    float timescore;
    float maxheightscore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playermaxheight = 0.0f;
        playtime = 0.0f;
        
        timescore = PlayerPrefs.GetFloat("TimeScore");
        Debug.Log("Timescore: " + timescore);

        maxheightscore = PlayerPrefs.GetFloat("MaxHeightScore");
        Debug.Log("MaxHeightScore: " + maxheightscore);
    }

    void Update()
    {
        playtime += 1.0F * Time.deltaTime;

        // records maxheight
        if (player.transform.position.y > playermaxheight) 
        { 
            playermaxheight = player.transform.position.y; 
        }

        if (playermaxheight > maxheightscore) 
        { 
            maxheightscore = playermaxheight; 
            PlayerPrefs.SetFloat("MaxHeightScore", maxheightscore);
            maxheightscore = PlayerPrefs.GetFloat("MaxHeightScore");
            Debug.Log("MaxHeightScore: " + maxheightscore);

        }

        // records timerscore
        if (playtime > timescore) 
        { 
            timescore = playtime;
            PlayerPrefs.SetFloat("TimeScore", timescore);
            timescore = PlayerPrefs.GetFloat("TimeScore");
            Debug.Log("Timescore: " + timescore);
        }
    }
}
