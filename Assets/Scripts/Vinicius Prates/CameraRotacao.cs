using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotacao : MonoBehaviour
{
    [SerializeField] float _sensibilidade;

    public void CamRotacao(InputAction.CallbackContext context)
    {
        float rotacao = context.ReadValue<float>();
        
    }
}
