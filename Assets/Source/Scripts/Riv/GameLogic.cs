using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] int _pelmenCountFromStateUp = 3;

    [Header("Roach Wave One")]
    [SerializeField] private int _roachCountOne = 10;
    [SerializeField] private float _spawnDelayOne = 1;

    [Header("Roach Wave Two")]
    [SerializeField] private int _roachCountTwo = 20;
    [SerializeField] private float _spawnDelayTwo = 1;


    [SerializeField] private Pot _pot;

    [SerializeField] private SpawnerTaracan _spawnerTaracan;

    private GameStates _gameState = 0;

    private void Start()
    {
        _pot.PotHeating += OnPotHeating;
        _pot.PelmenInPot += OnPelmenInPot;
        _pot.PotOnPlita += PotOnPlita;

        _spawnerTaracan.StartSpawnRoach(2, 0);

        _spawnerTaracan.AllRoachDie += OnAllRoachDie; 
    }

    private void PotOnPlita()
    {
        if(_gameState == 0)
        {
            _gameState = GameStates.PelmenInPot;
            _spawnerTaracan.StartSpawnRoach(_roachCountOne, _spawnDelayOne);

            Debug.LogWarning("geme state - " + _gameState);

            VRSubtatile.Instance.ShowSubtitle("Тараканы атакуют!");
        }
    }

    private void OnAllRoachDie()
    {
        //
    }

    private void OnPelmenInPot(int count)
    {
        if(_gameState == GameStates.PelmenInPot && count >= _pelmenCountFromStateUp)
        {
            _gameState = GameStates.KillTaracansTwo;
            _spawnerTaracan.StartSpawnRoach(_roachCountTwo, _spawnDelayTwo);
            Debug.LogWarning("geme state - " + _gameState);

            VRSubtatile.Instance.ShowSubtitle("Тараканы опять идут в бой!");
        }
    }

    private void OnPotHeating()
    {
        //пора закинуть пельмени/ может вызываться повторно 
        VRSubtatile.Instance.ShowSubtitle("Пора закинуть пельмени");
    }

    private void OnDestroy()
    {
        _pot.PotHeating -= OnPotHeating;
        _pot.PelmenInPot -= OnPelmenInPot;
        _pot.PotOnPlita -= PotOnPlita;

        _spawnerTaracan.AllRoachDie -= OnAllRoachDie;
    }
}

public enum GameStates
{
    NeedPotHeating,
    KillTaracansOne,
    PelmenInPot,
    KillTaracansTwo,
    End
}
