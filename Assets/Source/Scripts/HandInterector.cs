using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Collider))]
public class HandInterector : MonoBehaviour
{
    public bool IsLeftHand;

    public TinyInputDeviceManager InputDeviceManager;

    private InterectableObgect _interectObgInHand;

    private InterectableObgect _interectObgOnHand;

    private ActionObject _actionObjectOnHand;


    private void Reset()
    {
        InputDeviceManager = GetComponentInParent<TinyInputDeviceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out InterectableObgect interectable) && interectable.isActiveAndEnabled)
        {
            _interectObgOnHand = interectable;
        }

        if(other.gameObject.TryGetComponent(out ActionObject actionObject) && actionObject.isActiveAndEnabled)
        {
            _actionObjectOnHand = actionObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out InterectableObgect interectable) && interectable == _interectObgOnHand)
        {
            _interectObgOnHand = null;
        }


        if (other.gameObject.TryGetComponent(out ActionObject actionObject) && _actionObjectOnHand == actionObject)
        {
            _actionObjectOnHand = null;
        }
    }

    private void Update()
    {
        var inputDevice = IsLeftHand ? InputDeviceManager.LeftController : InputDeviceManager.RightController;

        inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);
        inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButton);

        if (gripValue && _interectObgOnHand != null)
        {
            _interectObgInHand = _interectObgOnHand;
            _interectObgOnHand = null;

            _interectObgInHand.Rigidbody.isKinematic = true;
            _interectObgInHand.transform.parent = transform;
        }

        if(!gripValue  && _interectObgInHand!= null)
        {
            _interectObgInHand.transform.parent = null;
            
            _interectObgInHand.Rigidbody.isKinematic = false;
            _interectObgInHand = null;
        }

        if(triggerButton && _actionObjectOnHand != null)
        {
            _actionObjectOnHand.Swith();

            _actionObjectOnHand = null;
        }

    }
}
