using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTaracan : MonoBehaviour
{
    [SerializeField] private EnemyMover prefabsTaracan;
    [SerializeField] private int countTaracans;

    [SerializeField] private Transform testPosCreate;

    [SerializeField] private MovePoints _movePointsStart;
    [SerializeField] private MovePoints _moveRandomPoints;

    private void Start()
    {
        StartCoroutine(CreatesTaracan(testPosCreate, countTaracans));
    }

    private IEnumerator CreatesTaracan(Transform positionCreated, int countTarecans)
    {
        int num = 0;
        int count = countTarecans;

        while (num < count)
        {
            num++;
            CreateObjectTaracan(positionCreated);
            yield return new WaitForSeconds(1f);
        }
    }

    private void CreateObjectTaracan(Transform pos)
    {
        EnemyMover taracan = Instantiate(prefabsTaracan, pos.position, Quaternion.identity);
        taracan.SetMovePoints(_movePointsStart, _moveRandomPoints);
    }
}
