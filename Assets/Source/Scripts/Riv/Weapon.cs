using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _isActive = false;

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
    }

    public void Dectivate()
    {
        _isActive = false;
    }
}
