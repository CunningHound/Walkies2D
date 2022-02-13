using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreAtLevelStart;
    public int currentScore;

    public int distanceThisLevel;
    public int subtractedThisLevel;

    private int bestLevelScore;

    public PlayerController player;

    private static ScoreManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Globals.scoreManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        ResetAll();
    }

    public void ResetAll()
    {
        currentScore = 0;
        scoreAtLevelStart = 0;

        distanceThisLevel = 0;
        subtractedThisLevel = 0;

        bestLevelScore = 0;
    }

    public void ResetLevelScores()
    {
        distanceThisLevel = 0;
        subtractedThisLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            return; // nothing to update when paused
            // also caused some trouble when loading new scene
        }
        if (player != null)
        {
            int distance = (int)Mathf.Floor(player.transform.position.x);
            if(distance > distanceThisLevel)
            {
                distanceThisLevel = distance;
            }
        }
        currentScore = scoreAtLevelStart + distanceThisLevel - subtractedThisLevel;
    }

    public void EndLevel()
    {
        Debug.Log("[ScoreManager::EndLevel]");
        player = null;
        currentScore = scoreAtLevelStart + distanceThisLevel - subtractedThisLevel;
        int scoreThisLevel = distanceThisLevel - subtractedThisLevel;
        if(scoreThisLevel > bestLevelScore)
        {
            bestLevelScore = scoreThisLevel;
        }
        scoreAtLevelStart += scoreThisLevel;
        ResetLevelScores();
    }
    public int Penalise(ScaryThingType type)
    {
        int scoreCost = GetScoreCost(type);
        Debug.Log("[ScoreManager::Penalise] encountered " + type + " and lost " + scoreCost + " points");
        subtractedThisLevel += scoreCost;
        return scoreCost;
    }

    public int Penalise(TastyThingType type)
    {
        int scoreCost = GetScoreCost(type);
        Debug.Log("[ScoreManager::Penalise] encountered " + type + " and lost " + scoreCost + " points");
        subtractedThisLevel += scoreCost;
        return scoreCost;
    }

    public int Penalise(MovingObstructionType type)
    {
        int scoreCost = GetScoreCost(type);
        Debug.Log("[ScoreManager::Penalise] encountered " + type + " and lost " + scoreCost + " points");
        subtractedThisLevel += scoreCost;
        return scoreCost;
    }

    private int GetScoreCost(ScaryThingType type)
    {
        switch(type)
        {
            case ScaryThingType.BigBlackDog:
                return 20;
            case ScaryThingType.Jogger:
                return 5;
            case ScaryThingType.RubbishCollector:
                return 10;
            default:
                Debug.Log("[ScoreManager::GetScoreCost] looking up cost of unknown scare type:" + type);
                return 0;
        }
    }

    private int GetScoreCost(TastyThingType type)
    {
        switch(type)
        {
            default:
                Debug.Log("[ScoreManager::GetScoreCost] looking up cost of tasty thing " + type);
                return 5;
        }
    }

    private int GetScoreCost(MovingObstructionType type)
    {
        switch(type)
        {
            case MovingObstructionType.Cyclist:
                return 10;
            default:
                Debug.Log("[ScoreManager::GetScoreCost] looking up cost of unknown obstruction type " + type);
                return 0;
        }
    }
}
