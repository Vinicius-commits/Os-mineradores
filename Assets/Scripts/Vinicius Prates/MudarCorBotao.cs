using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudarCorBotao : MonoBehaviour
{
    [SerializeField] Image _sprite;
    [SerializeField] Color _normalColor;
    [SerializeField] Color _changeColor;

    private void Awake() {
        _sprite = GetComponent<Image>();
        _normalColor = _sprite.color;    
    }

    public void AtivarMudarCor()
    {
        _sprite.color = _changeColor;
    }

    public void DesativarMudarCor()
    {
        _sprite.color = _normalColor;
    }

}
