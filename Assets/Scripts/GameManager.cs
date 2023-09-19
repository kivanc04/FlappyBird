using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Device;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighestScore;
    public int highestScore;

    public GameObject MenuScreen;
    public PipeSpawnerScript play;
    public Button rankingButton;
    public Button playButton;
    public Button TurnBack;
    public BirdScript birdy;
    private bool gameStarted = false;

    public TextMeshProUGUI[] scores = new TextMeshProUGUI[10];
    public const int maxLastTenScoresCount = 10;
    public List<GameObject> pipesInUse = new List<GameObject>();
    public GameObject currentUIScreen; // Reference to the main UI screen
    public GameObject PanelScreen;
    public TextMeshProUGUI LastTenScoresText;
    public TextMeshProUGUI mytext;
    public List<int> lastTenScores = new List<int>();

    public GameObject UIScreen;
    public GameObject Background;
    public GameObject NightBackground;
    public GameObject Platform;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();

        highestScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighestScoreText();

        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].text = score.ToString();
        }
        

        playButton.onClick.AddListener(OnPlayButtonClick);
        rankingButton.onClick.AddListener(ShowPanel);

        play.enabled = false;
        MenuScreen.SetActive(true);

        // Load last 10 scores
        LoadLastTenScores();

        // Update the UI for last 10 scores
        UpdateLastTenScoresText();

        if (NightBackground&&Background.activeInHierarchy)
        {
            NightBackground.SetActive(false);
            mytext.enabled = true;
        }
    }

    void Update()
    {
        // Your Update logic here
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
    public void TurnBackButton()
    {
        if (!NightBackground.activeInHierarchy)
        {
            TurnBack.enabled = false;
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
            PanelScreen.SetActive(false);
            play.enabled = true;
            gameStarted = true;
        }
    }

    public void LoadLastTenScores()
    {
        for (int i = 0; i < maxLastTenScoresCount; i++)
        {
            int savedScore = PlayerPrefs.GetInt($"LastScore{i}", 0);
            if (savedScore > 0)
            {
                lastTenScores.Add(savedScore);
            }
        }
    }

    public void SaveLastTenScores()
    {
        for (int i = 0; i < lastTenScores.Count; i++)
        {
            PlayerPrefs.SetInt($"LastScore{i}", lastTenScores[i]);
        }
        PlayerPrefs.Save();
    }

    public void UpdateLastTenScoresText()
    {
        if (LastTenScoresText != null)
        {
            LastTenScoresText.text = "Last 10 Scores:\n";

            foreach (int score in lastTenScores)
            {
                LastTenScoresText.text += score + "\n";
            }
        }
    }

    public void ActivatePanelScreen()
    {
        UIScreen.SetActive(false);  // Deactivate the UI screen
        PanelScreen.SetActive(true); // Activate the panel screen
    }

    public void TabButton()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].text = score.ToString();

            if (!gameStarted)
            {
                MenuScreen.SetActive(false);
                PanelScreen.SetActive(true);
                Platform.SetActive(false);
                NightBackground.SetActive(true);
            }
        }
    }

    public void ShowPanel()
    {
        if (currentUIScreen != null)
        {
            currentUIScreen.SetActive(false);
        }

        PanelScreen.SetActive(true);

        // Save the last 10 scores before showing the panel
        SaveLastTenScores();

        gameStarted = false;
        if (!gameStarted)
        {
            NightBackground.SetActive(true);
            Platform.SetActive(false);
            PanelScreen.SetActive(true);
            Panel.SetActive(true);
            Background.SetActive(false);
            MenuScreen.SetActive(false);
            //birdy.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);
            gameStarted = true;
        }
    }
}

