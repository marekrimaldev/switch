using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private string[] _nonGameSceneNames;
    private List<string> _nonGameSceneNamesList = new List<string>();

    public int Restarts { get; private set; } = 0;
    public bool IsStoryModeOn { get; set; } = false;

    [SerializeField] private StoryUI _storyUI;

    private const string ProgressKey = "StoryLevelName";
    private const string RestartKey = "RestartCount";

    private LevelManager _levelManager;

    private void Awake()
    {
        StoryManager sm = FindObjectOfType<StoryManager>();
        if (sm != null && sm != this)
            Destroy(this.gameObject);

        for (int i = 0; i < _nonGameSceneNames.Length; i++)
        {
            _nonGameSceneNamesList.Add(_nonGameSceneNames[i]);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        _levelManager = FindObjectOfType<LevelManager>();
        if(_levelManager == null)
            Debug.LogError("LevelManager cant be found");

        string currSceneName =_levelManager.GetCurrSceneName();

        if (IsGameScene(currSceneName))
        {
            _storyUI.ShowUI(true);

            if (IsStoryModeOn)
                SaveProgress();
        }
        else
        {
            _storyUI.ShowUI(false);
        }
    }

    public void StartNewGame()
    {
        ResetProgress();
        _levelManager.OnLevelWasCompleted();
    }

    public void LoadProgress()
    {
        if (PlayerPrefs.HasKey(ProgressKey))
        {
            Restarts = PlayerPrefs.GetInt(RestartKey);

            string sceneToLoadName = PlayerPrefs.GetString(ProgressKey);
            Debug.Log("Scene name " + sceneToLoadName);
            _levelManager.LoadLevel(sceneToLoadName);
        }

        _storyUI.UpdateRestarts(Restarts);
    }

    public bool CanLoadProgress()
    {
        if(PlayerPrefs.HasKey(ProgressKey))
            Debug.Log("Saved scene = " + PlayerPrefs.GetString(ProgressKey));

        return PlayerPrefs.HasKey(ProgressKey);
    }

    public void ResetProgress()
    {
        Restarts = 0;
        _storyUI.UpdateRestarts(Restarts);
        PlayerPrefs.DeleteKey(ProgressKey);
    }

    private void SaveProgress()
    {
        Debug.Log("Saving progress in scene " + _levelManager.GetCurrSceneName());

        PlayerPrefs.SetInt(RestartKey, Restarts);

        string currSceneName = _levelManager.GetCurrSceneName();
        PlayerPrefs.SetString(ProgressKey, currSceneName);
    }

    public void OnLevelRestart()
    {
        Restarts++;
        _storyUI.UpdateRestarts(Restarts);
    }

    public bool IsStoryCompleted()
    {
        return PlayerPrefs.GetString(ProgressKey) == "Credits";
    }

    private bool IsGameScene(string sceneName)
    {
        return !_nonGameSceneNamesList.Contains(sceneName);
    }
}
