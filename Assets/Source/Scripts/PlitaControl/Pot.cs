using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject effectVape;

    private List<SwimPelmen> _pelmeni;

    private PotPelmenDetector _detector;

    private void Start()
    {
        _detector = GetComponentInChildren<PotPelmenDetector>();

        _pelmeni = GetComponentsInChildren<SwimPelmen>().ToList();

        foreach (var item in _pelmeni)
        {
            item.gameObject.SetActive(false);
        }

        _detector.PelmenInPot += OnPelmenInPot;

        effectVape.SetActive(false);
    }

    private void OnDestroy()
    {
        _detector.PelmenInPot -= OnPelmenInPot;
    }

    public void ActiveCookingPot()
    {
        effectVape.SetActive(true);
    }

    public void DeActiveCookingPot()
    {
        effectVape.SetActive(false);
    }

    private void OnPelmenInPot(Pelmen arg0)
    {
        arg0.gameObject.SetActive(false);

        List<SwimPelmen> noActive = _pelmeni.Where(_ => _.isActiveAndEnabled == false).ToList();

        if (noActive.Count > 0)
        {
            noActive[Random.Range(0, noActive.Count)].gameObject.SetActive(true);
        }
    }

    //private IEnumerator Smoo
}
