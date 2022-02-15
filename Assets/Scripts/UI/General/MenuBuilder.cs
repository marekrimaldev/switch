using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UISelector))]
public class MenuBuilder : MonoBehaviour, IUIBuilder
{
    [SerializeField] private ButtonDisplay[] _buttonDisplays;

    private void Start()
    {
        AssignAdjacency();
        GetComponent<UISelector>().SetUIBuilder(this);
    }

    private void OnDisable()
    {
        for (int i = 0; i < _buttonDisplays.Length; i++)
        {
            _buttonDisplays[i].Highlight(false);
        }
    }

    public IUISelectable GetFirstUISelectable()
    {
        return _buttonDisplays[0];
    }

    private void AssignAdjacency()
    {
        for (int i = 0; i < _buttonDisplays.Length; i++)
        {
            _buttonDisplays[i].LeftSuccessor = _buttonDisplays[i];
            _buttonDisplays[i].RightSuccessor = _buttonDisplays[i];
            _buttonDisplays[i].DownSuccessor = _buttonDisplays[(i + 1) % _buttonDisplays.Length];
            _buttonDisplays[i].UpSuccessor = _buttonDisplays[(i + _buttonDisplays.Length - 1) % _buttonDisplays.Length];
        }
    }
}
