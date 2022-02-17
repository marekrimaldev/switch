using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour, IInteractable
{
    [SerializeField] private VoidGameEvent OnColorSwitch;
    [SerializeField] private UnityEvent OnColorSwitchUE;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void Interact(PlayerController player)
    {
        SpriteRenderer sr = player.GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            if(sr.color != _sr.color)
            {
                Void v;
                OnColorSwitch?.Raise(v);
                OnColorSwitchUE?.Invoke();
            }
        }
    }
}
