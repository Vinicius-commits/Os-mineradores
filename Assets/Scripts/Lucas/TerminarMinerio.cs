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
            minerando = true;
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
        minerando = false;
        if (contador >= 3)
        {
            if (pedra != null)
            {
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