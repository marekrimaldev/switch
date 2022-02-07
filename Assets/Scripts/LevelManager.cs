using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Each level must have one LevelManager which manages the level events
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private ChapterInfo _chapterInfo;
    [SerializeField] private int _levelIndex = 0;

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void OnLevelWasCompleted()
    {
        _chapterInfo.UnlockNextLevel(_levelIndex);
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        if ((int)(SceneManager.GetActiveScene().buildIndex + 1) < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            LoadNextLevel();
        }
    }
}
