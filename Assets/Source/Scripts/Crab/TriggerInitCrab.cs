using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TriggerInitCrab : MonoBehaviour
{
    [SerializeField] private CrabEndGame prefabCrab;
    [SerializeField] private Transform positionStart;

    private bool isActiveTriggerCrab = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActiveTriggerCrab)
        {
            if (collision.gameObject.TryGetComponent(out XROrigin _))
            {
                Instantiate(prefabCrab, positionStart.position, Quaternion.Euler(-90,0,0));
            }
        }
    }

    public void ActiveredTriggerCrab()
    {
        isActiveTriggerCrab = true;
    }
}
