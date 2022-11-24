using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject _effectVape;
    [SerializeField] private GameObject _effectSmallVape;

    [SerializeField] private float _heatingSecondsStep = 1;
    [SerializeField] private float _heatingSecondsMax = 60;

    private List<SwimPelmen> _pelmeni;

    private PotPelmenDetector _detector;

    private float _heatingSecond;
    private bool _isHeating = false;

    private Coroutine _heating;

    public event UnityAction PotHeating;
    public event UnityAction PotOnPlita;
    public event UnityAction<int> PelmenInPot;

    private void Start()
    {
        _detector = GetComponentInChildren<PotPelmenDetector>();

        _pelmeni = GetComponentsInChildren<SwimPelmen>().ToList();

        foreach (var item in _pelmeni)
        {
            item.gameObject.SetActive(false);
        }

        _detector.PelmenInPot += OnPelmenInPot;

        _effectVape.SetActive(false);
        _effectSmallVape.SetActive(false);
    }

    private void OnDestroy()
    {
        _detector.PelmenInPot -= OnPelmenInPot;
    }

    public void ActiveCookingPot()
    {
        if (_heating != null)
            StopCoroutine(_heating);
        _heating = StartCoroutine(WaterHeating());
        _effectSmallVape.SetActive(true);

        PotOnPlita?.Invoke();
    }

    public void DeActiveCookingPot()
    {
        _effectVape.SetActive(false);
        _effectSmallVape.SetActive(false);
    }

    private void OnPelmenInPot(Pelmen arg0)
    {
        if (_isHeating)
        {
            arg0.gameObject.SetActive(false);

            List<SwimPelmen> noActive = _pelmeni.Where(_ => _.isActiveAndEnabled == false).ToList();

            if (noActive.Count > 0)
            {
                arg0.gameObject.SetActive(false);
                noActive[Random.Range(0, noActive.Count)].gameObject.SetActive(true);

                PelmenInPot?.Invoke(_pelmeni.Count - noActive.Count+1);
            }
        }
    }

    private IEnumerator WaterHeating()
    {
        WaitForSeconds seconds = new WaitForSeconds(_heatingSecondsStep);

        while(_heatingSecond < _heatingSecondsMax)
        {
            _heatingSecond += _heatingSecondsStep;
            yield return seconds;
        }
        _isHeating = true;

        _effectVape.SetActive(true);
        _effectSmallVape.SetActive(false);

        PotHeating?.Invoke();
    }
}
