using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDManager3 : MonoBehaviour
{
    public TextMeshProUGUI ouroText;
    public TextMeshProUGUI ferroText;
    public TextMeshProUGUI aluminioText;
    

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
        ouroText.text = GameManager.Instance.ouro.ToString();
        ferroText.text = GameManager.Instance.zinco.ToString();
        aluminioText.text = GameManager.Instance.grafita.ToString();
        
    }
}
