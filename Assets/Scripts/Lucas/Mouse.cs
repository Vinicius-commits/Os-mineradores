using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         // Travar o mouse no centro da tela
        Cursor.lockState = CursorLockMode.Locked;

        // Esconder o cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
