using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;

    public void Start()
    {
        GameManager._instance._uiController = this;
    }

    public void Pause()
    {
        if (Time.timeScale > 0)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0.0f;
    }

    public void UpdateCoin(int quantidade)
    {
        txt.text = quantidade.ToString();
    }
}
