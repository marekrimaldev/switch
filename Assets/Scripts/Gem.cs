using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private VoidGameEvent OnLevelComplete;

    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _animationSpeed = 1;
    [SerializeField] private AudioClip _pickUpSound;
    private AudioSource _audioSource;

    private bool _triggered = false;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
        GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_triggered)
            return;

        _triggered = true;

        Debug.Log("Level Completed");

        _audioSource.PlayOneShot(_pickUpSound);

        StartCoroutine(LevelCompleteAnimation());

        Void v;
        OnLevelComplete?.Raise(v);
    }

    private IEnumerator LevelCompleteAnimation()
    {
        while (gameObject.activeSelf)
        {
            transform.localScale += new Vector3(1,1,1) * _animationSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
