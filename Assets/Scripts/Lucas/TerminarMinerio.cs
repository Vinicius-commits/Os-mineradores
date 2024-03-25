using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarMinerio : MonoBehaviour
{

    [SerializeField] private float timer;
    [SerializeField] private int contador;
    [SerializeField] private bool minerando;
    void Update()
    {
        //O Input q vai ser trocar pelo novo input system
        if (Input.GetMouseButtonDown(0))
        {
            if(!minerando)
            {
                Mineracao();
                
            }
            
        }
    }

    void Mineracao()
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

    void Quebrar() //verifica se ele ja foi minerado 3 vezes caso sim ele quebra de deixa a pedra sem minerio
    {
        //AQUI O BAIA PRA TU TIRAR O BARRA BARRA(DEPOIS APAGA ISSO AKI)
        //GameManager.Instance.minerios++;
       contador++;
       minerando = false;
       if(contador >= 3)
        Destroy(this.gameObject);

    }
}
