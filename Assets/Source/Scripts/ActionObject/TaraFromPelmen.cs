using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TaraFromPelmen : SelectidOnHandObject
{
    private Collider[] _colliders;

    private void Start()
    {       
        _colliders = GetComponentsInChildren<Collider>();
        foreach(Collider collider in _colliders)
        {
            if (collider.gameObject.TryGetComponent(out Pelmen pelmen))
            {
                _interector.colliders.Remove(collider);
            }
        }
    }

    public void Activate()
    {
        _colliders = GetComponentsInChildren<Collider>();
        SetColliderTrigger(true);
    }

    public void Dectivate()
    {
        SetColliderTrigger(false);
    }

    protected override void ObjectInHand(SelectEnterEventArgs args)
    {
        base.ObjectInHand(args);
        Activate();
    }

    protected override void ObjectOutHand(SelectExitEventArgs args)
    {
        base.ObjectOutHand(args);
        Dectivate();
    }

    private void SetColliderTrigger(bool isTrigger)
    {
        foreach (var item in _colliders)
        {
            item.isTrigger = isTrigger;
        }
    }
}
