using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMineracao : MonoBehaviour
{
    [SerializeField] private string tagProcurada;
    [SerializeField] private GameObject objetoMaisProximo;
    [SerializeField] private Transform minerio;
    [SerializeField] Transform descansoPosition;
    [SerializeField] bool estaDescansando = false;
    [SerializeField] private NavMeshAgent agente;

    public void SairDoDesacanso()
    {
        estaDescansando = false;
        StartCoroutine(AtrasarExecucao());
    }

    void Start()
    {
        StartCoroutine(AtrasarExecucao());
    }

    void FixedUpdate()
    {
        if(minerio == null && !estaDescansando)
            EncontrarObjetoMaisProximo();
    }

    public IEnumerator AtrasarExecucao()
    {
        yield return new WaitForSeconds(1f); // Atrasa por 1 segundo
        EncontrarObjetoMaisProximo();
    }

    public void EncontrarObjetoMaisProximo()
    {
        GameObject[] objetosComTag = GameObject.FindGameObjectsWithTag(tagProcurada);
        float menorDistancia = Mathf.Infinity;
        Vector3 posicaoAtual = transform.position;

        foreach (GameObject objeto in objetosComTag)
        {
            float distancia = Vector3.Distance(agente.transform.position, posicaoAtual);
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
        minerio = objetoMaisProximo.transform.GetChild(0);
        Vector3 Somar = new Vector3(1, 0, 1);
        Vector3 irPara = objetoMaisProximo.transform.position + Somar;
        agente.SetDestination(irPara);
    }

    public void Descansar()
    {
        estaDescansando = true;
        agente.SetDestination(descansoPosition.position);
        StopCoroutine(AtrasarExecucao());
        minerio = null;
    }

    public void MudarTag(string tag)
    {
        tagProcurada = tag;
        if(estaDescansando == true)
        {
            SairDoDesacanso();
        }
    }
}