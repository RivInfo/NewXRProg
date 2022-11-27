using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _dieEffects;

    public event UnityAction<Enemy> Dead;

    public void TakeHit()
    {
        Die();
    }

    private void Die()
    {
        Instantiate(_dieEffects,transform.position, Quaternion.identity);
        Destroy(gameObject);
        Dead?.Invoke(this);
    }
}
