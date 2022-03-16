using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeIndicator : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Image life1;
    public Image life2;
    public Image life3;
    
    // Update is called once per frame
    void Update()
    {
        // shouldn't be possible, but maybe while level is being destroyed? let's be safe
        if (scoreManager != null)
        {
            int livesLeft = scoreManager.lives;
            life1.enabled = (livesLeft > 0);
            life2.enabled = (livesLeft > 1);
            life3.enabled = (livesLeft > 2);
        }
    }
}
