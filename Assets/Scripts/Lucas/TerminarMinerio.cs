using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarMinerio : Interactable
{
    [SerializeField] private float timer;
    [SerializeField] private int contador;
    [SerializeField] private bool minerando;
    [SerializeField] private bool ouro, ferro, aluminio, niobio;
    [SerializeField] private GameObject pedra;

    public override void Interagir()
    {
        Mineracao();
    }

    public void Mineracao()
    {
        if (!minerando)
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
        if (ouro)
        {
            GameManager.Instance.ouro++;
            if(GameManager.Instance.ouro == 4)
            SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Ouro);
        }

        else if (ferro)
        {
            GameManager.Instance.ferro++;
            if(GameManager.Instance.ferro == 4)
            SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Ferro);
        }

        else if (aluminio)
        {
            GameManager.Instance.aluminio++;
            if(GameManager.Instance.aluminio == 4)
            SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Aluminio);
        }

        else if (niobio)
        {
            GameManager.Instance.niobio++;
            if(GameManager.Instance.niobio == 4)
            SaveManager.Instance.SaveMuseu(SaveManager.Minerios.Niobio);
        }

        contador++;
        minerando = false;
        if (contador >= 3)
        {
            pedra.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
