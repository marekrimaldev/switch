using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSetter : MonoBehaviour
{
    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
