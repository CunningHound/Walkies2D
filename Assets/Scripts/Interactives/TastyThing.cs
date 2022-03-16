using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TastyThing : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject scoreChangeIndicator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            GameObject obj = Instantiate(scoreChangeIndicator, gameObject.transform.position, Quaternion.identity);
            ScoreChangeIndicator indicator = obj.transform.GetComponent<ScoreChangeIndicator>();
            indicator.Display(obstacleData.scoreCost * -1);
            obstacleData.Activate(player);
            Destroy(gameObject, 0.5f);
        }
    }
}
