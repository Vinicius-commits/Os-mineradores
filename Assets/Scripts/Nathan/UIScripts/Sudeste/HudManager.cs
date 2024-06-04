using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI ouroText;
    public TextMeshProUGUI ferroText;
    public TextMeshProUGUI aluminioText;
    public TextMeshProUGUI niobioText;

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
        ouroText.text = GameManager.Instance.grafita.ToString();
        ferroText.text = GameManager.Instance.ferro.ToString();
        aluminioText.text = GameManager.Instance.manganes.ToString();
        niobioText.text = GameManager.Instance.niobio.ToString();
    }
}
