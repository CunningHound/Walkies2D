using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    public Text scoreDisplay;

    private void Start()
    {
        if (Globals.scoreManager != null)
        {
            int score = Globals.scoreManager.currentScore;
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
        if(Globals.scoreManager!= null)
        {
            Globals.scoreManager.ResetLevelScores();
        }
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        if(Globals.scoreManager!= null)
        {
            Globals.scoreManager.ResetLevelScores();
        }
    }
}
