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
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();
        //transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
    
    void Update()
    {

    }

    public void updateScore()
    {
        score++;
        ScoreText.text = score.ToString(); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}
