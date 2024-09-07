using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverBehaviour : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Retry()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        PlayerPrefs.Save();
        SceneManager.LoadScene("SampleScene");
    }
}
