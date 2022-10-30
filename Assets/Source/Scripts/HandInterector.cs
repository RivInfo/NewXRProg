using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Collider))]
public class HandInterector : MonoBehaviour
{
    [SerializeField] private bool IsLeftHand;

    public TinyInputDeviceManager InputDeviceManager;

    private InterectableObgect _interectObjInHand;

    private List<InterectableObgect> _interectObjecsOnHand = new();

    private ActionObject _actionObjectOnHand;


    private void Reset()
    {
        InputDeviceManager = GetComponentInParent<TinyInputDeviceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out InterectableObgect interectable) 
            && interectable.isActiveAndEnabled)
        {
            _interectObjecsOnHand.Add(interectable);
        }

        if(other.gameObject.TryGetComponent(out ActionObject actionObject) 
            && actionObject.isActiveAndEnabled)
        {
            _actionObjectOnHand = actionObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out InterectableObgect interectable) 
            && _interectObjecsOnHand.Contains(interectable))
        {
            _interectObjecsOnHand.Remove(interectable);
        }


        if (other.gameObject.TryGetComponent(out ActionObject actionObject) 
            && _actionObjectOnHand == actionObject)
        {
            _actionObjectOnHand = null;
        }
    }

    private void Update()
    {
        var inputDevice = IsLeftHand ? InputDeviceManager.LeftController 
            : InputDeviceManager.RightController;

        inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);
        inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButton);

        if (gripValue && _interectObjecsOnHand.Count>0)
        {
            InterectableObgect minDistanceObject = ClosestToHand();

            _interectObjInHand = minDistanceObject;

            _interectObjecsOnHand.Remove(minDistanceObject);

            _interectObjInHand.Rigidbody.isKinematic = true;
            _interectObjInHand.transform.parent = transform;
        }

        if(!gripValue  && _interectObjInHand!= null)
        {
            _interectObjInHand.transform.parent = null;
            
            _interectObjInHand.Rigidbody.isKinematic = false;
            _interectObjInHand = null;
        }

        if(triggerButton && _actionObjectOnHand != null)
        {
            _actionObjectOnHand.Activate();

            _actionObjectOnHand = null;
        }
    }

    private InterectableObgect ClosestToHand()
    {
        InterectableObgect minDistanceObject = null;
        float minDistance = 10000f;

        for (int i = 0; i < _interectObjecsOnHand.Count; i++)
        {
            float distance = 
                Vector3.Distance(_interectObjecsOnHand[i].transform.position, transform.position);
            
            if (distance < minDistance)
            {
                minDistanceObject = _interectObjecsOnHand[i];
                minDistance = distance;
            }          
        }
        return minDistanceObject;
    }
}
