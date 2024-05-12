using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraLanterna : MonoBehaviour
{
    Vector3 EscalaLocal;
    void Start()
    {
        EscalaLocal = transform.localScale;
    }
    void FixedUpdate()
    {
        EscalaLocal.x = Lanterna.BateriaAtual;
        transform.localScale = EscalaLocal;
    }
}
