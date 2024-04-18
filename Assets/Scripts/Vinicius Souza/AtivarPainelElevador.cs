using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarPainelElevador : MonoBehaviour
{
    [SerializeField] GameObject painelElevador;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            painelElevador.SetActive(true);
        }
        else
            painelElevador.SetActive(false);
    }
}
