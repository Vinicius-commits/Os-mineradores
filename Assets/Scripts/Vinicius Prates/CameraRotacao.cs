using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotacao : MonoBehaviour
{
    [SerializeField] bool booleana;

    public void CamRotacao(InputAction.CallbackContext context)
    {
        Vector2 inputRotacao = context.ReadValue<Vector2>();
        Quaternion.Euler(0, inputRotacao.x, 0);
    }
}
