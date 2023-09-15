using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighestScore;
    public int highestScore;
    public TextMeshProUGUI LastTenScoresText;
    private List<int> lastTenScores = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();

        highestScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighestScoreText();
    }
    
    void Update()
    {

    }

    public void updateScore()
    {
        score++;
        ScoreText.text = score.ToString();

        if (score > highestScore)
        {
            highestScore = score;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highestScore);
            PlayerPrefs.Save();

            // Update the high score text
            UpdateHighestScoreText();
        }
        lastTenScores.Add(score);

        // Keep only the last 10 scores in the list
        if (lastTenScores.Count > 10)
        {
            lastTenScores.RemoveAt(0);
        }

        // Update the last ten scores text
        UpdateLastTenScoresText();
    }
    public void UpdateLastTenScoresText()
    {
        LastTenScoresText.text = "Last 10 Scores:\n";

        foreach (int score in lastTenScores)
        {
            LastTenScoresText.text += score + "\n";
        }
    }

    void UpdateHighestScoreText()
    {
        HighestScore.text = "Highest Scroe: " + highestScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

}
