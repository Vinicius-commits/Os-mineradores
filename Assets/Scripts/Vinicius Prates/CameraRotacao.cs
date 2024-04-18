using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotacao : MonoBehaviour
{
    float rotateSpeed = 0;

    Vector2 rotationInput;
    public void CamRotacao(InputAction.CallbackContext context)
    {
        rotationInput = Mouse.current.delta.ReadValue();

        // Rotaciona o objeto com base na entrada do mouse
        float rotationX = rotationInput.y * rotateSpeed * Time.deltaTime;
        float rotationY = -rotationInput.x * rotateSpeed * Time.deltaTime; // Invertido para inverter a direção da rotação

        transform.Rotate(rotationX, rotationY, 0);
        Vector2 inputRotacao = context.ReadValue<Vector2>();
        Quaternion rotacao = Quaternion.Euler(0, inputRotacao.x, 0);
        transform.rotation *= rotacao;
    }
}
