using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MusicBoxScript : MonoBehaviour
{
    public static MusicBoxScript Instance;

        void Awake()
        {
            if (Instance != null) 
            {
                Destroy(gameObject);
            } 

            else   
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

        }

}
