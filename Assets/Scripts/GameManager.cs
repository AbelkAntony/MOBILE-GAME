
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] MobileSwipeMovement Player;
    [SerializeField] UiManager uiManager;

    private int _score;

    private void Start()
    {
        _score = 0;
        uiManager.UpdateScoreText(_score);
    }

    public void AddScore()
    {
        _score += 1;
        uiManager.UpdateScoreText(_score);
    }

    public void GameOver()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0;
        uiManager.GameOver();
    }

    public void CloseButton()
    {
        Application.Quit();
    }
}
