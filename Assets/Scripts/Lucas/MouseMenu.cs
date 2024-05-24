using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
         // Travar o mouse no centro da tela
        Cursor.lockState = CursorLockMode.None;

        // Esconder o cursor
        Cursor.visible = true;
    }
}
