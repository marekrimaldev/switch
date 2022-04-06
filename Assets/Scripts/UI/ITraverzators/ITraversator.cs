using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ITraversators can traverse ITraversables
/// </summary>
public interface ITraversator
{
    void SetTraversable(ITraversable traversable);
}
