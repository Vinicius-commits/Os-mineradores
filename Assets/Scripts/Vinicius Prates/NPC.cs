using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : Interactable
{
    #region MineirosTipos
    enum TiposMineiros
    {
        None,
        Alexandre,
        Cibelly,
        Samuel,
        Paola
    }

    [SerializeField] TiposMineiros tipoMineiro;
    [SerializeField] MineiroPreset mineiroPreset;
    [SerializeField] List<MineiroPreset> listaMineiros = new List<MineiroPreset>();
    #endregion

    #region NPCscripts
    [SerializeField] NPCInteraction interacoes;
    [SerializeField] NpcMineracao mineracao;
    #endregion

    #region UIMineiro
    [SerializeField] Image mineiroImage;
    [SerializeField] TextMeshProUGUI mineiroNome;
    [SerializeField] MeshFilter mineiroMesh;
    #endregion

    bool estaLiberadoInteragir = true;

    public void Start() {
        switch(tipoMineiro)
        {
            case TiposMineiros.None:
                mineiroPreset = null;
                break;

            case TiposMineiros.Alexandre:
                mineiroPreset = listaMineiros[0];
                break;

            case TiposMineiros.Cibelly:
                mineiroPreset = listaMineiros[1];
                break;

            case TiposMineiros.Paola:
                mineiroPreset= listaMineiros[2];
                break;

            case TiposMineiros.Samuel:
                mineiroPreset= listaMineiros[3];
                break;
                
        }
        if(mineiroPreset != null)
        {
            mineiroImage.sprite = mineiroPreset.mineiroIcon;
            mineiroNome.text = mineiroPreset.nome;
            mineiroMesh.mesh = mineiroPreset.corpoTipo;
        }
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
