using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 1;

    public void StartScaling()
    {
        StartCoroutine(Scale());
    }

    private IEnumerator Scale()
    {
        while (gameObject.activeSelf)
        {
            transform.localScale += new Vector3(1, 1, 1) * _scaleSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
