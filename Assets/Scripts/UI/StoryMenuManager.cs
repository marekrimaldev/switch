using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuManager : MonoBehaviour
{
    [SerializeField] private ButtonDisplay _loadGameButtonDisplay;

    private StoryManager _storyManager;

    private void Start()
    {
        StoryManager sm = FindObjectOfType<StoryManager>();
        if(sm != null)
        {
            if (sm.CanLoadProgress())
                _loadGameButtonDisplay.SetAvailable(true);
            else
                _loadGameButtonDisplay.SetAvailable(false);
        }
        else
        {
            Debug.LogWarning("StoryManager not found");
        }
    }

    public void StartNewStory()
    {
        _storyManager?.StartNewGame();
    }

    public void ResetStoryProgress()
    {
        _storyManager?.ResetProgress();
    }

    public void LoadStoryProgress()
    {
        _storyManager?.LoadProgress();
    }
}
