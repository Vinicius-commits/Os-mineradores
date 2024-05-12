using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lanterna : MonoBehaviour
{
    [SerializeField] float BateriaTotal;
    [SerializeField] public static float BateriaAtual;
    private float Tempo = 0.01f;
    private GameManager gameManager;
    [SerializeField] GameObject lanterna;

    private void Start()
    {
        BateriaAtual = BateriaTotal;
    }
    void FixedUpdate()
    {
        BateriaAtual -= Tempo * Time.deltaTime;
        if (BateriaAtual <= 0)
        {
            lanterna.SetActive(false);
            Tempo = 0f;
        }
        else
        {
            lanterna.SetActive(true);
        }
        if(BateriaAtual <= 0.5 && Input.GetKeyDown(KeyCode.R))
        {
            Recarregar();
        }
    }

    void Recarregar()
    {
        gameManager.grafita -= 1;
        gameManager.AtualizarGrafita(-1);
        BateriaAtual = 1;
    }
}
