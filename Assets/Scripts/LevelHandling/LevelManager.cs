using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public int score;

    public int maxLives;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            int currentPos = (int)Mathf.Floor(10*player.transform.position.x);
            if(currentPos > score)
            {
                score = currentPos;
            }
        }
    }

    public void loseLife()
    {
        lives--;
        if(lives <= 0)
        {
            // end game

            // go to menu
        }
    }

    public void addLife()
    { 
        if(lives < maxLives)
        {
            lives++;
        }
    }
}
