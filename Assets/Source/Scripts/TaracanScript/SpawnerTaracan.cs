using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerTaracan : MonoBehaviour
{
    [SerializeField] private EnemyMover prefabsTaracan;
    [SerializeField] private int countTaracans;

    [SerializeField] private Transform testPosCreate;

    [SerializeField] private MovePoints _movePointsStart;
    [SerializeField] private MovePoints _moveRandomPoints;

    private List<Enemy> enemies = new List<Enemy>();
    private int _killCount = 0;

    public event UnityAction AllRoachDie;
    public event UnityAction<int> RochKillCount;

    public int CurrenMaxRoch { get; private set; }

    public void StartSpawnRoach(int count, float delay)
    {
        CurrenMaxRoch = count + enemies.Count;
        _killCount = 0;
        RochKillCount?.Invoke(_killCount);

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
        _killCount++;
        RochKillCount?.Invoke(_killCount);

        if (enemies.Count == 0)
        {
            AllRoachDie?.Invoke();
        }
    }
}
