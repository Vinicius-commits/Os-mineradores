using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canva : MonoBehaviour
{
    public GameObject canvas; 

    
    public void ToggleCanvas()
    {
        
        canvas.SetActive(!canvas.activeSelf);
    }
}

