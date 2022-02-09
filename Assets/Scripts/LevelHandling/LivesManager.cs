using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int maxLives;
    private int livesLeft;

    public Image life1;
    public Image life2;
    public Image life3;
    

    void Start()
    {
        livesLeft = maxLives;
        life1.enabled = true;
        life2.enabled = true;
        life3.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        life1.enabled = (livesLeft > 0);
        life2.enabled = (livesLeft > 1);
        life3.enabled = (livesLeft > 2);
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
