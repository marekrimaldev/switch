using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    [SerializeField] private Transform _minPoint;
    [SerializeField] private Transform _maxPoint;
    [SerializeField] private float _speed = 1;
    [SerializeField] private bool _isGoingUp = true;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (_isGoingUp)
            StartCoroutine(GoUp());
        else
            StartCoroutine(GoDown());
    }

    private IEnumerator GoUp()
    {
        while (transform.position.y < _maxPoint.position.y)
        {
            _rb.velocity = transform.up * _speed * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(GoDown());
    }

    private IEnumerator GoDown()
    {
        while (transform.position.y > _minPoint.position.y)
        {
            _rb.velocity = -transform.up * _speed * Time.deltaTime;
            yield return null;
        }

        StartCoroutine(GoUp());
    }
}
