using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TriggerInitCrab : MonoBehaviour
{
    [SerializeField] private CrabEndGame prefabCrab;
    [SerializeField] private Transform positionStart;

    private bool isActiveTriggerCrab = false;

    private void Start()
    {
        prefabCrab.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isActiveTriggerCrab)
        {
            if (collision.gameObject.TryGetComponent(out PlayerAudio _))
            {
                prefabCrab.gameObject.SetActive(true);
                prefabCrab.JumpToPlayer();
                isActiveTriggerCrab = false;
            }
        }
    }

    public void ActiveredTriggerCrab()
    {
        isActiveTriggerCrab = true;
    }
}
