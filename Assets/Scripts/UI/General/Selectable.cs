using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour, ISelectable
{
    public abstract void Select();
}
