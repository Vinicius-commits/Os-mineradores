using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
    [SerializeField] private string[] tagsProcuradas;
    [SerializeField] private GameObject objetoMaisProximo;
    [SerializeField] private NavMeshAgent[] agentes;
    void Start()
    {
        StartCoroutine(AtrasarExecucao());



    }
    public IEnumerator AtrasarExecucao()
    {

        yield return new WaitForSeconds(1f); // Atrasa por 1 segundo
        EncontrarObjetoMaisProximo(0, 0);
    }

    public void EncontrarObjetoMaisProximo(int tag, int agente)
    {

        GameObject[] objetosComTag = GameObject.FindGameObjectsWithTag(tagsProcuradas[tag]);
        float menorDistancia = Mathf.Infinity;
        Vector3 posicaoAtual = transform.position;

        foreach (GameObject objeto in objetosComTag)
        {
            float distancia = Vector3.Distance(agentes[agente].transform.position, posicaoAtual);
            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                objetoMaisProximo = objeto;
            }
        }

        IrPara();
    }



    void IrPara()
    {
        Vector3 Somar = new Vector3(1, 0, 1);
        Vector3 irPara = objetoMaisProximo.transform.position + Somar;
        agentes[0].SetDestination(irPara);
    }
}
