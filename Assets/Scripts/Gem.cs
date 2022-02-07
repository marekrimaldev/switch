using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    [SerializeField] private VoidGameEvent OnLevelComplete;

    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _animationSpeed = 1;
    [SerializeField] private float _raiseCompleteInSeconds = 2f;
    [SerializeField] private AudioClip _pickUpSound;
    private AudioSource _as;

    private bool _triggered = false;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
        //GetComponentInChildren<SpriteRenderer>().color = Color.yellow;

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

    private IEnumerator LevelCompleteAnimation()
    {
        while (gameObject.activeSelf)
        {
            transform.localScale += new Vector3(1,1,1) * _animationSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public void Interact(Player player)
    {
        if (_triggered)
            return;

        _triggered = true;

        _as.PlayOneShot(_pickUpSound);
        StartCoroutine(LevelCompleteAnimation());

        Invoke("OnLevelCompleteRaise", _raiseCompleteInSeconds);
    }

    private void OnLevelCompleteRaise()
    {
        Void v;
        OnLevelComplete?.Raise(v);
    }
}
