using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDNordeste2 : MonoBehaviour
{
    public TextMeshProUGUI ouroText;
    public TextMeshProUGUI ferroText;
    public TextMeshProUGUI aluminioText;
    public TextMeshProUGUI uranioText;
    

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
        ferroText.text = GameManager.Instance.turmalina.ToString();
        aluminioText.text = GameManager.Instance.opala.ToString();
        uranioText.text = GameManager.Instance.uranio.ToString();
        
    }
}
