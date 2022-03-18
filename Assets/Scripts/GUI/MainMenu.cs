using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public ScoreManager scoreManager;
    public void StartGame()
    {
        SceneManager.LoadScene("SimpleStreet");
        scoreManager.Reset();
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial_Jogger");
        scoreManager.Reset();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Debug.Log("[MainMenu::QuitGame] quitting game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
