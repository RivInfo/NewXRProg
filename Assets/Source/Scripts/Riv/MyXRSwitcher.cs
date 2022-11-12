using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class MyXRSwitcher : MonoBehaviour
{
    private ActionBasedController _xrController;

    private void Start()
    {
        _xrController = GetComponent<ActionBasedController>();
    }

    private void Update()
    {
        Debug.LogWarning(_xrController.activateInteractionState.value);
    }
}
