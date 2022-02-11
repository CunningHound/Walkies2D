using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeIndicator : MonoBehaviour
{
    public LivesManager livesManager;
    public Image life1;
    public Image life2;
    public Image life3;
    
 // Start is called before the first frame update
    void Start()
    {
        livesManager = Globals.livesManager;
    }

    // Update is called once per frame
    void Update()
    {
        // shouldn't be possible, but maybe while level is being destroyed? let's be safe
        if (livesManager != null)
        {
            int livesLeft = livesManager.livesLeft;
            life1.enabled = (livesLeft > 0);
            life2.enabled = (livesLeft > 1);
            life3.enabled = (livesLeft > 2);
        }
    }
}
