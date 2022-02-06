using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip _switchSound;      // sound from joedeshon // other is https://freesound.org/people/Erokia/sounds/411746/

    private AudioSource _as;
    private SpriteRenderer _sr;
    private Color _color;

    [SerializeField] private VoidGameEvent OnColorSwitchRequest;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
        _sr = GetComponentInChildren<SpriteRenderer>();
        _color = _sr.color;
    }

    public Color GetColor()
    {
        return _color;
    }

    public void Interact(Player player)
    {
        if(player.GetComponentInChildren<SpriteRenderer>().color != _color)
        {
            _as.PlayOneShot(_switchSound);

            Void v;
            OnColorSwitchRequest.Raise(v);
        }
    }
}
