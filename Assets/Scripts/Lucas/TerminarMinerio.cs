using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarMinerio : Interactable
{
    [SerializeField] private float timer;
    [SerializeField] private int contador;
    [SerializeField] private bool minerando;
    [SerializeField] private bool ouro , ferro , aluminio , niobio;

    public override void Interagir()
    {
        Mineracao();
    }

    public void Mineracao()
    {
        if(!minerando)
        {
            //Verifica se o player ta perto do minerio
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (Collider collider in colliders)
            {
                //nessa parte eu vou colocar uma barra de UI para mostrar o tempo passando
                if (collider.CompareTag("Player"))
                {
                    minerando = true;
                    Invoke("Quebrar", timer);
                }
            }
        }
    }

    public void Quebrar() //verifica se ele ja foi minerado 3 vezes caso sim ele quebra de deixa a pedra sem minerio
    {
        if(ouro)
        GameManager.Instance.ouro++;
        else if(ferro)
        GameManager.Instance.ferro++;
        else if(aluminio)
        GameManager.Instance.aluminio++;
        else if(niobio)
        GameManager.Instance.niobio++;
        
        contador++;
        minerando = false;
        if(contador >= 3)
            Destroy(this.gameObject);
    }
}
