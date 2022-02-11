using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _UI;
    [SerializeField] private TMP_Text _restartsText;
    [SerializeField] private TMP_Text[] _thresholds;

    private void OnEnable()
    {
        SwitchUIToColor(Color.black);   
    }

    public void ShowUI(bool value)
    {
        _UI.SetActive(value);
    }

    public void SwitchUIColor()
    {
        if (_restartsText.color == Color.white)
            SwitchUIToColor(Color.black);
        else
            SwitchUIToColor(Color.white);
    }

    private void SwitchUIToColor(Color color)
    {
        _restartsText.color = color;
        for (int i = 0; i < _thresholds.Length; i++)
        {
            _thresholds[i].color = color;
        }
    }

    public void UpdateRestarts(int restartCount)
    {
        string rs = "";
        for (int i = 0; i < restartCount; i++)
        {
            rs += ". ";
        }
        _restartsText.text = rs;
    }
}
