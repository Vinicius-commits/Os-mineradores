using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarMinerio : Interactable
{
    [SerializeField] private float timer;
    [SerializeField] private float timernpc;
    [SerializeField] private int contador;
    [SerializeField] private bool minerando;
    [SerializeField] private bool ouro, ferro, aluminio, niobio;
    [SerializeField] private GameObject pedra;
    public bool npc = false;
    [SerializeField] private Transform pai;
    [SerializeField] private GameObject paiObj;
    [SerializeField] private GameObject npcObj;
    [SerializeField] private float distancia = 0;
    [SerializeField] private string tagAntes;
    

    void Start()
    {
        pai = transform.parent;
        paiObj = pai.gameObject;
    }

    public void Update()
    {
        // Cria uma esfera de detecção centrada na posição do objeto atual e com o raio especificado NPC
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.0f);

        // Itera sobre todos os colliders encontrados NPC
        foreach (Collider collider in colliders)
        {
            // Verifica se o collider pertence à tag desejada NPC
            if (collider.CompareTag("NPC"))
            {
                npcObj = collider.gameObject;
                
                Invoke("Mineracao", 2f);
                npc = true;

            }
            if(npcObj != npcObj)
            distancia = Vector3.Distance(npcObj.transform.position, transform.position);
            if(distancia > 3)
            {
                CancelInvoke("Quebrar");
                npc = false;
                this.gameObject.tag = tagAntes;
            }
             
        }
        
    }

    public override void Interagir()
    {
        Mineracao();
    }

    public void Mineracao()
    {
        if (!minerando)
        {
            tagAntes = transform.parent.gameObject.tag;
            transform.parent.gameObject.tag = "Minerando";
            minerando = true;
            if (npc)
            {   
                distancia = Vector3.Distance(npcObj.transform.position, transform.position);
                Debug.Log("" + distancia);
                if(distancia < 2)
                Invoke("Quebrar", timernpc);
            }

            else
                Invoke("Quebrar", timer);
        }
    }

    public void Quebrar()
    {
        if (ouro)
        {
            GameManager.Instance.AtualizarOuro(1);
            if (GameManager.Instance.ouro == 12)
                SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Ouro);
        }
        else if (ferro)
        {
            GameManager.Instance.AtualizarFerro(1);
            if (GameManager.Instance.ferro == 12)
                SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Ferro);
        }
        else if (aluminio)
        {
            GameManager.Instance.AtualizarAluminio(1);
            if (GameManager.Instance.aluminio == 12)
                SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Aluminio);
        }
        else if (niobio)
        {
            GameManager.Instance.AtualizarNiobio(1);
            if (GameManager.Instance.niobio == 12)
                SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Niobio);
        }

        contador++;
        Debug.LogError(contador);
        minerando = false;
        if (contador >= 3)
        {
            if (pedra != null)
            {
                paiObj.tag = "SemMinerio";
                pedra.SetActive(true);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogError("Pedra não definida para " + this.gameObject.name);
            }
        }
        else
        {
            if (!minerando)
            {
                Mineracao();
            }
        }
    }
}