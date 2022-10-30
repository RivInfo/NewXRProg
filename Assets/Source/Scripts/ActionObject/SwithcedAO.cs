using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithcedAO : ActionObject
{
    private void Start()
    {
        EventActivate();
    }

    private void Swith()
    {
        _isActive = !_isActive;
        EventActivate();
    }

    public override void Activate()
    {
        Swith();
    }

    public override void Deactivate()
    {
        Swith();
    }
}
