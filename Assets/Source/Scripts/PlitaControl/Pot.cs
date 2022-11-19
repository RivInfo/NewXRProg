using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject effectVape;

    private void Start()
    {
        effectVape.SetActive(false);
    }

    public void ActiveCookingPot()
    {
        effectVape.SetActive(true);
    }
}
