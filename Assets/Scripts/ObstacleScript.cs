using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float despawnPositionX;
    private DifficultyManager _difficultyManager;
    public float MoveSpeed {  get { return moveSpeed; } set {  moveSpeed = value; } }

    private void Update()
    {
        Move();
        PosCheck();
    }

    private void Move()
    {
        transform.Translate(-1 * new Vector3(moveSpeed*Time.deltaTime, 0));
    }
    private void PosCheck()
    {
        if (transform.position.x < despawnPositionX)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _difficultyManager = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<DifficultyManager>();
        if (_difficultyManager._currentMoveSpeed <= MoveSpeed) return;
        moveSpeed = _difficultyManager._currentMoveSpeed;
    }
}
