using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelManager))]
public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance;  } }

    [SerializeField] private string _mainMenuSceneName;
    [SerializeField] private string _creditsSceneName;
    [SerializeField] private ChapterInfo[] _chapters;
    private int _currChapterIdx = 0;

    /// <summary>
    /// Story mode enables saving progress and includes final scene
    /// </summary>
    public bool IsStoryModeOn {
        get { return _isStoryModeOn;  }
        set 
        {
            _isStoryModeOn = value;
            _chapters[_currChapterIdx].IncludeScoreScene(IsStoryModeOn);
        }
    }
    private bool _isStoryModeOn = false;
    public int Restarts { get; private set; } = 0;

    [SerializeField] private StoryUI _storyUI;

    private const string ProgressKey = "StoryLevelName";
    private const string RestartKey = "RestartCount";

    private LevelManager _levelManager;

    private void Awake()
    {
        if (GameManager._instance != null && GameManager._instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        _levelManager = GetComponent<LevelManager>();
        _storyUI.ShowUI(false);
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

    private void OnLevelWasLoaded(int level)
    {
        string currSceneName =_levelManager.GetCurrSceneName();
        if (IsStoryModeOn)
        {
            if (currSceneName != _mainMenuSceneName)
            {
                SaveProgress();
                _storyUI.ShowUI(true);
                _storyUI.SwitchUIToColor(Color.black);
            }
        }
        else
        {
            _storyUI.ShowUI(false);
        }
    }

    public void StartNewGame()
    {
        ResetProgress();
        string firstLevelName = _chapters[0].GetFirstLevelName();
        _levelManager.LoadScene(firstLevelName);
    }

    private void SaveProgress()
    {
        Debug.Log("Saving progress in scene " + _levelManager.GetCurrSceneName());

        PlayerPrefs.SetInt(RestartKey, Restarts);

        string currSceneName = _levelManager.GetCurrSceneName();
        PlayerPrefs.SetString(ProgressKey, currSceneName);
    }

    public bool CanLoadProgress()
    {
        if (PlayerPrefs.HasKey(ProgressKey))
            Debug.Log("Saved scene = " + PlayerPrefs.GetString(ProgressKey));

        return PlayerPrefs.HasKey(ProgressKey);
    }

    public void LoadProgress()
    {
        if (PlayerPrefs.HasKey(ProgressKey))
        {
            Restarts = PlayerPrefs.GetInt(RestartKey);

            string sceneToLoadName = PlayerPrefs.GetString(ProgressKey);
            Debug.Log("Scene name " + sceneToLoadName);
            _levelManager.LoadScene(sceneToLoadName);
        }

        _storyUI.UpdateRestarts(Restarts);
    }

    public void ResetProgress()
    {
        Restarts = 0;
        _storyUI.UpdateRestarts(Restarts);
        PlayerPrefs.DeleteKey(ProgressKey);
    }

    public void RestartLevel()
    {
        Restarts++;
        _storyUI.UpdateRestarts(Restarts);
        _levelManager.RestartScene();
    }

    public void OnLevelWasCompleted()
    {
        string currSceneName = _levelManager.GetCurrSceneName();
        if (currSceneName == _creditsSceneName)
        {
            _levelManager.LoadScene(_mainMenuSceneName);
        }
        else
        {
            _chapters[_currChapterIdx].UnlockNextLevel(currSceneName);
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        string currLevelName = _levelManager.GetCurrSceneName();

        if (IsThisTheLastLevelInTheGame(currLevelName))
            _levelManager.LoadScene(_creditsSceneName);
        else
        {
            string nextLevelName = _chapters[_currChapterIdx].GetNextLevelName(currLevelName);
            _levelManager.LoadScene(nextLevelName);
        }
    }

    private bool IsThisTheLastLevelInTheGame(string currLevelName)
    {
        string nextLevelName = _chapters[_currChapterIdx].GetNextLevelName(currLevelName);
        if (nextLevelName == _mainMenuSceneName && IsStoryModeOn && _currChapterIdx == _chapters.Length - 1)
            return true;

        return false;
    }

    public bool IsStoryCompleted()
    {
        return PlayerPrefs.GetString(ProgressKey) == _creditsSceneName;
    }
}
