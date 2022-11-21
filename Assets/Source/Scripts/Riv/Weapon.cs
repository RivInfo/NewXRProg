using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    private bool _isActive = false;

    private Collider[] _colliders;

    private void Start()
    {
        _colliders = GetComponentsInChildren<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive && other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeHit();
        }

        if(other.TryGetComponent(out XRRayInteractor Interector))
        {
            ConsoleTimeLog("Wepon on hand");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out XRRayInteractor Interector))
        {
            ConsoleTimeLog("Wepon OUT hand");
        }
    }

    public void Activate()
    {
        ConsoleTimeLog("Activate");
        _isActive = true;
        SetColliderTrigger(true);
    }

    public void Dectivate()
    {
        ConsoleTimeLog("Dectivate");
        _isActive = false;
        SetColliderTrigger(false);
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
        Debug.LogWarning(Time.time +" - " + messege);
    }
}
