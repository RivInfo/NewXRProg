using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Collider))]
public class HandInterector : MonoBehaviour
{
    [SerializeField] private bool IsLeftHand;

    private TinyInputDeviceManager _inputDeviceManager;

    private List<InterectableObgect> _interectObjecsOnHand = new();
    
    public InterectableObgect InterectObjInHand { get; private set; }

    private void Start()
    {
        _inputDeviceManager = GetComponentInParent<TinyInputDeviceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out InterectableObgect interectable) 
            && interectable.isActiveAndEnabled)
        {
            _interectObjecsOnHand.Add(interectable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out InterectableObgect interectable) 
            && _interectObjecsOnHand.Contains(interectable))
        {
            _interectObjecsOnHand.Remove(interectable);
        }
    }

    private void Update()
    {
        var inputDevice = IsLeftHand ? _inputDeviceManager.LeftController 
            : _inputDeviceManager.RightController;

        inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);

        if (gripValue && _interectObjecsOnHand.Count > 0 && InterectObjInHand == null)
        {
            InterectableObgect minDistanceObject = ClosestToHand();

            Debug.Log(_interectObjecsOnHand.Count);

            InterectObjInHand = minDistanceObject;

            _interectObjecsOnHand.Remove(minDistanceObject);

            Debug.Log(InterectObjInHand.name);


            InterectObjInHand.Rigidbody.isKinematic = true;
            InterectObjInHand.transform.parent = transform;
        }

        if(!gripValue  && InterectObjInHand != null)
        {
            if(InterectObjInHand.transform.parent == transform)
                InterectObjInHand.transform.parent = null;
            
            InterectObjInHand.Rigidbody.isKinematic = false;
            InterectObjInHand = null;
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
