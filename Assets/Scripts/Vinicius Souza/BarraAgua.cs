using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraAgua : MonoBehaviour
{
    Vector3 EscalaLocal;
    void Start()
    {
        EscalaLocal = transform.localScale;
    }
    void FixedUpdate()
    {
        EscalaLocal.x = Agua.AguaAtual;
        transform.localScale = EscalaLocal;
    }
}
