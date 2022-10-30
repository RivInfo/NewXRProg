using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ActionObject : MonoBehaviour
{
    [SerializeField] bool _isActive;

    [SerializeField] private UnityEvent _active;
    [SerializeField] private UnityEvent _deactive;

    private void Start()
    {
        EventActivate();
    }
    public void Swith()
    {
        _isActive = !_isActive;
        EventActivate();
    }

    private void EventActivate()
    {
        if (_isActive)
            _active.Invoke();
        else
            _deactive.Invoke();
    }

}
