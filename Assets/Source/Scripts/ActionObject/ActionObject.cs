using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ActionObject : MonoBehaviour
{
    [SerializeField] protected bool _isActive;

    [SerializeField] protected UnityEvent _activate;
    [SerializeField] protected UnityEvent _deactivate;

    public virtual void Activate() 
    { 
        _activate.Invoke(); 
    }

    public virtual void Deactivate()
    {
        _deactivate.Invoke();
    }

    protected void EventActivate()
    {
        if (_isActive)
            _activate.Invoke();
        else
            _deactivate.Invoke();
    }

}
