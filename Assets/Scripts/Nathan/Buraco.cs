using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buraco : MonoBehaviour
{
    [SerializeField] private string sceneName; 
    [SerializeField] private float pullSpeed = 5f; 
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange)
        {
            
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, -5f);
            GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(GameObject.FindGameObjectWithTag("Player").transform.position, newPos, Time.deltaTime * pullSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            ChangeScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void ChangeScene()
    {
        
        SceneManager.LoadScene(sceneName);
    }
}