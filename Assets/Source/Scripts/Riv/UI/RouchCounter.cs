using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouchCounter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private SpawnerTaracan _spawner;

    private void OnEnable()
    {
        _spawner.AllRoachDie += AllRoachDie;
        _spawner.RochKillCount += OnRochKillCount;

        _text.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _spawner.RochKillCount -= OnRochKillCount;
        _spawner.AllRoachDie -= AllRoachDie;
    }

    public void CounterActivated()
    {
        _text.gameObject.SetActive(true);
    }

    private void OnRochKillCount(int count)
    {
        _text.text =$"{count}/{_spawner.CurrenMaxRoch}";
    }

    private void AllRoachDie()
    {
        _text.gameObject.SetActive(false);
    }
}
