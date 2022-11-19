using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithcedNotStartActivate : ActionObject
{
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
