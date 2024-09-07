using UnityEngine;
using UnityEngine.UI;

public class AudioBackgroundBehaviour : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private Sprite audioOnSprite;
    [SerializeField] private Sprite audioOffSprite;
    [SerializeField] private GameObject audioButton;
    private Image _buttonImage;
    private bool _isPlaying = true;

    private void Awake()
    {
        _buttonImage = audioButton.GetComponent<Image>();
    }
    public void TurnOnOffAudio()
    {
        if (_isPlaying)
        {
            source.volume = 0;
            _isPlaying = false;
            _buttonImage.sprite = audioOffSprite;
            return;
        }
        if (!_isPlaying)
        {
            source.volume = 1;
            _isPlaying = true;
            _buttonImage.sprite = audioOnSprite;
        }
    }
}
