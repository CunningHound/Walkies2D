using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialInfo : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        Time.timeScale = 0;
        if(Input.GetButtonDown("Cancel"))
        {
            Continue();
        }
    }

    public void QuitGame()
    {
        Debug.Log("[PauseScreen::QuitGame");
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        Debug.Log("[PauseScreen::Continue");
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
