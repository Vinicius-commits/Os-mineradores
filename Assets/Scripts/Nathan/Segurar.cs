using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Segurar : MonoBehaviour
{
    private GameObject objetoSegurado;
    private bool segurando = false;

    public void SegurarObjeto(InputAction.CallbackContext context)
    {
        if (context.started)
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


                        objetoSegurado.transform.SetParent(transform);
                        return;
                    }
                }
            }
            else
            {
                SoltarObjeto();
            }
        }
    }

    public void SoltarObjeto()
    {
        objetoSegurado.transform.SetParent(null);
        segurando = false;
        objetoSegurado = null;
    }
}