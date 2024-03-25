using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    public void MudandoCena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SairDaAplicacao()
    {
        Application.Quit();
    }
}