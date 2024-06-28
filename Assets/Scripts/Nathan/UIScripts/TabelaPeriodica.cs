using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TabelaPeriodica : MonoBehaviour
{
    public GameObject[] imagesToShow;
    public float fadeInSpeed = 0.5f;
    public float fadeOutSpeed = 0.5f;
    public string targetTag;

    private GameObject ultimo = null;
    private bool hovering = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (ultimo != other.gameObject)
            {
                if (ultimo != null)
                {
                    StartCoroutine(FadeOutImages());
                }

                ultimo = other.gameObject;
                hovering = true;
                StartCoroutine(FadeInImages());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (ultimo == other.gameObject)
            {
                StartCoroutine(FadeOutImages());
                ultimo = null;
                hovering = false;
            }
        }
    }

    private IEnumerator FadeInImages()
    {
        foreach (GameObject image in imagesToShow)
        {
            image.SetActive(true);
            CanvasGroup canvasGroup = image.GetComponent<CanvasGroup>();
            float alpha = 0f;

            while (alpha < 1f)
            {
                alpha += Time.deltaTime * fadeInSpeed;
                canvasGroup.alpha = alpha;
                yield return null;
            }
        }
    }

    private IEnumerator FadeOutImages()
    {
        foreach (GameObject image in imagesToShow)
        {
            CanvasGroup canvasGroup = image.GetComponent<CanvasGroup>();
            float alpha = 1f;

            while (alpha > 0f)
            {
                alpha -= Time.deltaTime * fadeOutSpeed;
                canvasGroup.alpha = alpha;
                yield return null;
            }

            image.SetActive(false);
        }
    }

}