using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevador : MonoBehaviour
{
    [SerializeField] private Vector3 Posicao;
    [SerializeField] private string cena;
    [SerializeField] private bool estaDentro;
    [SerializeField] private KeyCode teclaTP = KeyCode.F;
    [SerializeField]
    private void Start()
    {
    }

    public void TrocarDeCena()
    {
        SceneManager.LoadScene(cena);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaDentro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaDentro = false;
        }
    }
}
