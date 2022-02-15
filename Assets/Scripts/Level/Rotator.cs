using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private bool _startAutomaticaly = false;

    private Coroutine _rotateCoroutine;

    private void Start()
    {
        if (_startAutomaticaly)
            StartRotation();
    }

    public void StartRotation()
    {
        _rotateCoroutine = StartCoroutine(Rotate());
    }

    public void StopRotation()
    {
        if(_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
