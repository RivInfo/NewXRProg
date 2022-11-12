using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private MovePoints _movePointsStart;
    private MovePoints _moveRandomPoints;
    [SerializeField] private float _speed = 1;
    [SerializeField] private Vector3 _rotationAdd;

    private bool startMove = true;
    private bool startRndMove = false;

    private int _pointNumber = 0;

    private Vector3 targetMove;

    Vector3 moveRandomPoint;

    void Update()
    {
        if (_movePointsStart != null && startMove) 
        {
            Vector3 movePoint = _movePointsStart.GetPositionFromIndex(_pointNumber);

            targetMove = movePoint;

            if (movePoint != transform.position)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position,
                    movePoint, _speed * Time.deltaTime);
            }
            else
            {
                _pointNumber++;
                if (_movePointsStart.GetMovePoints.Length - 1 < _pointNumber)
                {
                    startMove = false;
                    startRndMove = true;

                    moveRandomPoint = _moveRandomPoints.GetRandomPosition();
                    targetMove = moveRandomPoint;
                }
            }
        }

        if (startRndMove && _moveRandomPoints != null)
        {
            transform.position =Vector3.MoveTowards(transform.position,moveRandomPoint, _speed * Time.deltaTime);
            if (transform.position == moveRandomPoint)
            {
                moveRandomPoint = _moveRandomPoints.GetRandomPosition();
                targetMove = moveRandomPoint;
            }
        }

        var direction = targetMove - transform.position;
        transform.forward = direction.normalized;
    }


    public void SetMovePoints(MovePoints pointsStart, MovePoints RandomPoints)
    {
        _movePointsStart = pointsStart;
        _moveRandomPoints = RandomPoints;
    }
}
