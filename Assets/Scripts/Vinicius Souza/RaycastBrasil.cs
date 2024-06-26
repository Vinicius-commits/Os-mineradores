using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastBrasil : MonoBehaviour
{
    [SerializeField] string Tag;
    [SerializeField] string Anim1;
    [SerializeField] string Anim2;
    [SerializeField] string Cena;
    [SerializeField] Animator animator;
    private bool MouseEmCima = false;
    private GameObject Ultimo = null;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag(Tag))
            {
                if (Ultimo != hit.collider.gameObject)
                {
                    if (Ultimo != null)
                    {
                        Animacao(Anim2);
                    }

                    Ultimo = hit.collider.gameObject;
                    Animacao(Anim1);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(Cena);
                }
            }
        }
        else if (Ultimo != null)
        {
            Animacao(Anim2);
            Ultimo = null;
        }
    }

    void Animacao(string a)
    {
        if (animator != null)
        {
            animator.Play(a);
        }
    }

    void OnMouseEnter()
    {
        MouseEmCima = true;
        Animacao(Anim1);
    }

    void OnMouseExit()
    {
        MouseEmCima = false;
        Animacao(Anim2);
    }
}
