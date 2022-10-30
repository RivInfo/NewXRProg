using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class InterectableObgect : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
}
