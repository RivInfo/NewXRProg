using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _dieEffects;

    public void TakeHit()
    {
        Die();
    }

    private void Die()
    {
        Instantiate(_dieEffects,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
