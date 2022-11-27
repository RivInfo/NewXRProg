using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Collider), typeof(ActionBasedController))]
public class HandSwither : MonoBehaviour
{
    private ActionObject _actionObjectOnHand;

    private ActionBasedController _xrController;

    private bool _isSwithAllow = true;

    private float _swithValueActivatio = 0.7f;
    private float _swithValueAllow = 0.1f;

    private void Start()
    {
        _xrController = GetComponent<ActionBasedController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ActionObject actionObject)
            && actionObject.isActiveAndEnabled)
        {
            _actionObjectOnHand = actionObject;

            Debug.Log(actionObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ActionObject actionObject)
            && _actionObjectOnHand == actionObject)
        {
            _actionObjectOnHand = null;
        }
    }

    private void Update()
    {
        float interactionValue = _xrController.activateInteractionState.value;

        bool triggerButton = interactionValue > _swithValueActivatio;

        if (interactionValue < _swithValueAllow)
        {
            _isSwithAllow = true;
        }


        if (_isSwithAllow && triggerButton && _actionObjectOnHand != null)
        {
            _actionObjectOnHand.Activate();

            _isSwithAllow = false;
        }
    }
}
