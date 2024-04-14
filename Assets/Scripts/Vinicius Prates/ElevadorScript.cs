using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorScript : Interactable
{
    [SerializeField] MudarCena mudarCena;
    [SerializeField] string proximaCenaNome;
    public override void Interagir()
    {
        mudarCena.MudandoCena(proximaCenaNome);
    }
}
