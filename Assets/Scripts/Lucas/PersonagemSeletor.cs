using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemSeletor : MonoBehaviour
{
    bool djalma;
    bool marri;

    [SerializeField] Animator djalminha;
    [SerializeField] Animator marriCurri;
    public void Djalminha()
    {
        GameManager.Instance.djalminha = true;
        GameManager.Instance.mariCurri = false;
    }
    public void MariCurri()
    {
        GameManager.Instance.djalminha = false;
        GameManager.Instance.mariCurri = true;
    }

    public void DjalminhaAnm()
    {
        if (!djalma)
        {
            djalma = true;
            djalminha.SetTrigger("Tchau");
            Invoke("DjalminhaVolta", 2.375f);
        }

    }
    public void MarriCurriAnm()
    {
        AnimatorStateInfo stateInfoMarri = marriCurri.GetCurrentAnimatorStateInfo(0);
        if (!marri)
        {
            marri = true;
            marriCurri.SetTrigger("Tchau");
            Invoke("MarriCurriVolta", 2.375f);
        }
    }
    void DjalminhaVolta()
    {
        djalma = false;
    }
    void MarriCurriVolta()
    {
        marri = false;
    }
}
