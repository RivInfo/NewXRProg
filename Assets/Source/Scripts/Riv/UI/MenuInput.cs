using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private GameObject _panelActivatid;
    
    [SerializeField] private InputActionProperty _menuPressed;

    [SerializeField] private PositionatCanvasOnVr _positionatCanvas;

    [SerializeField] private Text _text;

    [SerializeField] private GameLogic _logic;

    private void Start()
    {
        _menuPressed.action.started += ActionOnStarted;

        _panelActivatid.SetActive(false);
    }

    private void OnDestroy()
    {
        _menuPressed.action.started -= ActionOnStarted;
    }

    private void ActionOnStarted(InputAction.CallbackContext obj)
    {
        _panelActivatid.SetActive(!_panelActivatid.activeSelf);
        _positionatCanvas.PlaceCanvas();

        if (_text != null)
        {
            _text.text = _logic.GetActualiMission();
        }
    }
}
