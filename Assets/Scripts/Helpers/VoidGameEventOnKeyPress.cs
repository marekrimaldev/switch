using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidGameEventOnKeyPress : EventOnKeyPressBase
{
    [SerializeField] private VoidGameEvent OnKeyPress;

    protected override void InvokeEvent()
    {
        Void v;
        OnKeyPress?.Raise(v);
    }
}
