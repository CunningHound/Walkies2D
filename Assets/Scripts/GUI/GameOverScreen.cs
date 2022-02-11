using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreDisplay;

    public void Display(int score)
    {
        gameObject.SetActive(true);
        scoreDisplay.text = "Score\n" + score;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SimpleStreet");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("quitting game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
