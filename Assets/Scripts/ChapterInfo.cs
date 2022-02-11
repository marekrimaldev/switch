using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Levels/Chapter")]
public class ChapterInfo : ScriptableObject
{
    [SerializeField] private string _chapterName;
    [SerializeField] private LevelInfo _scoreScene;
    [SerializeField] private LevelInfo _mainMenuScene;
    [SerializeField] private LevelInfo[] _levelInfos;
    private List<LevelInfo> _levels = new List<LevelInfo>();

    private void Awake()
    {
        for (int i = 0; i < _levelInfos.Length; i++)
        {
            _levels.Add(_levelInfos[i]);
        }
    }

    public void IncludeScoreScene(bool value)
    {
        Debug.Log("Including score scene");

        if (value)
            AddFinalScene();
        else
            RemoveFinalScene();

        Debug.Log("Levels count = " + _levels.Count);
    }

    private void AddFinalScene()
    {
        if (_levels.Count == _levelInfos.Length)
        {
            _levels.Add(_scoreScene);
        }
    }

    private void RemoveFinalScene()
    {
        if (_levels.Count > _levelInfos.Length)
        {
            _levels.Remove(_scoreScene);
        }
    }

    public string GetFirstLevelName()
    {
        return _levelInfos[0].LevelName;
    }

    public string GetNextLevelName(string currLevelName)
    {
        return GetNextLevel(currLevelName).LevelName;
    }

    public void UnlockNextLevel(string currLevelName)
    {
        LevelInfo nextLevel = GetNextLevel(currLevelName);
        nextLevel.IsLocked = false;
    }

    private LevelInfo GetNextLevel(string currLevelName)
    {
        int i = 0;
        while (i < _levels.Count && _levels[i].LevelName != currLevelName)
        {
            i++;
        }

        if (i + 1 < _levels.Count)
            return _levels[i + 1];
        else
        {
            return _mainMenuScene;
        }
    }
}
