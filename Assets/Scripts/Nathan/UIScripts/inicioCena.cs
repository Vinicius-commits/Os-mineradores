using UnityEngine;
using System.Collections;

public class inicioCena : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup; 
    public float fadeDuration = 1f; 

    private void Start()
    {
        if (fadeCanvasGroup != null)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        fadeCanvasGroup.alpha = 1f; 

        
        while (elapsedTime < fadeDuration)
        {
            fadeCanvasGroup.alpha = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        fadeCanvasGroup.alpha = 0f;
        fadeCanvasGroup.gameObject.SetActive(false); 
    }
}