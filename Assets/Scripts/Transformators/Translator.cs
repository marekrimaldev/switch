using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [Tooltip("Defines the path of this object. If no pathpoints are assigned this component is ignored.")]
    [SerializeField] private Transform[] _pathPoints;
    private int _nextPointIdx = 0;

    private void Start()
    {
        if(_pathPoints.Length != 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        while (true)
        {
            Vector3 vec = _pathPoints[_nextPointIdx].position - transform.position;
            Vector3 dir = vec.normalized;
            while (vec.magnitude > 0.1)
            {
                transform.Translate(dir * _speed * Time.deltaTime, Space.World);
                vec = _pathPoints[_nextPointIdx].position - transform.position;

                yield return null;
            }

            _nextPointIdx++;
            _nextPointIdx = _nextPointIdx % _pathPoints.Length;
        }
    }
}
