using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(IUIDisplay))]
public class UISelectable : MonoBehaviour, IUISelectable
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private bool _isAvailable = true;

    [Header("Colors")]
    [SerializeField] private Color _textUnselectColor = Color.white;
    [SerializeField] private Color _textSelectColor = Color.black;
    [SerializeField] private Color _textUnavailableColor = Color.gray;
    [SerializeField] private Color _backUnselectColor = Color.black;
    [SerializeField] private Color _backSelectColor = Color.yellow;

    [Header("Events")]
    [SerializeField] private UnityEvent OnSelect;
    [SerializeField] private UnityEvent OnUnavailable;
    [SerializeField] private UnityEvent OnHoverEnter;
    [SerializeField] private UnityEvent OnHoverExit;

    public IUISelectable LeftSuccessor { get; set; }
    public IUISelectable RightSuccessor { get; set; }
    public IUISelectable UpSuccessor { get; set; }
    public IUISelectable DownSuccessor { get; set; }

    private void Awake()
    {
        EndHover();
    }

    public void Hover(bool value)
    {
        if (value)
            StartHover();
        else
            EndHover();
    }

    public void Select()
    {
        if (_isAvailable)
            OnSelect?.Invoke();
        else
            OnUnavailable?.Invoke();
    }

    public void SetAvailable(bool isAvailable)
    {
        _isAvailable = isAvailable;
        EndHover();
    }

    private void StartHover()
    {
        OnHoverEnter?.Invoke();
        _image.color = _backSelectColor;

        if(_isAvailable)
            _text.color = _textSelectColor;
        else
            _text.color = _textUnavailableColor;
    }

    private void EndHover()
    {
        OnHoverExit?.Invoke();
        _image.color = _backUnselectColor;

        if (_isAvailable)
            _text.color = _textUnselectColor;
        else
            _text.color = _textUnavailableColor;
    }
}
