using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;      // sound from joedeshon // other is https://freesound.org/people/Erokia/sounds/411746/

    private Color _color;
    private SpriteRenderer _sr;
    private AudioSource _audioSource;   

    private bool _disabled = false;

    private void Awake()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
        _sr = GetComponentInChildren<SpriteRenderer>();
        _sr.color = Color.white;
        _color = Color.white;
    }

    public void LevelCompleteColor()
    {
        //_sr.color = Color.yellow;
        _disabled = true;
        Invoke("Enable", 2);
    }

    private void Enable()
    {
        _disabled = false;
        _color = Color.white;
        _sr.color = Color.white;
    }

    public void ChangeToWhite()
    {
        _color = Color.white;
        _sr.color = _color;
    }

    public void ChangeColor()
    {
        if (_disabled)
            return;

        _audioSource.PlayOneShot(_sound);

        if (_color == Color.white)
        {
            _color = Color.black;
            _sr.color = _color;
        }
        else
        {
            _color = Color.white;
            _sr.color = _color;
        }
    }
}
