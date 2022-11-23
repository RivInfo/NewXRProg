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

    List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        StartSpawnRoach(countTaracans, 1f);
    }

    public void StartSpawnRoach(int count, float delay)
    {
        StartCoroutine(CreatesTaracan(testPosCreate, count, delay));
    }

    private IEnumerator CreatesTaracan(Transform positionCreated, int countTarecans, float delay)
    {
        int num = 0;
        int count = countTarecans;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (num < count)
        {
            num++;
            CreateObjectTaracan(positionCreated);
            yield return wait;
        }
    }

    private void CreateObjectTaracan(Transform pos)
    {
        EnemyMover taracan = Instantiate(prefabsTaracan, pos.position, Quaternion.identity);
        taracan.SetMovePoints(_movePointsStart, _moveRandomPoints);

        if(taracan.TryGetComponent(out Enemy enemy))
        {
            RegistrateRoach(enemy);
        }
    }

    private void RegistrateRoach(Enemy enemy)
    {
        enemies.Add(enemy);
        enemy.Dead += OnDie;
    }

    private void OnDie(Enemy enemy)
    {
        enemies.Remove(enemy);
        enemy.Dead -= OnDie;
    }
}
