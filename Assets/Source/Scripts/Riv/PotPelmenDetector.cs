using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PotPelmenDetector : MonoBehaviour
{
    public event UnityAction <Pelmen> PelmenInPot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Pelmen pelmen))
            PelmenInPot?.Invoke(pelmen);
    }
}
