using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pegar : Interactable
{
    public override void Interagir(ref bool segurando, Transform mao)
    {
        if(segurando == false)
        {
            segurando = true;
            this.transform.SetParent(mao, true);
        }
        else
        {
            segurando = false;
            this.transform.SetParent(null, true);
        }
    }
}