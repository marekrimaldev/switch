using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Binds UI with GameManager
/// </summary>
public class GameManagerUIBinder : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private MenuItem _levelSelectButtonDisplay;
    [SerializeField] private MenuItem _loadGameButtonDisplay;

    void Awake()
    {
        SceneManager.sceneLoaded += SetupMainMenuButtons;
    }

    private void SetupMainMenuButtons(Scene scene, LoadSceneMode mode)
    {
        // This is only valid if buttons are assigned
        if (_levelSelectButtonDisplay == null)
            return;

        if (GameManager.Instance.IsStoryCompleted())
            _levelSelectButtonDisplay.SetAvailable(true);
        else
            _levelSelectButtonDisplay.SetAvailable(false);

        if (GameManager.Instance.CanLoadProgress())
            _loadGameButtonDisplay.SetAvailable(true);
        else
            _loadGameButtonDisplay.SetAvailable(false);
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }

    public void StartNewStory()
    {
        GameManager.Instance.StartNewGame();
    }

    public void ResetStoryProgress()
    {
        GameManager.Instance.ResetProgress();
    }

    public void LoadStoryProgress()
    {
        GameManager.Instance.LoadProgress();
    }

    public void SetStoryMode(bool value)
    {
        GameManager.Instance.IsStoryModeOn = value;
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
