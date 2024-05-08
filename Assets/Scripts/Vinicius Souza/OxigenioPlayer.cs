using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OxigenioPlayer : MonoBehaviour
{
    [SerializeField] float OxigenioTotal;
    [SerializeField] float OxigenioAtual;
    [SerializeField] float Tempo;

    public float oxigenioatual
    {
        get { return OxigenioAtual; }
        set {  OxigenioAtual = value; }
    }
    private void Start()
    {
        OxigenioAtual = OxigenioTotal;
    }
    void Update()
    {
        OxigenioAtual -= Tempo * Time.deltaTime;
        if (OxigenioAtual <= 0) 
        {
            SceneManager.LoadScene("Fase1");
        }
    }
}
