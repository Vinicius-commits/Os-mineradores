using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segurar : MonoBehaviour
{
    private GameObject objetoSegurado;
    private bool segurando = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (segurando)
            {
                SoltarObjeto();
            }
            else
            {
                SegurarObjeto();
            }
        }
    }

    void SegurarObjeto()
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

    void SoltarObjeto()
    {
        
        objetoSegurado.transform.SetParent(null);
        segurando = false;
        objetoSegurado = null;
    }
}