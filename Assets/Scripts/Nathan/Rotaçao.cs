using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaçao : MonoBehaviour
{
    public float velocidade = 100f;

    
    void Update()
    {
         transform.Rotate(0, 0, velocidade * Time.deltaTime);
    }
}
