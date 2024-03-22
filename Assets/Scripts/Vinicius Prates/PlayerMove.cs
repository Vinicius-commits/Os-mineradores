using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    #region Movement
    [Header("Movimentation")]
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] Vector3 _inputAcoes;
    [SerializeField] Movement _movimento = new Movement();
    [SerializeField] ForceMode _forceMode;
    #endregion
    
    #region Colisions
    [Header("Collisions")]
    [SerializeField] bool isGrounded;
    #endregion 

    public void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        ApplyMovement();
    }

    public void FixedUpdate()
    {
        //ApplyRotation();
    }

    public void ApplyMovement()
    {
        var targetSpeed = _movimento.isSprinting ? _movimento.velocidade * _movimento.multiplier : _movimento.velocidade;
        //_movimento.velocidadeAtual = Mathf.MoveTowards(_movimento.velocidadeAtual, targetSpeed, _movimento.aceleracao * Time.deltaTime);
        
        _rigidBody.AddForce((_inputAcoes * targetSpeed * Time.deltaTime), _forceMode);
    }

    public void ApplyRotation()
    {
        if (!(_inputAcoes.x == 0 && _inputAcoes.z == 0))
        {
            var _viewAngle = Mathf.Atan2(_inputAcoes.z, 0.0f) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, _viewAngle, 0.0f);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        _movimento.isSprinting = context.started || context.performed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputAcoes = context.ReadValue<Vector3>();
    }

    public bool IsGrounded() => isGrounded;
}

[Serializable]
public struct Movement
{
    public float velocidade, multiplier, aceleracao;

    [HideInInspector] public bool isSprinting;
    [HideInInspector] public float velocidadeAtual;
}