using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarPainelElevador : Interactable
{
    [SerializeField] GameObject painelElevador;

    public override void Interagir()
    {
        painelElevador.SetActive(!painelElevador.activeSelf);
        Cursor.visible = !Cursor.visible;
        if(Cursor.lockState == CursorLockMode.None) 
        {
            Cursor.lockState = CursorLockMode.Locked;   
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
