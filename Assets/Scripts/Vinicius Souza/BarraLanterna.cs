using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraLanterna : MonoBehaviour
{
    Vector3 EscalaLocal;
    [SerializeField] Lanterna lanterna;
    void Start()
    {
        EscalaLocal = transform.localScale;
    }
    void FixedUpdate()
    {
        EscalaLocal.x = lanterna.BateriaAtual;
        transform.localScale = EscalaLocal;
    }
}
