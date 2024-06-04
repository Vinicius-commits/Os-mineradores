using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDSul : MonoBehaviour
{
    public TextMeshProUGUI ouroText;
    
    

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
        ouroText.text = GameManager.Instance.fluorita.ToString();
        ;
        
    }
}
