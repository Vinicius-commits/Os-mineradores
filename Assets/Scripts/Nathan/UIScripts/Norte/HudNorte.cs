using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDNorte : MonoBehaviour
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
        ouroText.text = GameManager.Instance.aluminio.ToString();
        ferroText.text = GameManager.Instance.ferro.ToString();
        aluminioText.text = GameManager.Instance.cobre.ToString();
        
    }
}
