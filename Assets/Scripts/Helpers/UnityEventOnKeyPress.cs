using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnKeyPress : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    [SerializeField] private UnityEvent OnKeyPress;

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            OnKeyPress.Invoke();
        }
    }
}
