using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovimentacao : MonoBehaviour
{
    #region Movement
    [Header("Movimentation")]
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] Vector3 _inputAcoes;
    [SerializeField] Movimento _movimento = new Movimento();
    [SerializeField] ForceMode _forceMode;
    #endregion
    
    #region Colisions
    [Header("Collisions")]
    [SerializeField] bool _estaNoChao;
    [SerializeField] RaycastHit hit;
    #endregion 

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }

    public void ApplyMovement()
    {
        var targetSpeed = _movimento.estaCorrendo ? _movimento.velocidade * _movimento.multiplicarCorrida : _movimento.velocidade;        
        _rigidBody.AddForce((_inputAcoes * targetSpeed * Time.deltaTime), _forceMode);
    }

    public void ApplyRotation()
    {
        if (!(_inputAcoes.x == 0 && _inputAcoes.z == 0))
        {
            var _viewAngle = Mathf.Atan2(_inputAcoes.x, _inputAcoes.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, _viewAngle, 0.0f);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        _movimento.estaCorrendo = context.started || context.performed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputAcoes = context.ReadValue<Vector3>();
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Physics.Raycast(transform.position, transform.forward, out hit, 2.0f);

            if(hit.collider == null)
            {
                return;
            }

            if (hit.collider.CompareTag("Minerio") && hit.collider != null)
                hit.collider.GetComponent<IInteractable>().Interagir();

            if (hit.collider.CompareTag("Pedra") && hit.collider != null)
                hit.collider.GetComponent<IInteractable>().Interagir();
        }
    }

    public bool IsGrounded() => _estaNoChao;
}

[Serializable]
public struct Movimento
{
    public float velocidade, multiplicarCorrida, aceleracao;

    [HideInInspector] public bool estaCorrendo;
    [HideInInspector] public float velocidadeAtual;
}