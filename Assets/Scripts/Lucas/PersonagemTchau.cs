using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemTchau : MonoBehaviour
{

    [SerializeField] Animator djalminha;
    [SerializeField] Animator marriCurri;
    void Start()
    {
        djalminha.SetBool("Tchau", true);
        marriCurri.SetBool("Tchau", true);
    }
    void OnDestroy()
    {
        djalminha.SetBool("Tchau", false);
        marriCurri.SetBool("Tchau", true);
    }

}
