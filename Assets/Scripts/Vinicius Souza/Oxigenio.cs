using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxigenio : MonoBehaviour
{
    private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player") && OxigenioPlayer.OxigenioAtual < 1.3)
        {
            StartCoroutine("RecuperarOxigenio");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine("RecuperarOxigenio");
        }
    }

    IEnumerator RecuperarOxigenio()
    {
        for (float oxigenio = OxigenioPlayer.OxigenioAtual; oxigenio <= 1; oxigenio += 0.06f)
        {
            OxigenioPlayer.OxigenioAtual = oxigenio;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        OxigenioPlayer.OxigenioAtual = 1;
    }


}
