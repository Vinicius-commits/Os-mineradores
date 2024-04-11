using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Vector3 destino;
    [SerializeField] GameObject pedidos;

    public Vector3 Destino
    {
        get { return destino; }
    }

    #region SetDestino
    public void SetDestino(Transform novoDestino)
    {
        destino = novoDestino.position;
    }

    public void SetDestino(Vector3 novoDestino)
    {
        destino = novoDestino;
    }
    #endregion

    public void InteragirPedidos()
    {
        pedidos.SetActive(pedidos.activeSelf);
    }

    
}
