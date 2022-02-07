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

    [SerializeField] private AudioClip _highlightSound;
    [SerializeField] private AudioClip _selectSound;
    private AudioSource _as;

    public IUISelectable LeftSuccessor { get; set; }
    public IUISelectable RightSuccessor { get; set; }
    public IUISelectable UpSuccessor { get; set; }
    public IUISelectable DownSuccessor { get; set; }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _as = GetComponent<AudioSource>();
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
        GameObject go = new GameObject("Persistent sound player");
        go.AddComponent<AudioSource>();
        DontDestroyOnLoad(go);
        go.GetComponent<AudioSource>().volume = 0.5f;
        go.GetComponent<AudioSource>().PlayOneShot(_selectSound);
        Destroy(go, 1);

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
