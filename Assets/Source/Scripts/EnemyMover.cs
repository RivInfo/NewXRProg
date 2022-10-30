using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private MovePoints _movePoints;
    [SerializeField] private float _speed = 1;
    [SerializeField] private Vector3 _rotationAdd;

    private int _pointNumber = 0;

    
    void Update()
    {
        if( _movePoints != null)
        {
            Vector3 movePoint = _movePoints.GetPositionFromIndex(_pointNumber);
            if (movePoint != transform.position)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position,
                    movePoint, _speed * Time.deltaTime);

                Quaternion saveRotation = transform.rotation;

                transform.LookAt(movePoint);
            }
            else
            {
                _pointNumber++;
                if (_movePoints.GetMovePoints.Length - 1 < _pointNumber)
                    _pointNumber = 0;
            }
        }
    }
}
