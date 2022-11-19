using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class Pelmen : MonoBehaviour
{
    private bool _isActive = false;

    private Collider[] _colliders;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _colliders = GetComponentsInChildren<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        SetColliderTrigger(true);
    }

    public void Activate()
    {
        _isActive = true;
        SetColliderTrigger(true);
    }

    public void Dectivate()
    {
        _isActive = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
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
