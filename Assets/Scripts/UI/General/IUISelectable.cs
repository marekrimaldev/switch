using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classes implementing this interface can be traversed and selected
/// Defines successors of this object in 4 directions LEFT, RIGHT, UP, DOWN
/// </summary>
public interface IUISelectable
{
    IUISelectable LeftSuccessor { get; set; }
    IUISelectable RightSuccessor { get; set; }
    IUISelectable UpSuccessor { get; set; }
    IUISelectable DownSuccessor { get; set; }

    void Hover(bool value);
    void Select();
}
