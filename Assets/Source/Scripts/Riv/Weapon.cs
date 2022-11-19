using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void Activate()
    {
        _isActive = true;
        SetColliderTrigger(true);
    }

    public void Dectivate()
    {
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
}
