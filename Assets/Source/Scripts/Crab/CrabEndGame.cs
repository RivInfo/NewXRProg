using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEndGame : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _speedJump;
    [SerializeField] private float _speedLerp = 0.25f;

    private bool _isMove = false;

    public void JumpToPlayer()
    {
        Invoke(nameof(StartMove), 0.7f);       
    }

    private void StartMove()
    {
        _isMove = true;
    }

    private void Update()
    {
        if (_isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(_target.position.x, _target.position.y, _target.position.z), 
                Time.deltaTime * _speedJump);
            transform.rotation = 
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(_target.eulerAngles),
                _speedLerp);

            if (transform.position == _target.position)
            {
                transform.parent = _target;
                _isMove = false;
            }
        }
    }
}
