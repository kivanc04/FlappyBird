using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Last10Scores : MonoBehaviour
{
    public TextMeshProUGUI LastTenScoresText;

    public List<int> lastTenScores = new List<int>();
    public const int maxLastTenScoresCount = 10;

    public void Start()
    {
        // Load last 10 scores from PlayerPrefs
        for (int i = 0; i < maxLastTenScoresCount; i++)
        {
            int savedScore = PlayerPrefs.GetInt($"LastScore{i}", 0);
            if (savedScore > 0)
            {
                lastTenScores.Add(savedScore);
            }
        }

        UpdateLastTenScoresText();
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
}