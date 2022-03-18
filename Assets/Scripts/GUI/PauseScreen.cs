using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    static PauseScreen instance;
    public ScoreManager scoreManager;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Continue();
        }
    }

    public void QuitGame()
    {
        Debug.Log("[PauseScreen::QuitGame");
        if (scoreManager != null)
        {
            scoreManager.Reset();
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Debug.Log("[PauseScreen::Continue");
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
