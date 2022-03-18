using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScoreManager")]
public class ScoreManager : ScriptableObject { 

    public int currentScore;

    public int scoreAtLevelStart;

    public int distanceThisLevel;
    public int subtractedThisLevel;

    public int lives;
    public GameObject gameOverScreen;

    public void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        currentScore = 0;
        scoreAtLevelStart = 0;
        distanceThisLevel = 0;
        subtractedThisLevel = 0;
        lives = 3;
    }

    public void EndLevel()
    {
        scoreAtLevelStart = currentScore;
        distanceThisLevel = 0;
        subtractedThisLevel = 0;
        lives = 3;
    }

    private void recalculate()
    {
        currentScore = scoreAtLevelStart + distanceThisLevel - subtractedThisLevel;
    }

    public void setDistanceInLevel(int distance)
    {
        if (distance > distanceThisLevel)
        {
            distanceThisLevel = distance;
            recalculate();
        }
    }

    public void loseScore(int amount)
    {
        subtractedThisLevel += amount;
        recalculate();
    }

    public void loseLife()
    {
        lives--;
        if (lives <= 0 && gameOverScreen != null)
        {
            Instantiate(gameOverScreen);
            Time.timeScale = 0;
        }
    }

}
