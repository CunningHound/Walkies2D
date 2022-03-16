using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreDisplay;
    public ScoreManager scoreManager;

    private void Start()
    {
        Debug.Log("[GameOverScreen::Start]");
        if(scoreManager != null)
        {
            scoreManager.EndLevel();
            int score = scoreManager.currentScore;
            Display(score);
        }
    }

    public void Display(int score)
    {
        Debug.Log("[GameOverScreen::Display]");
        Time.timeScale = 0;
        gameObject.SetActive(true);
        scoreDisplay.text = "Score\n" + score;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SimpleStreet");
        if(scoreManager!= null)
        {
            scoreManager.Reset();
        }
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        if(scoreManager!= null)
        {
            scoreManager.Reset();
        }
        Time.timeScale = 1;
    }

}
