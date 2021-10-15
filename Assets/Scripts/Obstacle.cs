using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private LayerMask _whiteLayer;
    [SerializeField] private LayerMask blackLayer;


    private Color _color;
    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _color = _sr.color;
        if (_color == Color.white)
        {
            ChangeLayer(_whiteLayer);
        }
        else
        {
            ChangeLayer(blackLayer);
        }
    }

    private void ChangeLayer(LayerMask layer)
    {
        //foreach (Transform t in transform)
        //{
        //    t.gameObject.layer = layer;
        //}
    }

    public void ChangeColor()
    {
        //if (_color == Color.white)
        //{
        //    _color = Color.black;
        //    _sr.color = _color;
        //    gameObject.layer = _blackMask;
        //}
        //else
        //{
        //    _color = Color.white;
        //    _sr.color = _color;
        //    gameObject.layer = _whiteMask;
        //}
    }

    public Color GetColor()
    {
        return _color;
    }
}
