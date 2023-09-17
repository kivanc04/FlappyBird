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
    public GameObject MenuScreen;
    public PipeSpawnerScript play;
    public Button rankingButton;
    public Button playButton;
    public BirdScript birdy;
    private bool gameStarted = false;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;
    public TextMeshProUGUI score6;
    public TextMeshProUGUI score7;
    public TextMeshProUGUI score8;
    public TextMeshProUGUI score9;
    public TextMeshProUGUI score10;
    public GameObject Panel;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();

        highestScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighestScoreText();

        score1.text = score.ToString();
        score2.text = score.ToString();
        score3.text = score.ToString();
        score4.text = score.ToString();
        score5.text = score.ToString();
        score6.text = score.ToString();
        score7.text = score.ToString();
        score8.text = score.ToString();
        score9.text = score.ToString();
        score10.text = score.ToString();

        playButton.onClick.AddListener(ShowPanel);
        
        play.enabled = false;
        MenuScreen.SetActive(true);
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

            PlayerPrefs.SetInt("HighScore", highestScore);
            PlayerPrefs.Save();

            UpdateHighestScoreText();
        }
        lastTenScores.Add(score);

        if (lastTenScores.Count > 10)
        {
            lastTenScores.RemoveAt(0);
        }

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
    public void OnPlayButtonClick()
    {
        if (!gameStarted) 
        {
            MenuScreen.SetActive(false); 
            play.enabled = true; 
            gameStarted = true; 
        }
    }
    public void ShowPanel()
    {
        if (!gameStarted)
        {
            MenuScreen.SetActive(false);
            birdy.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);
            gameStarted = true;
           
            Panel.SetActive(true);

            score1.gameObject.SetActive(true);
            score2.gameObject.SetActive(true);
            score3.gameObject.SetActive(true);
            score4.gameObject.SetActive(true);
            score5.gameObject.SetActive(true);
            score6.gameObject.SetActive(true);
            score7.gameObject.SetActive(true);
            score8.gameObject.SetActive(true);
            score9.gameObject.SetActive(true);
            score10.gameObject.SetActive(true);
        }
    }
   
}
/*
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
    public GameObject MenuScreen;
    public PipeSpawnerScript play;
    public Button playButton;
    private bool gameStarted = false;
    public Button rankingButton;
    public BirdScript birdy;
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;
    public TextMeshProUGUI score6;
    public TextMeshProUGUI score7;
    public TextMeshProUGUI score8;
    public TextMeshProUGUI score9;
    public TextMeshProUGUI score10;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();

        highestScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighestScoreText();

        playButton.onClick.AddListener(OnPlayButtonClick);
        rankingButton.onClick.AddListener(ShowScoreDisplay);


        play.enabled = false;
        MenuScreen.SetActive(true);

        // Hide the score display screen initially
        HideScoreDisplay();
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

            PlayerPrefs.SetInt("HighScore", highestScore);
            PlayerPrefs.Save();

            UpdateHighestScoreText();
        }
        lastTenScores.Add(score);

        if (lastTenScores.Count > 10)
        {
            lastTenScores.RemoveAt(0);
        }

        UpdateLastTenScoresText();
    }

    public void UpdateLastTenScoresText()
    {
        // Display the last 10 scores in the UI Text elements
        for (int i = 0; i < lastTenScores.Count && i < 10; i++)
        {
            string scoreText = "Score " + (i + 1) + ": " + lastTenScores[i].ToString();

            // Update each UI Text element individually
            switch (i)
            {
                case 0:
                    score1.text = scoreText;
                    break;
                case 1:
                    score2.text = scoreText;
                    break;
                case 2:
                    score3.text = scoreText;
                    break;
                case 3:
                    score4.text = scoreText;
                    break;
                case 4:
                    score5.text = scoreText;
                    break;
                case 5:
                    score6.text = scoreText;
                    break;
                case 6:
                    score7.text = scoreText;
                    break;
                case 7:
                    score8.text = scoreText;
                    break;
                case 8:
                    score9.text = scoreText;
                    break;
                case 9:
                    score10.text = scoreText;
                    break;
            }
        }
    }

    void UpdateHighestScoreText()
    {
        HighestScore.text = "Highest Score: " + highestScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPlayButtonClick()
    {
        if (!gameStarted)
        {
            MenuScreen.SetActive(false);
            play.enabled = true;
            gameStarted = true;
        }
    }

    // Show the score display screen
    public void ShowScoreDisplay()
    {
        // Enable the GameObjects containing the Text elements
        if (!gameStarted)
        {
            MenuScreen.SetActive(false);
            birdy.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);
            gameStarted = true;

            score1.gameObject.SetActive(true);
            score2.gameObject.SetActive(true);
            score3.gameObject.SetActive(true);
            score4.gameObject.SetActive(true);
            score5.gameObject.SetActive(true);
            score6.gameObject.SetActive(true);
            score7.gameObject.SetActive(true);
            score8.gameObject.SetActive(true);
            score9.gameObject.SetActive(true);
            score10.gameObject.SetActive(true);
        }
    }

    // Hide the score display screen
    public void HideScoreDisplay()
    {
        // Disable the GameObjects containing the Text elements
        score1.gameObject.SetActive(false);
        score2.gameObject.SetActive(false);
        score3.gameObject.SetActive(false);
        score4.gameObject.SetActive(false);
        score5.gameObject.SetActive(false);
        score6.gameObject.SetActive(false);
        score7.gameObject.SetActive(false);
        score8.gameObject.SetActive(false);
        score9.gameObject.SetActive(false);
        score10.gameObject.SetActive(false);
    }
}

*/