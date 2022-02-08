using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCounter : MonoBehaviour
{
    public int Restarts { get; private set; } = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restarts++;
        }
    }
}
