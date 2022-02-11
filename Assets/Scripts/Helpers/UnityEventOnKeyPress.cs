using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnKeyPress : EventOnKeyPressBase
{
    [SerializeField] private UnityEvent OnKeyPress;

    protected override void InvokeEvent()
    {
        OnKeyPress?.Invoke();
    }
}
