using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : Singleton<GameManager>
{
    public int ouro = 0;
    public int ferro = 0;
    public int aluminio = 0;
    public int niobio = 0;


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

   
}
