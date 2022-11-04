using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Collider))]
public class HandSwither : MonoBehaviour
{
    [SerializeField] private bool IsLeftHand;

    private TinyInputDeviceManager _inputDeviceManager;

    private ActionObject _actionObjectOnHand;

    private void Start()
    {
        _inputDeviceManager = GetComponentInParent<TinyInputDeviceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ActionObject actionObject)
            && actionObject.isActiveAndEnabled)
        {
            _actionObjectOnHand = actionObject;
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
        var inputDevice = IsLeftHand ? _inputDeviceManager.LeftController
            : _inputDeviceManager.RightController;

        inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButton);


        if (triggerButton && _actionObjectOnHand != null)
        {
            _actionObjectOnHand.Activate();

            _actionObjectOnHand = null;
        }
    }
}
