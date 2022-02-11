using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreDisplay;

    public void Display(int score)
    {
        gameObject.SetActive(true);
        scoreDisplay.text = "Score\n" + score;
    }

}
