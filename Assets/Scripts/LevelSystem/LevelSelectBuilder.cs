using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectBuilder : MonoBehaviour, IUIBuilder
{
    [SerializeField] private LevelInfo[] _levelInfos;
    [SerializeField] private LevelDisplay _levelDisplayPrefab;
    private List<IUISelectable> _levelDisplays = new List<IUISelectable>();

    [SerializeField] private int _levelsPerRow = 5;
    [SerializeField] private int _spacing = 50;
    [SerializeField] private int _uiElementSize = 100;

    private void Awake()
    {
        BuildLevelSelect();
        AssignAdjacency();
    }

    public IUISelectable GetFirstUISelectable()
    {
        return _levelDisplays[0];
    }

    private void BuildLevelSelect()
    {
        float stepX = _uiElementSize + _spacing;
        float stepY = _uiElementSize + _spacing;

        int shouldShift = _levelsPerRow % 2 == 0 ? 1 : 0;   // Shift the start pos if there is even number of levels per row
        Vector2 startPos = Vector2.zero - (_levelsPerRow / 2) * stepX * Vector2.right + shouldShift * stepX * Vector2.right;

        for (int i = 0; i < _levelInfos.Length; i++)
        {
            int x = i % _levelsPerRow;
            int y = i / _levelsPerRow;
            Vector2 pos = startPos + x * stepX * Vector2.right - y * stepY * Vector2.up;

            LevelDisplay levelDisplay = Instantiate(_levelDisplayPrefab, Vector2.zero, Quaternion.identity, transform);
            levelDisplay.transform.localPosition = pos;
            levelDisplay.DisplayLevel(_levelInfos[i]);
            _levelDisplays.Add(levelDisplay);
        }
    }

    private void AssignAdjacency()
    {
        for (int i = 0; i < _levelDisplays.Count; i++)
        {
            int rowOffset = (i / _levelsPerRow) * _levelsPerRow;
            _levelDisplays[i].LeftSuccessor = _levelDisplays[rowOffset + (i + _levelsPerRow - 1) % _levelsPerRow];
            _levelDisplays[i].RightSuccessor = _levelDisplays[rowOffset + (i + _levelsPerRow + 1) % _levelsPerRow];
            _levelDisplays[i].UpSuccessor = _levelDisplays[(i + _levelDisplays.Count - _levelsPerRow) % _levelDisplays.Count];
            _levelDisplays[i].DownSuccessor = _levelDisplays[(i + _levelDisplays.Count + _levelsPerRow) % _levelDisplays.Count];
        }
    }
}
