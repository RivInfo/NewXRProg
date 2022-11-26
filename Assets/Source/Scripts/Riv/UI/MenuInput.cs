using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{
    [SerializeField] private GameObject _panelActivatid;
    
    [SerializeField] private InputActionProperty _menuPressed;

    [SerializeField] private PositionatCanvasOnVr _positionatCanvas;

    private void Start()
    {
        _menuPressed.action.started += ActionOnStarted;
    }

    private void ActionOnStarted(InputAction.CallbackContext obj)
    {
        _panelActivatid.SetActive(!_panelActivatid.activeSelf);
        _positionatCanvas.PlaceCanvas();
    }

    private void OnDestroy()
    {
        _menuPressed.action.started -= ActionOnStarted;
    }
}
