using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _inGameMenuCanvas;

    [SerializeField] private StringGameEvent OnLoadMainMenuRequest;

    private UISelector _uiSelector;

    private void Awake()
    {
        _uiSelector = GetComponent<UISelector>();
    }

    private void Start()
    {
        _inGameMenuCanvas.SetActive(false);
        _uiSelector.enabled = false;
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
        _uiSelector.enabled = !_uiSelector.enabled;
    }

    public void LoadMainMenu()
    {
        OnLoadMainMenuRequest.Raise("MainMenu");
    }
}
