using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

[ExecuteInEditMode]
public class VisualCamSeguir : MonoBehaviour
{
    #region Realocate
    [SerializeField] Transform _playerTransform;

    [Header("Realocate X")]
    [SerializeField] float _realocateDistanceX;
    [SerializeField] float _realocateSpeedX = 1.0f;

    [Header("Realocate Y")]
    [SerializeField] float _realocateDistanceY;
    [SerializeField] float _realocateSpeedY = 1.0f;

    [Header("Realocate Z")]
    [SerializeField] float _realocateDistanceZ;
    [SerializeField] float _realocateSpeedZ = 1.0f;

    [Header("Realocate Speed")]
    [SerializeField] float _speedUp = 1.5f;
    [SerializeField] float _normalSpeed = 1.0f;
    #endregion

    Vector3 rePosition;

    void FixedUpdate()
    {
        rePosition = new Vector3(_playerTransform.localPosition.x + (_realocateDistanceX * _realocateSpeedX), _playerTransform.localPosition.y + (_realocateDistanceY * _realocateSpeedY), _playerTransform.localPosition.z + (_realocateDistanceZ * _realocateSpeedZ));
        transform.position = rePosition;
    }

    public void ChangeRealocateSpeed(InputAction.CallbackContext context)
    {
        if(context.started || context.performed) 
        {
            _realocateSpeedX = _speedUp;
            _realocateSpeedZ = _speedUp;
        }
        else if(context.canceled)
        {
            _realocateSpeedX = _normalSpeed;
            _realocateSpeedZ = _normalSpeed;
        }

    }

    public void ChangeRealocateDistance(InputAction.CallbackContext context)
    {
        if(context.started || context.performed && context.ReadValue<Vector3>().x < 0 && _realocateDistanceX > 0)
        {
            _realocateDistanceX *= -1.0f;
        } else if (context.started || context.performed && context.ReadValue<Vector3>().x > 0 && _realocateDistanceX < 0)
        {
            _realocateDistanceX *= -1.0f;
        }
    }
}
