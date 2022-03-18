using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleData obstacleData;
    IObstacleMovement movement;

    public GameObject scoreChangeIndicator;

    protected virtual void Start()
    {
        // nothing complex for now
        Vector3 pos = transform.position;
        movement = GetComponent<IObstacleMovement>();
    }

    private void Update()
    {
        if(movement != null)
        {
            transform.parent.position = movement.GetNextPosition(gameObject.transform.parent);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            if (!(player.sitting && obstacleData.ignoredWhileSitting))
            {
                obstacleData.Activate(player);
                movement.Interaction();
                if (scoreChangeIndicator != null)
                {
                    GameObject obj = Instantiate(scoreChangeIndicator, gameObject.transform.parent);
                    ScoreChangeIndicator indicator = obj.GetComponent<ScoreChangeIndicator>();
                    indicator.Display(obstacleData.scoreCost * -1);
                }
            }
        }
    }
}
