using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDSul : MonoBehaviour
{
    public TextMeshProUGUI FluoritaText;
    public TextMeshProUGUI FerroText;
    public TextMeshProUGUI ManganesText;



    private void Start()
    {
        GameManager.Instance.OnMinerioAtualizado += AtualizarHUD;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnMinerioAtualizado -= AtualizarHUD;
    }

    private void AtualizarHUD(int valor)
    {
        FluoritaText.text = GameManager.Instance.fluorita.ToString();
        FerroText.text = GameManager.Instance.ferro.ToString();
        ManganesText.text = GameManager.Instance.manganes.ToString();


    }
}
