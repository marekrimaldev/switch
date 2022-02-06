using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _inGameMenuCanvas;

    [SerializeField] private StringGameEvent OnLoadMainMenuRequest;

    private void Start()
    {
        _inGameMenuCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        _inGameMenuCanvas.SetActive(!_inGameMenuCanvas.activeSelf);
    }

    public void LoadMainMenu()
    {
        OnLoadMainMenuRequest.Raise("MainMenu");
    }
}
