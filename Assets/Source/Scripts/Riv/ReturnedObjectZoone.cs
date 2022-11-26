using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnedObjectZoone : MonoBehaviour
{
    [SerializeField] private Transform _returnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Rigidbody rig))
        {
            rig.velocity = Vector3.zero;

            foreach(var collider in rig.GetComponentsInChildren<Collider>())
            {
                collider.isTrigger = false;
            }
        }

        other.transform.position = _returnPoint.position;
    }
}
