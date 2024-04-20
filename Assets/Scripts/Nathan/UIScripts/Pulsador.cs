using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulsador : MonoBehaviour
{
    //la ele

    //AINDA TO CRIANDO ISSO AQUI,  N MEXER

    //usando animation fica melhor rei
    // public float pulseScale = 1.15f; 
    // public float pulseSpeed = 0;
    
    bool _pulsando = false;

    RectTransform rectTransform;
    [SerializeField]private Vector3 defaultScale; 

    [SerializeField] Animation anim;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultScale = rectTransform.localScale; 
    }

    public void ComecaPulsar()
    {
        // _pulsando = true;
        // StartCoroutine(Pulsante());
        anim.Play();
    }

    public void ParaPulsar()
    {
        // _pulsando = false;
        anim.Stop();
        rectTransform.localScale = defaultScale;
    }

    // private IEnumerator Pulsante()
    // {
    //     while(_pulsando)
    //     {
    //         float scale = Mathf.PingPong(Time.time * pulseSpeed, pulseScale); 
    //         transform.localScale = defaultScale * scale;
    //         yield return new WaitForSeconds(0.2f);
    //     }
    // }
}