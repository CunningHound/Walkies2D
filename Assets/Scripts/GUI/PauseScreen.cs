using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    static PauseScreen instance;

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
        if (Globals.scoreManager != null)
        {
            Globals.scoreManager.Reset();
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
