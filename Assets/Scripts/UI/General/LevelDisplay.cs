using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDisplay : MonoBehaviour, IUIDisplay
{
    [SerializeField] private StringGameEvent OnLevelSelect;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    private LevelInfo _levelInfo;

    [Header("Colors")]
    [SerializeField] private Color _textUnselectColor = Color.white;
    [SerializeField] private Color _textSelectColor = Color.black;
    [SerializeField] private Color _textUnavailableColor = Color.gray;
    [SerializeField] private Color _backUnselectColor = Color.black;
    [SerializeField] private Color _backSelectColor = Color.yellow;

    public void DisplayLevel(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
        _text.text = levelInfo.LevelName;
    }

    public void StartHover()
    {
        throw new System.NotImplementedException();
    }

    public void EndHover()
    {
        throw new System.NotImplementedException();
    }

    public void SelectLevel()
    {
        OnLevelSelect.Raise(_levelInfo.LevelName);
    }
}
