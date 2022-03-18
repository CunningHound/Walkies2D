using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelCompleteScreen levelCompleteScreen;
    public PlayerController player;
    public PauseScreen pauseScreen;

    public LevelGenerator levelGenerator;

    public ScoreManager scoreManager;
    public int levelLength;
    public string nextSceneName;

    private void Start()
    {
        if (levelCompleteScreen != null)
        {
            levelCompleteScreen.nextSceneName = nextSceneName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && player.transform.position.x > levelLength)
        {
            EndLevel();
        }

        if(Input.GetButtonDown("Cancel"))
        {
            Instantiate(pauseScreen);
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
}
