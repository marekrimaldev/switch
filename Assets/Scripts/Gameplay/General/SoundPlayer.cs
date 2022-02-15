using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    private AudioSource _as;

    private void Awake()
    {
        _as = gameObject.AddComponent<AudioSource>();
        _as.playOnAwake = false;
    }

    public void PlaySound()
    {
        Debug.Log("Playing sound");
        _as.PlayOneShot(_sound);
    }
}
