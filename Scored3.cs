using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scored3 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}