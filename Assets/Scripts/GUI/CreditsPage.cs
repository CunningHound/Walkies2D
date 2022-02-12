using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsPage : MonoBehaviour
{
    public Text textBox;
    public TextAsset creditsFile;

    private void Start()
    {
        if(creditsFile != null && textBox != null)
        {
            textBox.text = creditsFile.text;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
