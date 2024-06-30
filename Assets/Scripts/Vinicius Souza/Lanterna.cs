using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Lanterna : MonoBehaviour
{
    [SerializeField] float BateriaTotal;
    public float BateriaAtual;
    private float Tempo = 0.007f;
    GameManager gameManager;
    [SerializeField] GameObject lanterna;
    [SerializeField] Light luz;

    private void Start()
    {
        BateriaAtual = BateriaTotal;
        luz = GetComponentInChildren<Light>();
    }
    void FixedUpdate()
    {
        BateriaAtual -= Tempo * Time.deltaTime;
        if (BateriaAtual <= 0)
        {
            Tempo = 0f;
            if (luz.intensity > 0)
            {
                StartCoroutine(DiminuirIntensidadeGradualmente(6f));
            }

            if (luz.intensity <= 0)
            {
                lanterna.SetActive(false);
            }
        }
        else
        {
            lanterna.SetActive(true);
        }
        // if(BateriaAtual <= 0.5 && Input.GetKeyDown(KeyCode.R))
        // {
        //     Debug.Log("Recarregou");
        //     Recarregar();
        // }
        
    }

    public void Recarregar(InputAction.CallbackContext context)
    {
        if((context.started || context.performed) && BateriaAtual <= 0.5)
        {
            Debug.Log("Entrada no recarregar da lanterna");
            if(gameManager.manganes >= 1)
            {
                BateriaAtual = 1;
                gameManager.manganes -= 1;
            }
        }
    }
    IEnumerator DiminuirIntensidadeGradualmente(float duracao)
    {
        float intensidadeInicial = luz.intensity;
        float tempoPassado = 0f;

        while (tempoPassado < duracao)
        {
            luz.intensity = Mathf.Lerp(intensidadeInicial, 0, tempoPassado / duracao);
            tempoPassado += Time.deltaTime;
            yield return null;
        }

        luz.intensity = 0;
    }
}
