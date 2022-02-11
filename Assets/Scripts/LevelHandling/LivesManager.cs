using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int maxLives;
    public int livesLeft { get; private set;}
   

    void Awake()
    {
        Globals.livesManager = this;
    }

    private void Start()
    {
        livesLeft = maxLives;
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
        if(livesLeft > 0)
        {
            livesLeft--;
            Debug.Log("lost life, now:" + livesLeft);
        }
        else
        {
            // TODO: game over
            Debug.Log("game over");
        }
    }
}
