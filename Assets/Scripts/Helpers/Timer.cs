using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private bool _startAutomaticaly = false;

    [SerializeField] private UnityEvent OnTimesUp;

    private void Start()
    {
        if (_startAutomaticaly)
            StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(_time);
        TimesUp();
    }

    private void TimesUp()
    {
        OnTimesUp.Invoke();
    }
}
