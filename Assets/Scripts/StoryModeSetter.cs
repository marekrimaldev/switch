using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryModeSetter : MonoBehaviour
{
    [SerializeField] private bool _setStoryMode;

    private void OnLevelWasLoaded(int level)
    {
        StoryManager sm = FindObjectOfType<StoryManager>();
        if(sm != null)
        {
            sm.IsStoryModeOn = _setStoryMode;
        }
    }
}
