using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIndicator : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text scoreIndicator;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = Globals.scoreManager; 
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreManager != null && scoreIndicator != null)
        {
            scoreIndicator.text = "SCORE: " + scoreManager.currentScore;
        }
    }
}
