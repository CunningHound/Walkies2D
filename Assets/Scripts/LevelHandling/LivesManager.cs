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
    }

    private void Start()
    {
        livesLeft = maxLives;
    }

    public bool AddLife()
    {
        if(livesLeft < maxLives)
        {
            livesLeft++;
            return true;
        }
        return false;
    }

    public void LoseLife()
    { 
        if(livesLeft > 1)
        {
            livesLeft--;
            Debug.Log("[LivesManager::LoseLife] lost life, now:" + livesLeft);
        }
        else
        {
            Debug.Log("[LivesManager::LoseLife] game over");
            levelManager.GameOver();
        }
    }
}
