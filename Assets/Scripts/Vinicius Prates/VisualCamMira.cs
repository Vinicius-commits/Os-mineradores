using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class VisualCamMira : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _realocateDistanceX, _realocateSpeedX = 1.0f; 
    [SerializeField] float _realocateDistanceY, _realocateSpeedY = 1.0f;
    [SerializeField] float _realocateDistanceZ, _realocateSpeedZ = 1.0f;
    Vector3 rePosition;

    void FixedUpdate()
    {
        rePosition = new Vector3(_playerTransform.position.x + (_realocateDistanceX * _realocateSpeedX), _playerTransform.position.y + (_realocateDistanceY * _realocateSpeedY), _playerTransform.position.z + (_realocateDistanceZ * _realocateSpeedZ));
        transform.position = rePosition;
    }

    public void ChangeRealocateSpeed(InputAction.CallbackContext context)
    {
        if(context.started || context.performed) {
            _realocateSpeedX = 1f;
            _realocateSpeedZ = 1f;
        }
        else if(context.canceled)
        {
            _realocateSpeedX = 1.5f;
            _realocateSpeedZ = 1.5f;
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
