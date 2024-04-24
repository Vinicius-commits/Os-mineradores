using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    public GameObject canvasPauseMenu; 
    private bool isPaused = false; 

    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
        canvasPauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Time.timeScale = 1f;
                canvasPauseMenu.SetActive(false);
                isPaused = false; 
            }

            else 
            {
                Time.timeScale = 0f; 
                canvasPauseMenu.SetActive(true); 
                isPaused = true; 
            }
        }
    }

    public void OnPause()
    {

    }
}
