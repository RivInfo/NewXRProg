using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool _isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive && other.TryGetComponent(out EnemyMover enemy))
        {
            Debug.LogWarning("Bonk rouch Trigger");
        }
    }

    public void Activate()
    {
        _isActive = true;
        Debug.LogWarning("Aktivate");
    }

    public void Dectivate()
    {
        _isActive = false;
    }
}
