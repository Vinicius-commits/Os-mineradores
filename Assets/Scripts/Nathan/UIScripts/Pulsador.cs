using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulsador : MonoBehaviour
{
    //la ele

    //AINDA TO CRIANDO ISSO AQUI,  N MEXER
    public Button button; 
    public float pulseScale = 1.1f; 
    public float pulseSpeed = 1.0f; 

    private Vector3 defaultScale; 

    void Start()
    {
        if (button == null)
        {
            button = GetComponent<Button>(); 
        }

        defaultScale = button.transform.localScale; 
    }

    void Update()
    {
        if (button.IsInteractable() && RectTransformUtility.RectangleContainsScreenPoint(button.GetComponent<RectTransform>(), Input.mousePosition))
        {
            
            float scale = Mathf.PingPong(Time.time * pulseSpeed, pulseScale); 
            button.transform.localScale = defaultScale * scale; 
        }
        else
        {
            
            button.transform.localScale = defaultScale; 
        }
    }
}