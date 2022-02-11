using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuManager : MonoBehaviour
{
    [SerializeField] private ButtonDisplay _loadGameButtonDisplay;

    private void Start()
    {
        if (GameManager.Instance.CanLoadProgress())
            _loadGameButtonDisplay.SetAvailable(true);
        else
            _loadGameButtonDisplay.SetAvailable(false);
    }

    public void StartNewStory()
    {
        GameManager.Instance.StartNewGame();
    }

    public void ResetStoryProgress()
    {
        GameManager.Instance.ResetProgress();
    }

    public void LoadStoryProgress()
    {
        GameManager.Instance.LoadProgress();
    }
}
