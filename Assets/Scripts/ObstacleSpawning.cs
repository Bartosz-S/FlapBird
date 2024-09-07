using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    [SerializeField] private float spawningDelay;
    [SerializeField] private float maxSpawnHeight;
    [SerializeField] private float minSpawnHeight;
    [SerializeField] private Object spawningObstacle;
    private float _time = 0;
     
    
    public float SpawnDelay {  get { return spawningDelay; } set {  spawningDelay = value; } }
    public Object Obstacle { get { return spawningObstacle; } set { spawningObstacle = value; } } 
    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        if(_time <= 0)
        {
            float _spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
            _time = spawningDelay;
            Instantiate(spawningObstacle, new Vector3(transform.position.x, _spawnHeight),
                default);
        }
        _time -= Time.deltaTime;
    }
}
