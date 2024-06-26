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

    private bool hovering = false;
    private GameObject Ultimo = null;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                if (Ultimo != hit.collider.gameObject)
                {
                    if (Ultimo != null)
                    {
                        StartCoroutine(FadeOutImages());
                    }

                    Ultimo = hit.collider.gameObject;
                    hovering = true;
                    StartCoroutine(FadeInImages());
                }
            }
        }
        else if (Ultimo != null)
        {
            StartCoroutine(FadeOutImages());
            Ultimo = null;
            hovering = false;
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