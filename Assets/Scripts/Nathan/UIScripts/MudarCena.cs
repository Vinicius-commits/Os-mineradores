using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour
{
    
    public string nomeDaCena;

    
    public void TrocarParaCena()
    {
        
        SceneManager.LoadScene(nomeDaCena);
    }
}