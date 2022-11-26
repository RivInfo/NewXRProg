using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class SelectidOnHandObject : MonoBehaviour
{
    [SerializeField] private UnityEvent _inHand;
    [SerializeField] private UnityEvent _outHand;

    protected XRGrabInteractable _interector;

    private void OnEnable()
    {
        _interector = GetComponent<XRGrabInteractable>();

        _interector.selectEntered.AddListener(ObjectInHand);
        _interector.selectExited.AddListener(ObjectOutHand);
    }

    private void OnDisable()
    {
        _interector.selectEntered.RemoveListener(ObjectInHand);
        _interector.selectExited.RemoveListener(ObjectOutHand);
    }

    protected virtual void ObjectInHand(SelectEnterEventArgs args)
    {
        _inHand.Invoke();
    }

    protected virtual void ObjectOutHand(SelectExitEventArgs args)
    {
        _outHand.Invoke();
    }
}
