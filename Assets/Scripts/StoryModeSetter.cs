using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryModeSetter : MonoBehaviour
{
    [SerializeField] private BoolGameEvent OnSetStoryMode;

    public void SetStoryMode(bool value)
    {
        OnSetStoryMode.Raise(value);
    }
}
