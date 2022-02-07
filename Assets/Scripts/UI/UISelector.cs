using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UISelector : MonoBehaviour
{
    private IUIBuilder _uiBuilder;
    private IUISelectable _currSelectable;

    private void OnEnable()
    {
        _currSelectable?.Highlight(true, false);
    }

    public void SetUIBuilder(IUIBuilder uiBuilder)
    {
        _uiBuilder = uiBuilder;
        _currSelectable = _uiBuilder.GetFirstUISelectable();
        _currSelectable.Highlight(true, false);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _currSelectable.Highlight(false);

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                _currSelectable = _currSelectable.LeftSuccessor;
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                _currSelectable = _currSelectable.RightSuccessor;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                _currSelectable = _currSelectable.UpSuccessor;
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                _currSelectable = _currSelectable.DownSuccessor;

            _currSelectable.Highlight(true);

            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                _currSelectable.Select();
            }
        }
    }
}
