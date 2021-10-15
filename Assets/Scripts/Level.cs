using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    private List<Obstacle> _obstacles = new List<Obstacle>();

    private void Start()
    {
        FindAllObstacles();
    }

    public void RespawnPlayer(Player player)
    {
        player.transform.position = _spawn.position;
        player.ChangeColor(Color.black);
    }

    private void FindAllObstacles()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        for (int i=0; i< obstacles.Length; i++)
        {
            _obstacles.Add(obstacles[i]);
        }
    }

    public void ChangeColors()
    {
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.ChangeColor();
        }
    }
}
