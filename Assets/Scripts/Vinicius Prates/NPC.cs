using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField] NPCInteraction interacoes;
    [SerializeField] NpcMineracao mineracao;

    public override void Interagir()
    {
        if (!interacoes.IsPanelActive)
            interacoes.ActivatePanel();
        else
            interacoes.DeactivatePanel();
    }
}
