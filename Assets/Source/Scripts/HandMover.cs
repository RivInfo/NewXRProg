using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandMover : MonoBehaviour
{
    [SerializeField] private bool IsLeftHand;
    [SerializeField] private float _rotateDelay = 1f;
    [SerializeField] private float _xAxisRotation = 45f;
    [SerializeField] private float _speed = 10;

    [SerializeField] private Rigidbody _rigidbody;

    private TinyInputDeviceManager _inputDeviceManager;

    private bool _isRotateAvalible = true;

    private Coroutine _currentCorontine;

    private WaitForSeconds _dalay;

    private void Start()
    {
        _inputDeviceManager = GetComponentInParent<TinyInputDeviceManager>();

        _dalay = new WaitForSeconds(_rotateDelay);
    }

    private void Update()
    {
        var inputDevice = IsLeftHand ? _inputDeviceManager.LeftController
            : _inputDeviceManager.RightController;

        inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisValue);


        if(!_isRotateAvalible && axisValue.y == 0)
        {
            _isRotateAvalible = true;
        }

        if (_isRotateAvalible && Mathf.Abs(axisValue.y) > 0.5f)
        {
            if (_currentCorontine != null)
                StopCoroutine(_currentCorontine);

            _currentCorontine = StartCoroutine(RotateDelay());

            Rotate(axisValue.y);
        }


        if(Mathf.Abs(axisValue.x) > 0.2f && _rigidbody!=null)//Тут рассинхрон камеры игрока и
        //игровой зоны. нужно как то решить
        {
            Vector3 decreesVector = _inputDeviceManager.transform.position - transform.position;

            _rigidbody.velocity = decreesVector.normalized * axisValue.x * _speed;
        }
    }

    private void Rotate(float axisY)
    {
        if(axisY > 0)
        {
            _inputDeviceManager.transform.Rotate(_xAxisRotation, 0,0);
        }
        else
        {
            _inputDeviceManager.transform.Rotate(-_xAxisRotation, 0, 0);
        }
    }

    private IEnumerator RotateDelay()
    {
        _isRotateAvalible = false;

        yield return _dalay;

        _isRotateAvalible = true;
    }
}
