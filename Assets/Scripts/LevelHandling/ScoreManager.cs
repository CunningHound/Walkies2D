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
    public GameObject scoreChangeIndicator;

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

    public int Penalise(ScaryThing scaryThing)
    {
        int scoreCost = GetScoreCost(scaryThing.scareType);
        Debug.Log("[ScoreManager::Penalise] encountered " + scaryThing.scareType + " and lost " + scoreCost + " points");
        subtractedThisLevel += scoreCost;
        DisplayScoreChange(scoreCost, scaryThing.transform.parent);
        return scoreCost;
    }

    public int Penalise(TastyThing tastyThing)
    {
        int scoreCost = GetScoreCost(tastyThing.type);
        Debug.Log("[ScoreManager::Penalise] encountered " + tastyThing.type + " and lost " + scoreCost + " points");
        subtractedThisLevel += scoreCost;
        DisplayScoreChange(scoreCost, tastyThing.transform.position);
        return scoreCost;
    }

    public int Penalise(MovingObstruction obstruction)
    {
        int scoreCost = GetScoreCost(obstruction.type);
        Debug.Log("[ScoreManager::Penalise] encountered " + obstruction.type + " and lost " + scoreCost + " points");
        subtractedThisLevel += scoreCost;
        DisplayScoreChange(scoreCost, obstruction.transform);
        return scoreCost;
    }

    private void DisplayScoreChange(int amount, Transform parent)
    {
        if (amount != 0 && scoreChangeIndicator != null)
        {
            GameObject obj = Instantiate(scoreChangeIndicator, parent);
            ScoreChangeIndicator change = obj.GetComponent<ScoreChangeIndicator>();
            if (change != null)
            {
                change.Display(amount * -1);
            }
        }
    }

    private void DisplayScoreChange(int amount, Vector3 position)
    {
        if (amount != 0 && scoreChangeIndicator != null)
        {
            GameObject obj = Instantiate(scoreChangeIndicator, position, Quaternion.identity);
            ScoreChangeIndicator change = obj.GetComponent<ScoreChangeIndicator>();
            if (change != null)
            {
                change.Display(amount * -1);
            }
        }
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
