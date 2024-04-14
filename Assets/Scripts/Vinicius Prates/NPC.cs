using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : Interactable
{
    [SerializeField] NPCInteraction interacoes;
    [SerializeField] NpcMineracao mineracao;

    #region UIMineiro
    [SerializeField] MineiroPreset mineiroPreset;
    [SerializeField] Image mineiroImage;
    [SerializeField] TextMeshProUGUI mineiroNome;
    [SerializeField] MeshFilter mineiroMesh;
    #endregion

    bool estaLiberadoInteragir = true;

    public void Start() {
        mineiroImage.sprite = mineiroPreset.mineiroIcon;
        mineiroNome.text = mineiroPreset.nome;
        mineiroMesh.mesh = mineiroPreset.corpoTipo;
    }

    public override void Interagir()
    {
        if (!interacoes.IsPanelActive && estaLiberadoInteragir)
        {
            StartCoroutine(TempoParaInteragir());
            interacoes.ActivatePanel();
        }
        else if(estaLiberadoInteragir && interacoes.IsPanelActive)
        {
            StartCoroutine(TempoParaInteragir());
            interacoes.DeactivatePanel();
        }
    }

    public IEnumerator TempoParaInteragir()
    {
        estaLiberadoInteragir = false;
        yield return new WaitForSeconds(1);
        estaLiberadoInteragir = true;
    }

    public void Descanso()
    {
        mineracao.Descansar();
    }
}
