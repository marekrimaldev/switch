using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private KeyCode _toggleButton = KeyCode.Escape;
    [SerializeField] private GameObject _inGameMenuCanvas;
    private Canvas[] _otherSceneCanvases;

    [SerializeField] private StringGameEvent OnLoadMainMenuRequest;

    private MenuTraversator _uiSelector;

    private void Awake()
    {
        _uiSelector = GetComponent<MenuTraversator>();
        SetTimeScale(1);
    }

    private void Start()
    {
        _inGameMenuCanvas.SetActive(false);
        _uiSelector.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(_toggleButton))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        _inGameMenuCanvas.SetActive(!_inGameMenuCanvas.activeSelf);
        _uiSelector.enabled = !_uiSelector.enabled;

        EnableSceneCanvases(!_inGameMenuCanvas.activeSelf);

        if (_inGameMenuCanvas.activeSelf)
            SetTimeScale(0);
        else
            SetTimeScale(1);
    }

    private void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    private void EnableSceneCanvases(bool enable)
    {
        if (!enable)
        {
            _otherSceneCanvases = FindObjectsOfType<Canvas>();
            for (int i = 0; i < _otherSceneCanvases.Length; i++)
            {
                if (_otherSceneCanvases[i].gameObject == _inGameMenuCanvas)
                    continue;

                _otherSceneCanvases[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < _otherSceneCanvases.Length; i++)
            {
                if (_otherSceneCanvases[i].gameObject == _inGameMenuCanvas)
                    continue;

                _otherSceneCanvases[i].gameObject.SetActive(true);
            }
        }
    }

    public void LoadMainMenu()
    {
        OnLoadMainMenuRequest.Raise("MainMenu");
    }
}
