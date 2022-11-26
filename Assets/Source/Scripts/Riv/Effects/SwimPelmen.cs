using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimPelmen : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Vector2 _minMaxOffset = new Vector2(0, 0.2f);
    [SerializeField] private Vector2 _minMaxRandomRotation;

    private Vector3 _startPosition;
    private Vector3 _firstPosition;
    private Vector3 _lastPosition;

    private int _index = 0;

    private void Start()
    {
        _startPosition = transform.localPosition;

        _firstPosition = _startPosition;
        _firstPosition.z += _minMaxOffset.x;

        _lastPosition = _startPosition;
        _lastPosition.z += _minMaxOffset.y;
    }

    void Update()
    {

        if (_index == 0)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, 
                _lastPosition, _speed*Time.deltaTime);
        else
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                _firstPosition, _speed * Time.deltaTime);

        if (transform.localPosition == _firstPosition)
            _index = 0;
        if (transform.localPosition == _lastPosition)
            _index = 1;

        //Vector3 lo = transform.localRotation.eulerAngles;
        //lo.x += Random.Range(_minMaxRandomRotation.x, _minMaxRandomRotation.y)*Time.deltaTime;
        //lo.y += Random.Range(_minMaxRandomRotation.x, _minMaxRandomRotation.y) * Time.deltaTime;
        //lo.z += Random.Range(_minMaxRandomRotation.x, _minMaxRandomRotation.y) * Time.deltaTime;

        //transform.localRotation = Quaternion.Euler(lo);
    }
}
