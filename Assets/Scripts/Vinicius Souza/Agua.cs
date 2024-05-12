using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Agua : MonoBehaviour
{
    [SerializeField] float AguaTotal;
    [SerializeField] public static float AguaAtual;
    private float Tempo = 0.009f;
    [SerializeField] float cooldown;
    private float BeberAgua;

    private void Start()
    {
        AguaAtual = AguaTotal;
    }
    void FixedUpdate()
    {
        AguaAtual -= Tempo * Time.deltaTime;
        if (AguaAtual <= 0)
        {
            SceneManager.LoadScene("Norte3");
        }
        if (Input.GetKeyDown(KeyCode.R) && Time.time > BeberAgua + cooldown)
        {
            Recarregar();
        }
    }
    void Recarregar()
    {
        AguaAtual = 1f;
    }
}
