using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NpcMineracao : MonoBehaviour
{
    [SerializeField] private List<string> tagProcurada;
    [SerializeField] public string minerioTag;
    [SerializeField] private GameObject objetoMaisProximo;
    [SerializeField] private Transform minerio;
    [SerializeField] Transform descansoPosition;
    [SerializeField] bool estaDescansando = false;
    [SerializeField] private NavMeshAgent agente;
    [SerializeField] private int aux;

    public void SairDoDescanso()
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
        if(minerio == null)
            EncontrarObjetoMaisProximo();
        // if(objetoMaisProximo != null && objetoMaisProximo.tag == "Minerando")
        //     EncontrarObjetoMaisProximo();
            
    }

    public IEnumerator AtrasarExecucao()
    {
        if(minerio != null)
        {
            yield return new WaitForSeconds(1f); // Atrasa por 1 segundo
            EncontrarObjetoMaisProximo();
        }
    }

    public void EncontrarObjetoMaisProximo()
    {
        
        GameObject[] objetosComTag = GameObject.FindGameObjectsWithTag(minerioTag);
        if(objetosComTag == null)
        {
            if(tagProcurada[aux+1] is not null)
            {
                minerioTag = tagProcurada[aux+1];
                aux++;
                objetosComTag = GameObject.FindGameObjectsWithTag(minerioTag);
            }
            
            else
            {
                minerioTag = tagProcurada[0];
                aux = 0;
                objetosComTag = GameObject.FindGameObjectsWithTag(minerioTag);
            }
        }   
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
        StopCoroutine(AtrasarExecucao());
        minerioTag = tagProcurada.Last();
        estaDescansando = true;
        
    }

    public void MudarTag(int tag)
    {
        aux = tag;
        minerioTag = tagProcurada[tag];
        if(estaDescansando == true)
        {
            SairDoDescanso();
        }
    }
}