using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels/Level")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private string _levelName = "";
    public string LevelName { get { return _levelName; } set { _levelName = value; } }

    [SerializeField] private bool _isLocked = false;
    public bool IsLocked { get { return _isLocked; } set { _isLocked = value; } }
}