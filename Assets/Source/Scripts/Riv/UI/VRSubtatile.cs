using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class VRSubtatile : PositionatCanvasOnVr
{
    [SerializeField] private float _lerpValue = 0;
    [SerializeField] private Text _subtitle;
    [SerializeField] private float _delayFromOneChar = 0.5f;

    private Vector3 _lastPos = Vector3.zero;

    private Coroutine _coroutine;

    public static VRSubtatile Instance { get; private set; }

    private void OnEnable()
    {
        if(Instance == null)
            Instance = this;

        _subtitle.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if(Instance == this)
            Instance = null;
    }

    private void Update()
    {
        PlaceCanvas();

        transform.position = Vector3.Lerp(_lastPos, transform.position, _lerpValue);

        _lastPos = transform.position;
    }

    public void ShowSubtitle(string text, float delaySecond = 0)
    {
        _subtitle.gameObject.SetActive(true);
        _subtitle.text = text;

        if(_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(TextDisableWait(delaySecond));
    }

    private IEnumerator TextDisableWait(float delaySecond)
    {
        if (delaySecond == 0)
            delaySecond = _subtitle.text.Length * _delayFromOneChar;

        WaitForSeconds wait = new WaitForSeconds(delaySecond);
        yield return wait;
        _subtitle.gameObject.SetActive(false);
    }
}
