using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    [SerializeField] private MovePoint[] _movePoints;

    public MovePoint[] GetMovePoints => _movePoints;

    public Vector3 GetPositionFromIndex(int index)
    {
        if (index < _movePoints.Length && index >= 0)
        {
            return _movePoints[index].transform.position;
        }
        else
        {
            Debug.LogError("Индекс вышел за пределы");
        }

        return Vector3.zero;
    }
}
