using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : Singleton<GameManager>
{
    public bool djalminha;
    public bool mariCurri;
    public int ouro = 0;
    public int ferro = 0;
    public int aluminio = 0;
    public int niobio = 0;
    public int zinco = 0;
    public int grafita = 0;
    public int gipsita = 0;
    public int turmalina = 0;
    public int tungstenio = 0;
    public int uranio = 0;
    public int opala = 0;
    public int magnesita = 0;
    public int cobre = 0;
    public int fluorita = 0;
    public int manganes = 0;

    // Evento para notificar sobre as mudanças nos valores de minério
    public event Action<int> OnMinerioAtualizado;

    // Método para atualizar os valores de minério e notificar os assinantes do evento
    private void AtualizarMinerio(int valor, ref int minerio)
    {
        minerio += valor;
        OnMinerioAtualizado?.Invoke(minerio);
    }

    // Métodos para atualizar os valores de minério individualmente
    public void AtualizarOuro(int valor)
    {
        AtualizarMinerio(valor, ref ouro);
    }

    public void AtualizarFerro(int valor)
    {
        AtualizarMinerio(valor, ref ferro);
    }

    public void AtualizarAluminio(int valor)
    {
        AtualizarMinerio(valor, ref aluminio);
    }

    public void AtualizarNiobio(int valor)
    {
        AtualizarMinerio(valor, ref niobio);
    }
    public void AtualizarZinco(int valor)
    {
        AtualizarMinerio(valor, ref zinco);
    }

    public void AtualizarGrafita(int valor)
    {
        AtualizarMinerio(valor, ref grafita);
    }

    public void AtualizarGipsita(int valor)
    {
        AtualizarMinerio(valor, ref gipsita);
    }
    public void AtualizarTurmalina(int valor)
    {
        AtualizarMinerio(valor, ref turmalina);
    }
    public void AtualizarTungstenio(int valor)
    {
        AtualizarMinerio(valor, ref tungstenio);
    }
    public void AtualizarOpala(int valor)
    {
        AtualizarMinerio(valor, ref opala);
    }
    public void AtualizarFluorita(int valor)
    {
        AtualizarMinerio(valor, ref fluorita);
    }
    public void AtualizarMagnesita(int valor)
    {
        AtualizarMinerio(valor, ref magnesita);
    }
    public void AtualizarCobre(int valor)
    {
        AtualizarMinerio(valor, ref cobre);
    }
    public void AtualizarUranio(int valor)
    {
        AtualizarMinerio(valor, ref uranio);
    }
    public void AtualizarManganes(int valor)
    {
        AtualizarMinerio(valor, ref manganes);
    }

}
