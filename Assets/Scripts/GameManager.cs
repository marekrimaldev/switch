using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VoidGameEvent OnRestartLevel;

    [SerializeField] private int _startLevel = 0;
     
    [SerializeField] private Player _player;
    [SerializeField] private Level[] _levels;
    [SerializeField] private float _secondsAfterLevelComplete = 1f;
    private int _currLevel = 0;

    void Start()
    {
        _currLevel = _startLevel;
        RestartLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            NextLevel();
        }
    }

    public void LoadNextLevelInSeconds()
    {
        Invoke("NextLevel", _secondsAfterLevelComplete);
    }

    private void NextLevel()
    {
        if (_currLevel + 1 >= _levels.Length)
            return;

        _levels[_currLevel].gameObject.SetActive(false);
        _currLevel++;
        _levels[_currLevel].gameObject.SetActive(true);
        _levels[_currLevel].RespawnPlayer(_player);

        Void v;
        OnRestartLevel.Raise(v);
    }

    private void RestartLevel()
    {
        Void v;
        OnRestartLevel.Raise(v);
        _levels[_currLevel].RespawnPlayer(_player);
    }
}
