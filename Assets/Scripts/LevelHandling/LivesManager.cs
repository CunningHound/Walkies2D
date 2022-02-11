using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int maxLives;
    public int livesLeft { get; private set;}

    private LevelManager levelManager;
   

    void Awake()
    {
        Globals.livesManager = this;
    }

    private void Start()
    {
        livesLeft = maxLives;
        levelManager = Globals.levelManager;
    }

    public bool addLife()
    {
        if(livesLeft < maxLives)
        {
            livesLeft++;
            Debug.Log("adding life, now: " + livesLeft);
            return true;
        }
        Debug.Log("full lives, doing nothing");
        return false;
    }

    public void loseLife()
    { 
        if(livesLeft > 1)
        {
            livesLeft--;
            Debug.Log("lost life, now:" + livesLeft);
        }
        else
        {
            Debug.Log("game over");
            levelManager.GameOver();
        }
    }
}
