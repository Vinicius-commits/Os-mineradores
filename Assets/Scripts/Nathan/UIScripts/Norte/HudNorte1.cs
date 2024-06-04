using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDNorte1 : MonoBehaviour
{
    public TextMeshProUGUI ouroText;
    public TextMeshProUGUI ferroText;
    
    

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
        ouroText.text = GameManager.Instance.cobre.ToString();
        ferroText.text = GameManager.Instance.manganes.ToString();
        
        
    }
}
