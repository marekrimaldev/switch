using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject[] _subMenus;

    [Header("Buttons")]
    [SerializeField] private ButtonDisplay _levelSelectButtonDisplay;
    [SerializeField] private ButtonDisplay _loadGameButtonDisplay;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMainMenu();
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        ShowMainMenu();

        if (GameManager.Instance.IsStoryCompleted())
            _levelSelectButtonDisplay.SetAvailable(true);
        else
            _levelSelectButtonDisplay.SetAvailable(false);

        if (GameManager.Instance.CanLoadProgress())
            _loadGameButtonDisplay.SetAvailable(true);
        else
            _loadGameButtonDisplay.SetAvailable(false);
    }

    private void ShowMainMenu()
    {
        _mainMenu.SetActive(true);

        for (int i = 0; i < _subMenus.Length; i++)
        {
            _subMenus[i].SetActive(false);
        }
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
