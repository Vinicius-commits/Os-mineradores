using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotacao : MonoBehaviour
{
    [SerializeField] float _sensibilidade;
    [SerializeField] float _rotacao = 0;

    public void CamRotacao(InputAction.CallbackContext context)
    {
        float rotacao = context.ReadValue<float>() * _sensibilidade * Time.deltaTime;
        _rotacao += rotacao;

        transform.localRotation = Quaternion.Euler(0, _rotacao, 0);
    }
}
