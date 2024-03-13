using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DismantlePlatform : MonoBehaviour
{
    [SerializeField] float _timeCrash = 2.0f, _timeRegen = 3.0f, _crashingTimingStart, _timing;
    [SerializeField] bool _isCrashed, _isCrashing;
    [SerializeField] Transform _platformBody;

    public void FixedUpdate()
    {
        if (_isCrashing)
        {
            if(Time.time - _crashingTimingStart >= _timeCrash)
            {
                _timing = 0;
                _isCrashing = false;
                _isCrashed = true;
                _platformBody.gameObject.SetActive(false);
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        if(_isCrashed)
        {
            _timing += Time.deltaTime;
            if( _timing >= _timeRegen)
            {
                GetComponent<BoxCollider>().enabled = true;
                _timing = 0;
                _platformBody.gameObject.SetActive(true);
                _isCrashed = false;
                gameObject.tag = "DismantlePlatform";
            }
        }
    }

    public void ActiveRoutine()
    {
        _isCrashing = true;
        _crashingTimingStart = Time.time;
        StartCoroutine(Vibration());
    }

    public IEnumerator Vibration()
    { 
        while(!_isCrashed && _isCrashing)
        {
            yield return new WaitForSeconds(0.2f);
            _platformBody.rotation = Quaternion.Inverse(_platformBody.rotation);
        }

        _isCrashing = false;
    }
}
