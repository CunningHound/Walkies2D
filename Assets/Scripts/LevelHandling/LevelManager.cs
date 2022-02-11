using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public ScoreManager scoreManager;
    public int score;

    // Start is called before the first frame update
    private void Awake()
    {
        Globals.levelManager = this;
    }
    void Start()
    {
        scoreManager = Globals.scoreManager;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        if( gameOverScreen != null && scoreManager != null )
        {
            Instantiate(gameOverScreen);
            gameOverScreen.Display(scoreManager.currentScore);
        }
    }
}
