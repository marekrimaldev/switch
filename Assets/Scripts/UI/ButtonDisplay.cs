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

    public IUISelectable LeftSuccessor { get; set; }
    public IUISelectable RightSuccessor { get; set; }
    public IUISelectable UpSuccessor { get; set; }
    public IUISelectable DownSuccessor { get; set; }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Highlight(bool value)
    {
        if (value)
        {
            //_as.PlayOneShot(_highlightSound);
            SetHighlighted();
        }
        else
        {
            SetUnhighlighted();
        }
    }

    public void Select()
    {
        // SOUND
        _button.onClick.Invoke();
    }

    private void SetHighlighted()
    {
        _buttonImage.color = Color.yellow;
        _buttonText.color = Color.black;
    }

    private void SetUnhighlighted()
    {
        _buttonImage.color = Color.black;
        _buttonText.color = Color.white;
    }
}
