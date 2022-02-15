using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gem : MonoBehaviour, ITriggerInteractable
{
    [SerializeField] private VoidGameEvent OnLevelComplete;
    [SerializeField] private UnityEvent OnInteract;

    [SerializeField] private float _nextLevelInSeconds = 2f;
    [SerializeField] private AudioClip _pickUpSound;
    private AudioSource _as;

    private bool _triggered = false;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    public void Interact(Player player)
    {
        if (_triggered)
            return;

        _triggered = true;

        _as.PlayOneShot(_pickUpSound);
        OnInteract.Invoke();

        Invoke("OnLevelCompleteRaise", _nextLevelInSeconds);
    }

    private void OnLevelCompleteRaise()
    {
        Void v;
        OnLevelComplete?.Raise(v);
    }
}
