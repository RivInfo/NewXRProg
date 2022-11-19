using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTaracans : MonoBehaviour
{
    [SerializeField] private EnemyMover prefabsTaracan;
    [SerializeField] private int countTaracans;

    [SerializeField] private float speedTaracanEffect;

    [SerializeField] private MovePoints[] _movePointsStart;

    private int index = 1;

    private void Start()
    {
        StartEffectRunTaracans();
    }

    public void StartEffectRunTaracans()
    {
        int num = 0;
        int count = countTaracans;

        while (num < count)
        {
            num++;
            OnlyEffectTaracans();
        }
    }

    private void OnlyEffectTaracans()
    {
        EnemyMover taracan = Instantiate(prefabsTaracan, _movePointsStart[index].GetPositionFromIndex(0), Quaternion.identity);
        taracan.SetSpeedMove(speedTaracanEffect);
        taracan.SetMovePoints(_movePointsStart[index]);
        index++;
        if (index >= _movePointsStart.Length)
            index = 1;
    }
}
