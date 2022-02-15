using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDisplay : MonoBehaviour, IUISelectable
{
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private Image _levelImage;
    private LevelInfo _levelInfo;

    [SerializeField] private AudioClip _highlightSound;
    [SerializeField] private AudioClip _selectSound;
    [SerializeField] private AudioClip _unavailableSound;
    private AudioSource _as;

    [SerializeField] private StringGameEvent OnLevelSelect;

    public IUISelectable LeftSuccessor { get; set; }
    public IUISelectable RightSuccessor { get; set; }
    public IUISelectable UpSuccessor { get; set; }
    public IUISelectable DownSuccessor { get; set; }

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    public void DisplayLevel(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
        _levelNumberText.text = levelInfo.LevelName;

        SetUnhighlighted();
    }

    public void Highlight(bool value, bool playSound = true)
    {
        if (value)
        {
            if(playSound)
                _as.PlayOneShot(_highlightSound);

            SetHighlighted();
        }
        else
        {
            SetUnhighlighted();
        }
    }

    public void Select()
    {
        if (_levelInfo.IsLocked)
        {
            _as.PlayOneShot(_unavailableSound);
        }
        else
        {
            GameObject go = new GameObject("Persistent sound player");
            go.AddComponent<AudioSource>();
            DontDestroyOnLoad(go);
            go.GetComponent<AudioSource>().PlayOneShot(_selectSound);
            Destroy(go, 5);

            OnLevelSelect.Raise(_levelInfo.LevelName);
        }
    }

    private void SetHighlighted()
    {
        if (_levelInfo.IsLocked)
        {
            _levelImage.color = Color.white;
            _levelNumberText.color = Color.black;
        }
        else
        {
            _levelImage.color = Color.yellow;
            _levelNumberText.color = Color.black;
        }
    }

    private void SetUnhighlighted()
    {
        if (_levelInfo.IsLocked)
        {
            _levelImage.color = Color.black;
            _levelNumberText.color = Color.white;
        }
        else
        {
            _levelImage.color = Color.black;
            _levelNumberText.color = Color.yellow;
        }
    }
}
