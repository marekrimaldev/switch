using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UISelector : MonoBehaviour
{
    [SerializeField] private bool _startOnFirstSelectable = false;

    private IUIBuilder _uiBuilder;
    private IUISelectable _currSelectable;

    private void OnEnable()
    {
        if (_uiBuilder != null && _startOnFirstSelectable)
            _currSelectable = _uiBuilder.GetFirstUISelectable();

        _currSelectable?.Hover(true);
    }

    public void SetUIBuilder(IUIBuilder uiBuilder)
    {
        _uiBuilder = uiBuilder;
        _currSelectable = _uiBuilder.GetFirstUISelectable();
        _currSelectable.Hover(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _currSelectable.Hover(false);

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                _currSelectable = _currSelectable.LeftSuccessor;
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                _currSelectable = _currSelectable.RightSuccessor;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                _currSelectable = _currSelectable.UpSuccessor;
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                _currSelectable = _currSelectable.DownSuccessor;

            _currSelectable.Hover(true);

            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                _currSelectable.Select();
            }
        }
    }
}
