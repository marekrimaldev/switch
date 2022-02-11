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

    [SerializeField] private VoidGameEvent OnLevelRestart;

    public void LoadLevel(string levelName)
    {
        Debug.Log("Loading level " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void OnLevelWasCompleted()
    {
        _chapterInfo.UnlockNextLevel(_levelIndex);
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int currSceneBuildIdx = SceneManager.GetActiveScene().buildIndex;
        if ((int)(SceneManager.GetActiveScene().buildIndex + 1) < SceneManager.sceneCountInBuildSettings)
            LoadLevel(SceneManager.GetSceneByBuildIndex(currSceneBuildIdx + 1).name);
        else
            SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
    }

    public void RestartLevel()
    {
        Void v;
        OnLevelRestart.Raise(v);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetBuildIdxFromSceneName(string sceneName)
    {
        return SceneManager.GetSceneByName(sceneName).buildIndex;
    }

    public string GetCurrSceneName()
    {
        return SceneManager.GetActiveScene().name;
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
