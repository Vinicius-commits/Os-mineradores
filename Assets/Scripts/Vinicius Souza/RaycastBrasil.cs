using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RaycastBrasil : MonoBehaviour
{
    [SerializeField] string Tag;
    [SerializeField] string Anim1;
    [SerializeField] string Anim2;
    [SerializeField] string Cena;
    [SerializeField] GameObject[] imagesToShow;
    [SerializeField] float fadeInSpeed = 0.5f;
    [SerializeField] float fadeOutSpeed = 0.5f;
    private GameObject lastObject = null;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(Tag))
            {
                if (lastObject != hit.collider.gameObject)
                {
                    if (lastObject != null)
                    {
                        OnTriggerExit(lastObject.GetComponent<Collider>());
                    }
                    lastObject = hit.collider.gameObject;
                    OnTriggerEnter(lastObject.GetComponent<Collider>());
                }

                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(Cena);
                }
            }
        }
        else
        {
            if (lastObject != null)
            {
                OnTriggerExit(lastObject.GetComponent<Collider>());
                lastObject = null;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider != null && collider.CompareTag(Tag))
        {
            PlayAnimation(collider.gameObject, Anim1);
            StartCoroutine(FadeInImages());
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider != null && collider.CompareTag(Tag))
        {
            PlayAnimation(collider.gameObject, Anim2);
            StartCoroutine(FadeOutImages());
        }
    }

    void PlayAnimation(GameObject obj, string anim)
    {
        Animator objAnimator = obj.GetComponent<Animator>();
        if (objAnimator != null)
        {
            objAnimator.Play(anim);
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

