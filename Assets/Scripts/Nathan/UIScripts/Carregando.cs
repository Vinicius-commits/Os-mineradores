using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Carregando : MonoBehaviour
{
    public float fadeDuration = 2f; 
    public GameObject[] spritesToFade; 
    public GameObject panelToFadeOut; 
    public GameObject panelToFadeIn; 
    private bool fading = false; 

    void Start()
    {
        StartChangePanel(); // Começa a mudança de painel quando o script é iniciado
    }

    public void StartChangePanel()
    {
        if (!fading)
        {
            StartCoroutine(ChangePanel());
        }
    }

    private IEnumerator ChangePanel()
    {
        fading = true; 

        // Faz o painel antigo desaparecer
        panelToFadeOut.SetActive(true);
        CanvasGroup canvasGroupOut = panelToFadeOut.GetComponent<CanvasGroup>();

        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            canvasGroupOut.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }
        canvasGroupOut.alpha = 0f;
        panelToFadeOut.SetActive(false); 

        // Faz o novo painel aparecer
        panelToFadeIn.SetActive(true);
        CanvasGroup canvasGroupIn = panelToFadeIn.GetComponent<CanvasGroup>();

        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            canvasGroupIn.alpha = alpha;
            timer += Time.deltaTime;
            yield return null;
        }
        canvasGroupIn.alpha = 1f;

        fading = false; 
    }
}