using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText; 
    private int score = 0;

    public Vector2 BallPosition;

    private void Start()
    {
        updateScoreText();

     
        if (HighScoreText != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            HighScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        updateScoreText();
 

     
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.Save();
        Handheld.Vibrate();
    }

    void updateScoreText()
    {
        ScoreText.text = score.ToString();
    }
}
