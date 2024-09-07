using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    //[SerializeField] GameObject spawner;
    [SerializeField] private float speedIncrease;
    
    private List<GameObject> _obstacleList = new List<GameObject>();
    private List<ObstacleScript> _obstacleScripts = new List<ObstacleScript>();
    public float _currentMoveSpeed = 0;
    public void IncreaseDifficulty()
    {
        _obstacleList.AddRange(GameObject.FindGameObjectsWithTag("Obstacle"));
        foreach (GameObject obstacle in _obstacleList)
        {
            _obstacleScripts.Add(obstacle.GetComponent<ObstacleScript>());
        }
        _currentMoveSpeed = _obstacleScripts[0].MoveSpeed + speedIncrease;
        foreach (ObstacleScript script in _obstacleScripts)
        {
            script.MoveSpeed = _currentMoveSpeed;
        }
        _obstacleList.Clear();
        _obstacleScripts.Clear();
    }
}
