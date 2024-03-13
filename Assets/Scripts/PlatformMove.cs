using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float t, _speed;
    [SerializeField] Transform _pointA, _pointB, _platform;

    public void Update()
    {
        t = Mathf.PingPong(Time.time * _speed, 1.0f);
        Movement();
    }

    public void Movement()
    {
        _platform.position = Vector3.Lerp(_pointB.position, _pointA.position, t);
    }
}
