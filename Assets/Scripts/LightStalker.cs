using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStakjer : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;

    Vector3 rePosition;

    void FixedUpdate()
    {
        rePosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z);
        transform.position = rePosition;
    }
}
