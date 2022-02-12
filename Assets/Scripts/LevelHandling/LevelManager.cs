using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public LevelCompleteScreen levelCompleteScreen;
    public PlayerController player;

    public LevelGenerator levelGenerator;

    private ScoreManager scoreManager;
    public int levelLength;

    // Start is called before the first frame update
    private void Awake()
    {
        Globals.levelManager = this;
    }
    void Start()
    {
        scoreManager = Globals.scoreManager;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && player.transform.position.x > levelLength)
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
        if( levelCompleteScreen != null && scoreManager != null )
        {
            Instantiate(levelCompleteScreen);
            scoreManager.EndLevel();
            player.transform.position = new Vector3(0, 0, 0);
        }
    }

    public void GameOver()
    {
        if( gameOverScreen != null && scoreManager != null )
        {
            Instantiate(gameOverScreen);
        }
    }
}
