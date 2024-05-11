using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    Vector3 EscalaLocal;
    void Start()
    {
        EscalaLocal = transform.localScale;
    }
    void FixedUpdate()
    {
        EscalaLocal.x = OxigenioPlayer.OxigenioAtual;
        transform.localScale = EscalaLocal;
    }
}
