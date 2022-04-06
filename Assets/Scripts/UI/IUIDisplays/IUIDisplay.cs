using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classes implementing this interface are able to react on StartHover and StopHover events
/// </summary>
public interface IUIDisplay
{
    void StartHover(bool isSelectAvailable);
    void StopHover(bool isSelectAvailable);
}
