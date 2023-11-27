using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PausePanel;


    // Update is called once per frame



    private void Start()
    {
        Time.timeScale = 1;
        //PausePanel = GameObject.Find("PausePanel");
        PausePanel.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Pause();
        }


        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Continue();
        }
    }

    public void Pause() 
    { 
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
