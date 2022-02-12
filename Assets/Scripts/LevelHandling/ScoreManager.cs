using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreAtLevelStart;
    public int distanceThisLevel;
    public int currentScore;
    private int subtractedThisLevel;
    public PlayerController player;
    private int bestLevelScore;

    // Start is called before the first frame update
    private void Awake()
    {
        Globals.scoreManager = this;
    }

    void Start()
    {
        currentScore = 0;
        distanceThisLevel = 0;
        subtractedThisLevel = 0;
        bestLevelScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distanceThisLevel = (int)Mathf.Floor(player.transform.position.x);
        }
        currentScore = scoreAtLevelStart + distanceThisLevel - subtractedThisLevel;
    }

    public void EndLevel()
    {
        if(distanceThisLevel - subtractedThisLevel > bestLevelScore)
        {
            bestLevelScore = distanceThisLevel - subtractedThisLevel;
        }
        scoreAtLevelStart = currentScore;
    }

    private int getScoreCost(ScaryThingType scaryThingType)
    {
        switch(scaryThingType)
        {
            case ScaryThingType.BigBlackDog:
                return 20;
            case ScaryThingType.Jogger:
                return 5;
            case ScaryThingType.RubbishCollector:
                return 10;
            default:
                Debug.Log("looking up cost of unknown scare type:" + scaryThingType);
                return 0;
        }
    }

    public int Penalise(ScaryThingType scaryThingType)
    {
        int scoreCost = getScoreCost(scaryThingType);
        subtractedThisLevel += scoreCost;
        return scoreCost;
    }
}
