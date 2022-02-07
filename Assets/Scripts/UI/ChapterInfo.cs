using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Levels/Chapter")]
public class ChapterInfo : ScriptableObject
{
    [SerializeField] private string _chapterName;
    [SerializeField] private LevelInfo[] _levelInfos;

    public void UnlockNextLevel(int currLevelIndex)
    {
        if (currLevelIndex + 1 <= _levelInfos.Length)
            _levelInfos[currLevelIndex + 1].IsLocked = false;
    }
}
