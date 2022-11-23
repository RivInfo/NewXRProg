using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : SelectidOnHandObject
{
    private bool _isActive = false;

    private Collider[] _colliders;

    private void Start()
    {
        _colliders = GetComponents<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive && other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeHit();
        }
    }

    public void Activate()
    {
        //ConsoleTimeLog("Activate");
        _isActive = true;
        SetColliderTrigger(true);
    }

    public void Dectivate()
    {
        //ConsoleTimeLog("Dectivate");
        _isActive = false;
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

    //public void ConsoleTimeLog(string messege)
    //{
    //    Debug.LogWarning(Time.time +" - " + messege);
    //}
}
