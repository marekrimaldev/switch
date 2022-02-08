using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryMenu : MonoBehaviour
{
    [SerializeField] private ButtonDisplay _loadGameButtonDisplay;

    private void Start()
    {
        Debug.Log("Can load progress = " + FindObjectOfType<StoryManager>().CanLoadProgress());
        _loadGameButtonDisplay.SetAvailable(FindObjectOfType<StoryManager>().CanLoadProgress());
    }
}
