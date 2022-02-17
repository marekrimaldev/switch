using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectBuilder : GridMenuBuilder
{
    //[SerializeField] private LevelSelectable _levelSelectablePrefab;
    //[SerializeField] private LevelInfo[] _levelInfos;

    public override ITraversable[] GetTraverzables()
    {
        //AssignAdjacency();
        return _uiTraversables.ToArray();
    }

    //private void BuildLevelSelect()
    //{
    //    Debug.Log(_levelSelectablePrefab.GetComponent<RectTransform>().lossyScale.x);
    //    ;
    //    float stepX = (_uiElementSize + _spacing) * _levelSelectablePrefab.GetComponent<RectTransform>().rect.width;
    //    float stepY = (_uiElementSize + _spacing) * _levelSelectablePrefab.GetComponent<RectTransform>().rect.height;

    //    int shouldShift = _levelsPerRow % 2 == 0 ? 1 : 0;   // Shift the start pos if there is even number of levels per row
    //    Vector2 startPos = Vector2.zero - (_levelsPerRow / 2) * stepX * Vector2.right + shouldShift * stepX * Vector2.right;

    //    for (int i = 0; i < _levelInfos.Length; i++)
    //    {
    //        int x = i % _levelsPerRow;
    //        int y = i / _levelsPerRow;
    //        Vector2 pos = startPos + x * stepX * Vector2.right - y * stepY * Vector2.up;

    //        MenuItem uiSelectable = Instantiate(_menuItemPrefab, Vector2.zero, Quaternion.identity, transform);
    //        uiSelectable.transform.localScale = new Vector2(_uiElementSize, _uiElementSize);
    //        uiSelectable.transform.localPosition = pos;

    //        LevelSelectable levelSelectable = uiSelectable.gameObject.AddComponent<LevelSelectable>();
    //        levelSelectable.SetLevelInfo(_levelInfos[i]);

    //        TextDisplay textDisplay = uiSelectable.GetComponent<TextDisplay>();
    //        textDisplay.DisplayText(_levelInfos[i].LevelName);

    //        _uiTraversables.Add(uiSelectable);
    //    }
    //}

    //private void AssignAdjacency()
    //{
    //    for (int i = 0; i < _uiTraversables.Count; i++)
    //    {
    //        int rowOffset = (i / _levelsPerRow) * _levelsPerRow;
    //        _uiTraversables[i].LeftSuccessor = _uiTraversables[rowOffset + (i + _levelsPerRow - 1) % _levelsPerRow];
    //        _uiTraversables[i].RightSuccessor = _uiTraversables[rowOffset + (i + _levelsPerRow + 1) % _levelsPerRow];
    //        _uiTraversables[i].UpSuccessor = _uiTraversables[(i + _uiTraversables.Count - _levelsPerRow) % _uiTraversables.Count];
    //        _uiTraversables[i].DownSuccessor = _uiTraversables[(i + _uiTraversables.Count + _levelsPerRow) % _uiTraversables.Count];
    //    }
    //}
}
