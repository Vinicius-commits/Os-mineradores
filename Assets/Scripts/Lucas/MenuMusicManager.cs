using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicManager : MonoBehaviour
{
    [SerializeField] private bool menu;

    private static MenuMusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Creditos" || SceneManager.GetActiveScene().name == "Configurations" || SceneManager.GetActiveScene().name == "MapaBrasil")
        {
            menu = true;
        }
        else
        {
            Destroy(gameObject);
        }
        

    }
}
