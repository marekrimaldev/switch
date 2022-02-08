using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private string _storySceneName;
    [SerializeField] private string _mainMenuSceneName;

    [Header("UI")]
    [SerializeField] private TMP_Text _restartsText;
    [SerializeField] private TMP_Text[] _thresholds;

    public int Restarts { get; private set; } = 0;

    private LevelManager _levelManager;

    private const string ProgressKey = "StoryLevelName";
    private const string RestartKey = "RestartCount";

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnLevelWasLoaded(int level)
    {
        _levelManager = FindObjectOfType<LevelManager>();
        if(_levelManager == null)
            Debug.LogError("LevelManager cant be found");

        SwitchUIToColor(Color.black);

        if (_levelManager.GetCurrSceneName() == _mainMenuSceneName)
            Destroy(gameObject);
        else if (_levelManager.GetCurrSceneName() != _storySceneName)
            SaveProgress();
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

        UpdateRestarts();
    }

    public bool CanLoadProgress()
    {
        return PlayerPrefs.HasKey(ProgressKey);
    }

    public void ResetProgress()
    {
        Restarts = 0;
        UpdateRestarts();
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
        UpdateRestarts();
    }

    public void OnColorSwitch()
    {
        if (_restartsText.color == Color.white)
            SwitchUIToColor(Color.black);
        else
            SwitchUIToColor(Color.white);
    }

    private void SwitchUIToColor(Color color)
    {
        _restartsText.color = color;
        for (int i = 0; i < _thresholds.Length; i++)
        {
            _thresholds[i].color = color;
        }
    }

    private void UpdateRestarts()
    {
        string rs = "";
        for (int i = 0; i < Restarts; i++)
        {
            rs += ". ";
        }
        _restartsText.text = rs;
    }
}
