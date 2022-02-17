using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectable : MonoBehaviour, ISelectable
{
    [SerializeField] private StringGameEvent OnLevelSelect;
    [SerializeField] private LevelInfo _levelInfo;

    public void SetLevelInfo(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
    }

    public void Select()
    {
        OnLevelSelect.Raise(_levelInfo.LevelName);
    }
}
