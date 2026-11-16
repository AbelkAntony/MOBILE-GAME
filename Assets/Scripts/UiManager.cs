using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject gameUi;
    [SerializeField] private GameObject gameOverUi;

    public void UpdateScoreText(int _score)
    {
        gameUi.SetActive(true);
        gameOverUi.SetActive(false);
        _scoreText.text = _score.ToString();
    }

    public void GameOver()
    {
        gameUi.SetActive(false);
        gameOverUi.SetActive(true);
    }
}
