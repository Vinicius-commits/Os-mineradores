using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class MuseuHud : MonoBehaviour
{
    public GameObject panelToShow; 
    public float fadeInSpeed = 0.5f;
    public float fadeOutSpeed = 0.5f; 

    private bool playerInRange = false; 
    private bool panelActive = false; 

    void Update()
    {
       
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
           
            if (!panelActive)
            {
                ActivatePanel();
            }
           
            else
            {
                DeactivatePanel();
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
           
            DeactivatePanel();
        }
    }

    
    private void ActivatePanel()
    {
        panelToShow.SetActive(true);
        StartCoroutine(FadeInPanel());
        panelActive = true;
    }

    
    private void DeactivatePanel()
    {
        StartCoroutine(FadeOutPanel());
        panelActive = false;
    }

    
    private IEnumerator FadeInPanel()
    {
        CanvasGroup canvasGroup = panelToShow.GetComponent<CanvasGroup>();
        float alpha = 0f;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeInSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }
    }

    
    private IEnumerator FadeOutPanel()
    {
        CanvasGroup canvasGroup = panelToShow.GetComponent<CanvasGroup>();
        float alpha = 1f;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeOutSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }

        panelToShow.SetActive(false);
    }
}
