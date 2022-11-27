using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class Pelmen : SelectidOnHandObject
{
    private bool _isActive = false;

    private Collider[] _colliders;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _colliders = GetComponentsInChildren<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        //SetColliderTrigger(true);
    }

    public void Activate()
    {
        _isActive = true;
        SetColliderTrigger(true);
       // ConsoleTimeLog("pel");
    }

    public void Dectivate()
    {
        _isActive = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
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


    public void ConsoleTimeLog(string messege)
    {
        Debug.LogWarning(Time.time + " - " + messege);
    }
}
