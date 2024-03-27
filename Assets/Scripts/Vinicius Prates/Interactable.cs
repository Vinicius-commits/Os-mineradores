using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Interagir()
    {
        return;
    }

    public virtual void Interagir(ref bool segurando, Transform mao)
    {
        segurando = true;
    }
}
