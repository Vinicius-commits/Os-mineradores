using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDNordeste : MonoBehaviour
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
        ouroText.text = GameManager.Instance.opala.ToString();
        ferroText.text = GameManager.Instance.magnesita.ToString();
        aluminioText.text = GameManager.Instance.uranio.ToString();
        
    }
}
