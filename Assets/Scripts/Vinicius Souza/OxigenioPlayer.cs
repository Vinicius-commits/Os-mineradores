using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OxigenioPlayer : MonoBehaviour
{
    [SerializeField] float OxigenioTotal;
    [SerializeField] public static float OxigenioAtual;
    private float Tempo = 0.02f;

    private void Start()
    {
        OxigenioAtual = OxigenioTotal;
    }
    void Update()
    {
        OxigenioAtual -= Tempo * Time.deltaTime;
        if( OxigenioAtual <= 0)
        {
            SceneManager.LoadScene("Fase 2");
        }
    }
}
