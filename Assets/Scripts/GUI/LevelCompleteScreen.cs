using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    public Text scoreDisplay;
    ScoreManager scoreManager;

    private void Start()
    {
        if (scoreManager != null)
        {
            int score = scoreManager.currentScore;
            Display(score);
        }
    }

    public void Display(int score)
    {
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
    }
}
