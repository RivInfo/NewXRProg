using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlitaController : MonoBehaviour
{
    [SerializeField] private GameObject fireObj;

    private bool isActivePlita = true; 
    public Pot currentPotOnPlita;

    private void Start()
    {
        //fireObj.SetActive(false);
        //Invoke(nameof(ActiveFirePlita), 5f);
    }

    public void ActiveFirePlita()
    {
        isActivePlita = !isActivePlita;
        fireObj.SetActive(isActivePlita);

        if (isActivePlita && currentPotOnPlita != null)
        {
            currentPotOnPlita.ActiveCookingPot();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Pot pot))
        {
            currentPotOnPlita = pot;

            if (isActivePlita)
                currentPotOnPlita.ActiveCookingPot();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Pot pot))
        {
            pot.DeActiveCookingPot();
            currentPotOnPlita = null;
        }
    }
}
