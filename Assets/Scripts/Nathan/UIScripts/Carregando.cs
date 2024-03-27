using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carregando : MonoBehaviour
{
    public float fadeDuration = 2f; 
    public GameObject[] spritesToFade; 
    public GameObject panelToFade;
    private void Start()
    {
        StartCoroutine(FadeOutPanel(panelToFade));
        
        foreach (GameObject sprite in spritesToFade)
        {
            StartCoroutine(FadeOutSprite(sprite));
        }
    }

    
    private IEnumerator FadeOutPanel(GameObject panelObject)
    {
        CanvasGroup canvasGroup = panelObject.GetComponent<CanvasGroup>();
        float timer = 0f;

        while (timer < fadeDuration)
        {
            
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

            
            canvasGroup.alpha = alpha;

            
            timer += Time.deltaTime;

            yield return null;
        }

        
        canvasGroup.alpha = 0f;
        panelObject.SetActive(false); 
    }

    
    private IEnumerator FadeOutSprite(GameObject spriteObject)
    {
        SpriteRenderer spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            
            float alpha = Mathf.Lerp(originalColor.a, 0f, timer / fadeDuration);

           
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            
            timer += Time.deltaTime;

            yield return null; 
        }

        
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}