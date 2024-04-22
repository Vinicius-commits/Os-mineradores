using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarPainelElevador : Interactable
{
    [SerializeField] GameObject painelElevador;

    public override void Interagir()
    {
        painelElevador.SetActive(!painelElevador.activeSelf);
        if(!painelElevador.activeSelf) 
        {
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;   
        } else
        {
            // Cursor.visible = true;
            // Cursor.lockState = CursorLockMode.None;
        }
    }
}
