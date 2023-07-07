using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scored : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;


    private void Start()
    {
        UpdateScoreText();
    }

    public void MinusScore(int parts)
    {
        score -=parts;
        UpdateScoreText ();
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}