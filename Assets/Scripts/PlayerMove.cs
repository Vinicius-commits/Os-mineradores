using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    #region Movement
    [Header("Movimentation")]
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _angleCurrentVelocity;
    [SerializeField] Vector3 _direction, _inputAction;
    [SerializeField] Movement _movement = new Movement();
    #endregion

    #region Jump
    [Header("Jump")]
    [SerializeField] float _jumpPower;
    #endregion

    #region Gravity
    [Header("Gravity")]
    [SerializeField] float _gravity = -9.81f;
    [SerializeField] float _gravityMultiplier = 3.0f;
    [SerializeField] Vector2 _velocity = new Vector2();
    #endregion

    #region Dash
    [Header("Dash")]
    [SerializeField] float _dashStartTime;
    [SerializeField] float _dashSpeed = 3.0f;
    [SerializeField] float _dashTime;
    [SerializeField] float _dashCooldown = 1.0f;
    [SerializeField] bool _isDashing;
    #endregion
    
    #region Colisions
    [Header("Collisions")]
    bool _invicible = false;
    #endregion 

    public void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void FixedUpdate()
    {
        if (_isDashing)
        {
            if (Time.time - _dashStartTime >= _dashCooldown)
            {
                _isDashing = false;
            }
        }

        if(transform.parent != null)
        {
            transform.position = transform.parent.position;
        }

        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "DismantlePlatform" )
        {
            Debug.Log("Colidiu");
            hit.collider.tag = "Untagged";
        }

        else if (hit.transform.tag == "Coins")
        {
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "HorizontalPlatform")
        {
            gameObject.transform.SetParent(hit.transform);
        }

        if(hit.transform.tag != "HorizontalPlatform" || !IsGrounded())
        {
            gameObject.transform.SetParent(null);
        }
        
        if (hit.transform.tag == "PowerUp")
        {
            _invicible = true;
        }

        if (hit.transform.tag == "Enemy" && !_invicible)
        {
        }
    }

    public void ApplyGravity()
    {
        if (IsGrounded() && _velocity.y < 0)
        {
            _velocity.y = -1.0f;
        }
        else
        {
            _velocity.y += _gravity * _gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity.y;
    }

    public void ApplyMovement()
    {
        var targetSpeed = _movement.isSprinting ? _movement.speed * _movement.multiplier : _movement.speed;
        _movement.currentSpeed = Mathf.MoveTowards(_movement.currentSpeed, targetSpeed, _movement.acceleration * Time.deltaTime);
        
        _characterController.Move(_direction * _movement.currentSpeed * Time.deltaTime);
    }

    public void ApplyRotation()
    {
        if (!(_direction.x == 0))
        {
            var _viewAngle = Mathf.Atan2(_direction.x, 0) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, _viewAngle, 0.0f);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        _movement.isSprinting = context.started || context.performed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _inputAction = context.ReadValue<Vector3>();
        _direction = new Vector3(_inputAction.x, 0, 0);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        // jump with button press timed / hight
        if (!context.started) return;
        if (!IsGrounded()) return;

        _velocity.y += _jumpPower;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        StartCoroutine(DashLogic());
    }

    public bool IsGrounded() => _characterController.isGrounded;

    IEnumerator DashLogic()
    {
        float dashStartTime = Time.time;

        while(Time.time < dashStartTime + _dashTime)
        {
            _characterController.Move(_direction * _dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

[Serializable]
public struct Movement
{
    public float speed, multiplier, acceleration;

    [HideInInspector] public bool isSprinting;
    [HideInInspector] public float currentSpeed;
}