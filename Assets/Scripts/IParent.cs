using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classes which demands parenting the player on contact should implement this interface
/// </summary>
public interface IParent
{
    void AddChild(Transform t);
}
