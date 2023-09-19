using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PanelAccess : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI ScoreText;
    public GameObject MenuScreen;
    public BirdScript birdy;
    private bool gameStarted = false;
    public GameObject currentUIScreen; 
    public GameObject PanelScreen;
    public GameObject Background;
    public GameObject NightBackground;
    public GameObject Platform;

    public void OpenPanel()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(true);
        }
    }
    public void ShowPanel()
    {
        if (currentUIScreen != null)
        {
            currentUIScreen.SetActive(false);
        }

        PanelScreen.SetActive(true);

        gameStarted = false;
        if (!gameStarted)
        {
            NightBackground.SetActive(true);
            Platform.SetActive(false);
            PanelScreen.SetActive(true);
            Panel.SetActive(true);
            Background.SetActive(false);
            MenuScreen.SetActive(false);
            birdy.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);
            gameStarted = true;
        }
    }

}

