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
    [SerializeField] Animator animator;
    [SerializeField] GameObject[] imagesToShow;
    [SerializeField] float fadeInSpeed = 0.5f;
    [SerializeField] float fadeOutSpeed = 0.5f;
    private GameObject currentObject = null;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(Tag))
            {
                if (currentObject != hit.collider.gameObject)
                {
                    OnCollisionExit(currentObject);
                    currentObject = hit.collider.gameObject;
                    OnCollisionEnter(currentObject);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(Cena);
                }
            }
        }
        else
        {
            OnCollisionExit(currentObject);
            currentObject = null;
        }
    }

    void OnCollisionEnter(GameObject obj)
    {
        if (obj != null)
        {
            Animacao(Anim1);
            StartCoroutine(FadeInImages());
        }
    }

    void OnCollisionExit(GameObject obj)
    {
        if (obj != null)
        {
            Animacao(Anim2);
            StartCoroutine(FadeOutImages());
        }
    }

    void Animacao(string anim)
    {
        if (animator != null)
        {
            animator.Play(anim);
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

