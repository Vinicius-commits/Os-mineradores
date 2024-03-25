using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pegar : MonoBehaviour, IInteractable
{
    private GameObject objetoSegurado;
    private bool segurando = false;
    [SerializeField] Transform mao;

    public void Interagir()
    {
        SegurarObjeto();
    }

    public void SegurarObjeto()
    {
        if (!segurando)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Pedra"))
                {
                    objetoSegurado = collider.gameObject;
                    segurando = true;

                    objetoSegurado.transform.SetParent(mao, false);
                    return;
                }
            }
        }

        else
        {
            SoltarObjeto();
        }
    }

    public void SoltarObjeto()
    {
        objetoSegurado.transform.SetParent(null);
        segurando = false;
        objetoSegurado = null;
    }
}