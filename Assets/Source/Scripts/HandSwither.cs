using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Collider), typeof(ActionBasedController))]
public class HandSwither : MonoBehaviour
{
    private ActionObject _actionObjectOnHand;

    private ActionBasedController _xrController;

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
        bool triggerButton = _xrController.activateInteractionState.value > 0.5f;

        Debug.Log(triggerButton);

        if (triggerButton && _actionObjectOnHand != null)
        {
            _actionObjectOnHand.Activate();

            _actionObjectOnHand = null;
        }
    }
}
