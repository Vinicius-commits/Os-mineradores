using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCInteraction : MonoBehaviour
{
    public GameObject panel;
    public float fadeInSpeed = 0.5f;
    public float fadeOutSpeed = 0.5f;

    private bool playerInRange = false;
    private bool panelActive = false;

    public bool IsPanelActive
    {
        get => panelActive;
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerInRange = true;
    //     }
    // }

    // private void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerInRange = false;
    //         DeactivatePanel();
    //     }
    // }

    // private void Update()
    // {
    //     if (playerInRange && Input.GetKeyDown(KeyCode.E))
    //     {
    //         if (!panelActive)
    //         {
    //             ActivatePanel();
    //         }
    //         else
    //         {
    //             DeactivatePanel();
    //         }
    //     }
    // }

    public void ActivatePanel()
    {
        panel.SetActive(true);
        StartCoroutine(FadeInPanel());
        panelActive = true;
    }

    public void DeactivatePanel()
    {
        StartCoroutine(FadeOutPanel());
        panelActive = false;
    }

    private IEnumerator FadeInPanel()
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
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
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
        float alpha = 1f;

        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * fadeOutSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }

        panel.SetActive(false);
    }
}