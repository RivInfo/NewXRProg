using UnityEngine;
using UnityEngine.XR;

public class HandCapsule : MonoBehaviour
{
    public bool IsLeftHand;

    public TinyInputDeviceManager InputDeviceManager;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Reset()
    {
        InputDeviceManager = GetComponentInParent<TinyInputDeviceManager>();
    }

    private void Update()
    {
        var inputDevice = IsLeftHand ? InputDeviceManager.LeftController : InputDeviceManager.RightController;

        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out var triggerValue);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out var gripValue);
        inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out var primaryVect);

        _renderer.material.color = new Color(triggerValue, gripValue, 1f);
    }
}
