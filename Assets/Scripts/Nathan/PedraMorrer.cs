using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PedraMorrer : MonoBehaviour
{
    public string nomeDaCena; 

    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Pedra"))
        {
            
            SceneManager.LoadScene(nomeDaCena);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("Pedra"))
        {
           
            SceneManager.LoadScene(nomeDaCena);
        }
    }
}