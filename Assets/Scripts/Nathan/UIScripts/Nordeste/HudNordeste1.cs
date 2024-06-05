using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDNordeste1 : MonoBehaviour
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
        ouroText.text = GameManager.Instance.gipsita.ToString();
        ferroText.text = GameManager.Instance.turmalina.ToString();
        aluminioText.text = GameManager.Instance.tungstenio.ToString();
        
    }
}
