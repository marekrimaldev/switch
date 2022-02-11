using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestartDisplay : MonoBehaviour
{
    [SerializeField] private int _goldThreshold;
    [SerializeField] private int _silverThreshold;
    [SerializeField] private int _bronzeThreshold;
    [SerializeField] private TMP_Text _scoreText;
     
    [SerializeField] private SpriteRenderer[] _stars;

    private void Start()
    {
        GameManager rc = FindObjectOfType<GameManager>();
        if (rc != null)
        {
            _scoreText.text = rc.Restarts.ToString();
            ShowStars(rc.Restarts);
        }
    }

    private void ShowStars(int restarts)
    {
        int starCount = 0;

        if (restarts <= _goldThreshold)
        {
            starCount = 3;
        }
        else if (restarts <= _silverThreshold)
        {
            starCount = 2;
        }
        else if (restarts <= _bronzeThreshold)
        {
            starCount = 1;
        }

        for (int i = starCount; i < _stars.Length; i++)
        {
            _stars[i].color = Color.gray;
        }
    }
}
