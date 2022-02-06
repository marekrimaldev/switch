using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    [SerializeField] private LevelSelectBuilder _levelSelectBuilder;

    private IUIBuilder _uiBuilder;
    private IUISelectable _currLevelSelected;

    private void OnLevelWasLoaded(int level)
    {
        _uiBuilder = FindObjectOfType<IUIBuilder>();
        _currLevelSelected = _levelSelectBuilder.GetFirstUISelectable();
        _currLevelSelected.Highlight(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _currLevelSelected.Highlight(false);

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                _currLevelSelected = _currLevelSelected.LeftSuccessor;
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                _currLevelSelected = _currLevelSelected.RightSuccessor;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                _currLevelSelected = _currLevelSelected.UpSuccessor;
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                _currLevelSelected = _currLevelSelected.DownSuccessor;

            _currLevelSelected.Highlight(true);

            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                _currLevelSelected.Select();
            }
        }
    }
}
