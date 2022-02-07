using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Color _color;
    private SpriteRenderer _sr;

    private bool _disabled = false;

    private void Awake()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _sr.color = Color.white;
        _color = Color.white;
    }

    public void LevelCompleteColor()
    {
        _disabled = true;
        Invoke("Enable", 2);
    }

    private void Enable()
    {
        _disabled = false;
        _color = Color.white;
        _sr.color = Color.white;
    }

    public void ChangeColor()
    {
        if (_disabled)
            return;

        if (_color == Color.white)
        {
            _color = Color.black;
            _sr.color = Color.black;
        }
        else
        {
            _color = Color.white;
            _sr.color = Color.white;
        }
    }
}
