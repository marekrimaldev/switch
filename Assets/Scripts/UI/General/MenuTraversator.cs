using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuTraversator : MonoBehaviour, ITraversator
{
    [SerializeField] private bool _startOnFirstSelectable = false;

    private ITraversable _currTraversable;

    public void SetTraversable(ITraversable traversable)
    {
        _currTraversable = traversable;
        _currTraversable?.OnHoverStart();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _currTraversable.OnHoverStop();

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                _currTraversable = _currTraversable.LeftSuccessor;
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                _currTraversable = _currTraversable.RightSuccessor;
            else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                _currTraversable = _currTraversable.UpSuccessor;
            else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                _currTraversable = _currTraversable.DownSuccessor;

            _currTraversable.OnHoverStart();

            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                _currTraversable.Select();
            }
        }
    }
}
