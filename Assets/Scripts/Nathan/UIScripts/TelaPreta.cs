using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TelaPreta : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f; 
    public string sceneToLoad; 

    
    public void StartFade()
    {
        if (fadeCanvasGroup != null)
        {
            fadeCanvasGroup.gameObject.SetActive(true); 
            StartCoroutine(FadeOutAndSwitchScene());
        }
    }

    private IEnumerator FadeOutAndSwitchScene()
    {
        float elapsedTime = 0f;
        fadeCanvasGroup.alpha = 0f; 

        
        while (elapsedTime < fadeDuration)
        {
            fadeCanvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

       
        fadeCanvasGroup.alpha = 1f;

       
        SceneManager.LoadScene(sceneToLoad);
    }
}