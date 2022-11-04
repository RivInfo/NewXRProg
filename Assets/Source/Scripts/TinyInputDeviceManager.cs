using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TinyInputDeviceManager : MonoBehaviour
{
    public InputDevice LeftController { get; private set; }
    public InputDevice RightController { get; private set; }

    private void Awake()
    {
        var listDevices = new List<InputDevice>();
        InputDevices.GetDevices(listDevices);

        foreach (var inputDevice in listDevices)
        {
            InitController(inputDevice);
        }

        InputDevices.deviceConnected += InitController;
    }

    private void OnDestroy()
    {
        InputDevices.deviceConnected -= InitController;
    }

    private void InitController(InputDevice inputDevice)
    {
        Debug.Log(inputDevice.name);

        if (!inputDevice.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
        {
            return;
        }

        if (inputDevice.characteristics.HasFlag(InputDeviceCharacteristics.Left))
        {
            LeftController = inputDevice;
        }
        else
        {
            RightController = inputDevice;
        }
        Debug.Log(inputDevice.isValid + " "+ inputDevice.name);
    }
}
