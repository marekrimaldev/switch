using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonDisplay : MonoBehaviour, IUISelectable
{
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Image _buttonImage;
    private Button _button;

    private bool _isAvailable = true;

    [Header("Colors")]
    [SerializeField] private Color _textUnselectColor = Color.white;
    [SerializeField] private Color _textSelectColor = Color.black;
    [SerializeField] private Color _textUnavailableColor = Color.gray;
    [SerializeField] private Color _backUnselectColor = Color.black;
    [SerializeField] private Color _backSelectColor = Color.yellow;

    [Header("Sound")]
    [SerializeField] private AudioClip _highlightSound;
    [SerializeField] private AudioClip _selectSound;
    [SerializeField] private AudioClip _unavailableSound;
    private AudioSource _as;

    public IUISelectable LeftSuccessor { get; set; }
    public IUISelectable RightSuccessor { get; set; }
    public IUISelectable UpSuccessor { get; set; }
    public IUISelectable DownSuccessor { get; set; }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _as = GetComponent<AudioSource>();

        SetUnhighlighted();
    }

    public void Highlight(bool value, bool playSound = false)
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
        if (_isAvailable)
        {
            GameObject go = new GameObject("Persistent sound player");
            go.AddComponent<AudioSource>();
            DontDestroyOnLoad(go);
            go.GetComponent<AudioSource>().volume = 0.5f;
            go.GetComponent<AudioSource>().PlayOneShot(_selectSound);
            Destroy(go, 1);

            _button.onClick.Invoke();
        }
        else
        {
            _as.PlayOneShot(_unavailableSound);
        }
    }

    public void SetAvailable(bool isAvailable)
    {
        _isAvailable = isAvailable;
        SetUnhighlighted();
    }

    private void SetHighlighted()
    {
        _buttonImage.color = _backSelectColor;

        if(_isAvailable)
            _buttonText.color = _textSelectColor;
        else
            _buttonText.color = _textUnavailableColor;
    }

    private void SetUnhighlighted()
    {
        _buttonImage.color = _backUnselectColor;

        if (_isAvailable)
            _buttonText.color = _textUnselectColor;
        else
            _buttonText.color = _textUnavailableColor;
    }
}
