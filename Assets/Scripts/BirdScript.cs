using UnityEngine;
using UnityEngine.Events;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private float jumpStrength;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private AudioSource source;
    [SerializeField] private GameObject gameOverCanv;
    private Camera mainCamera;
    private Rigidbody2D _rb2d;
    private bool _isAlive = true;
    public bool GetIsAlive() {  return _isAlive; }

    public UnityEvent TouchedObstacle = new UnityEvent();
    public UnityEvent OutOfBonds = new UnityEvent();
    public UnityEvent Jumped = new UnityEvent();

    private void Awake()
    {
        TouchedObstacle.AddListener(OnGameOver);
        OutOfBonds.AddListener(OnGameOver);
        Jumped.AddListener(OnJump);
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _rb2d.angularVelocity = -rotationSpeed;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Jump();
        PosCheck();
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isAlive)
        {
            _rb2d.velocity = Vector2.up * jumpStrength;
            _rb2d.rotation = default;
            _rb2d.MoveRotation(10);
            Jumped.Invoke();
        }
    }
    private void PosCheck()
    {
        Vector3 posToCamera = mainCamera.WorldToViewportPoint(transform.position);
        if (!(posToCamera.x >= 0 && posToCamera.x <= 1 
            && posToCamera.y >= 0 && posToCamera.y <= 1))
        {
            OutOfBonds.Invoke();
        }
    }
    private void OnGameOver()
    {
        if (!_isAlive) return;
        _isAlive = false;
        Time.timeScale = 0f;
        PlayerPrefs.Save();
        gameOverCanv.SetActive(true);
        Debug.Log("Game Over");
    }
    private void OnJump()
    {
        source.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.isTrigger) return;
        TouchedObstacle.Invoke();
    }
}
