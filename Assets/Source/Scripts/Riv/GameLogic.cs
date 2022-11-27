using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    [SerializeField] private RouchCounter _rouchCounter;

    [SerializeField] private TriggerInitCrab _triggerInitCrab;

    [SerializeField] private InputActionProperty _helpPressed;

    private GameStates _gameState = 0;

    private void Start()
    {
        _pot.PotHeating += OnPotHeating;
        _pot.PelmenInPot += OnPelmenInPot;
        _pot.PotOnPlita += PotOnPlita;

        _spawnerTaracan.StartSpawnRoach(2, 0);

        _spawnerTaracan.AllRoachDie += OnAllRoachDie;

        _triggerInitCrab.GetCrab.EndMove += EndGame;

        _helpPressed.action.started += ActionOnStarted;
    }

    private void OnDestroy()
    {
        _pot.PotHeating -= OnPotHeating;
        _pot.PelmenInPot -= OnPelmenInPot;
        _pot.PotOnPlita -= PotOnPlita;

        _spawnerTaracan.AllRoachDie -= OnAllRoachDie;

        _helpPressed.action.started -= ActionOnStarted;

        _triggerInitCrab.GetCrab.EndMove -= EndGame;
    }

    private void EndGame()
    {
        if(_gameState == GameStates.End)
        {

        }
    }

    private void ActionOnStarted(InputAction.CallbackContext obj)
    {
        VRSubtatile.Instance.ShowSubtitle("МИССИЯ");
    }

    private void PotOnPlita()
    {
        if(_gameState == 0)
        {
            _gameState = GameStates.PelmenInPot;

            _spawnerTaracan.StartSpawnRoach(_roachCountOne, _spawnDelayOne);
            _rouchCounter.CounterActivated();

            Debug.LogWarning("geme state - " + _gameState);

            VRSubtatile.Instance.ShowSubtitle("Тараканы атакуют!");
        }
    }

    private void OnAllRoachDie()
    {
        if (_gameState == GameStates.PelmenInPot)
        {
            _pot.MomentumHaiting();
        }

        if(_gameState == GameStates.KillTaracansTwo)
        {           
            VRSubtatile.Instance.ShowSubtitle("Странный звук у дальнего стола...");

            _triggerInitCrab.ActiveredTriggerCrab();
            _gameState= GameStates.End;
        }
    }

    private void OnPelmenInPot(int count)
    {
        if(_gameState == GameStates.PelmenInPot && count >= _pelmenCountFromStateUp)
        {
            _gameState = GameStates.KillTaracansTwo;

            _spawnerTaracan.StartSpawnRoach(_roachCountTwo, _spawnDelayTwo);
            _rouchCounter.CounterActivated();
            Debug.LogWarning("geme state - " + _gameState);

            VRSubtatile.Instance.ShowSubtitle("Тараканы опять идут в бой!");
        }
    }

    private void OnPotHeating()
    {
        //пора закинуть пельмени/ может вызываться повторно 
        if(_gameState == GameStates.PelmenInPot)
            VRSubtatile.Instance.ShowSubtitle("Пора закинуть пельмени");
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
