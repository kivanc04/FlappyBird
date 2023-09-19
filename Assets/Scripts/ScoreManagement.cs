using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManagement : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighestScore;
    public int highestScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void updateScore()
    {
        score++;
        ScoreText.text = score.ToString();

        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighScore", highestScore);
            PlayerPrefs.Save();
            UpdateHighestScoreText();
        }
    }

    public void UpdateHighestScoreText()
    {
        HighestScore.text = "Highest Score: " + highestScore.ToString();
    }
}
