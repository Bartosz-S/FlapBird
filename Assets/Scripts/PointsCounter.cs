using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text textTMP;
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject obstacleSpawner;
    [SerializeField] private DifficultyManager difficultyManager;
    private int _points = 0;
    private int _record = 0;
    private float _time = 0;

    
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        _record = PlayerPrefs.GetInt("Record");
        PlayerPrefs.SetInt("Record", _record);      
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (textTMP != null)
        {
            UpdatePoints();
            
            textTMP.text = "Points: " + _points + "\n"
                                           + "Highest score: " + _record;
            if(_points > _record)
            {
                _record = _points;
                PlayerPrefs.SetInt("Record", _record);
            }
        }
    }
    private void UpdatePoints()
    {
        
        if (_time < 1)
        {
            _time += Time.deltaTime;
            return;
        }
        if (_points % 10 == 0 && _points > 0)
        {
            difficultyManager.IncreaseDifficulty();
        }
        _points++;
        _time = 0;
    }
}
