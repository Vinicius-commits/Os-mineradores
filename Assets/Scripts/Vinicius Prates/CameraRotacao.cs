using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotacao : MonoBehaviour
{
    [SerializeField] float _sensibilidade;
    [SerializeField] float _rotacao = 0;
    [SerializeField] float rotacao;

    public void CamRotacao(InputAction.CallbackContext context)
    {
        if (context.control.device is Gamepad)
            rotacao = context.ReadValue<Vector2>().x * _sensibilidade * 100 * Time.deltaTime;
        else
            rotacao = context.ReadValue<Vector2>().x * _sensibilidade * Time.deltaTime;


    }
    public void Update()
    {
        _rotacao += rotacao;
        transform.localRotation = Quaternion.Euler(0, _rotacao, 0);
    }
}
