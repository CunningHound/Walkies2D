using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreDisplay;

    private void Start()
    {
        if(Globals.scoreManager != null)
        {
            Globals.scoreManager.EndLevel();
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
            Globals.scoreManager.ResetAll();
        }
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        if(Globals.scoreManager!= null)
        {
            Globals.scoreManager.ResetAll();
        }
        Time.timeScale = 1;
    }

}
